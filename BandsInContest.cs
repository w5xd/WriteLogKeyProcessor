using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WriteLogKeyProcessor
{
    class BandsInContest
    {
        private double[] hamBandsMHz = {
        1.8,
        3.5,
        7,
        10.1,
        14,
        18.068,
        21,
        24.89,
        28,
        50,
        144,
        222,
        420,
        902,
        1240,
        2300,
        3300,
        5650,
        10000,
        24000,
        47000,
        76000,
        122500,
        134000,
        241000,
        275000};

        private Dictionary<short, List<double> > m_seBandIdxToBand;
        private List<double> m_bandList;

        public Dictionary<short, List<double>> BandIdxToBand
        {
            get { return new Dictionary<short, List<double> >(m_seBandIdxToBand); }
        }

        public List<double> BandList
        {
            get { return new List<double>(m_bandList); }
        }

        public bool IsAllowed(short band, double[] allowedBands)
        {
            if (allowedBands == null)
                return true;
            List<double> freqs;
            if (m_seBandIdxToBand.TryGetValue(band, out freqs))
            {
                // freqs is the list of indicies into m_bandList that correspond to the given band
                foreach (double bandFreq in freqs)
                    foreach (double edge in allowedBands)
                        if (bandFreq == edge)
                            return true;
                return false;
            }
            return true;
        }

        public BandsInContest(WriteLogClrTypes.IWriteL wl)
        {
            WriteLogClrTypes.ISingleEntry se = (WriteLogClrTypes.ISingleEntry)wl.CreateEntry();
            // This is pretty hokey, but works...
            // iterate through combination of all bands and modes, taking the result of ISingleEntry.GetBand.
            // The result is a mapping from GetBand to a frequency in our hamBandsMHz array.
            // 
            // But some of those mappings are almost certainly invalid because the "invalid band" return
            // is one higher than the highest valid one. But WriteLog automation interfaces don't tell
            // us that number. So we "find" it.
            // 
            short prevBand = -2; // not -1 in case GetBand returns that--it doesn't normally.
            double prevMhz = 0;
            m_bandList = new List<double>();
            m_seBandIdxToBand = new Dictionary<short, List<double>>();
            short highestBand = -1;
            Dictionary<double, List<short>> BandIndicesForFreq = new Dictionary<double, List<short>>();
            foreach (double ed in hamBandsMHz)
            {
                double hz = ed * 1e3;
                for (short m = 1; m <= 6; m++)
                {
                    se.SetLogFrequencyEx(m, hz, hz, 0);
                    short b = se.GetBand();
                    if (b > highestBand)
                        highestBand = b;

                    // knowing contest modules report their bands in
                    // increasing frequency order, 
                    // skip non-zero bands until we get a zero return
                    if (prevBand == -2 && b != 0)
                        continue;
                    if (!BandIndicesForFreq.ContainsKey(ed))
                        BandIndicesForFreq.Add(ed, new List<short>());
                    BandIndicesForFreq[ed].Add(b);
                    if (prevMhz != ed)
                    {
                        m_bandList.Add(ed);
                        prevMhz = ed;
                    }
                    if (!m_seBandIdxToBand.ContainsKey(b))
                        m_seBandIdxToBand.Add(b, new List<double>());
                    m_seBandIdxToBand[b].Add(ed);
                    prevBand = b;
                }
            }

            // with one theoretical exception the highestBandIndex is and invalid band,
            // and any band edge in BandIndiciesForFreq that ONLY has highestBandIndex needs to be remove.
            // The exception is that ALL possible band/mode combinations are valid.
            //
            // We'll detect that exception by checking if highestBand appears more often
            // than any other.

            bool keepHighestBandIndex = true;
            if (m_seBandIdxToBand.ContainsKey(highestBand))
            {
                keepHighestBandIndex = false;
                int highestBandsCount = m_seBandIdxToBand[highestBand].Count;
                foreach (var idxs in m_seBandIdxToBand)
                {
                    if (idxs.Key == highestBand)
                        continue;
                    if (idxs.Value.Count >= highestBandsCount)
                    {
                        keepHighestBandIndex = true;
                        break;
                    }
                }
            }
            if (!keepHighestBandIndex)
            {
                foreach (var bands in BandIndicesForFreq)
                {
                    bool freqOk = false;
                    foreach (short b in bands.Value)
                    {
                        if (b != highestBand)
                        {
                            freqOk = true;
                            break;
                        }
                    }
                    if (!freqOk)
                         m_bandList.Remove(bands.Key);
                 }
            }
       }
    }
}
