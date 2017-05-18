using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WriteLogKeyProcessor
{
    public partial class KeyProcessorSettingsForm : Form
    {
        private KeyProcessorSettings m_settings;
        private List<double> m_loadedBandsMhz;


        internal KeyProcessorSettingsForm(KeyProcessorSettings s, BandsInContest bl)
        {
            m_settings = s;
            m_loadedBandsMhz = bl.BandList;
            InitializeComponent();
        }


        private void RunModeSettingsForm_Load(object sender, EventArgs e)
        {
            CheckedListBox[] listBoxes = { checkedListBoxRadio1,
                                             checkedListBoxRadio2,
                                             checkedListBoxRadio3,
                                             checkedListBoxRadio4};
            CheckBox[] checkBoxes = { checkBoxRadio1, checkBoxRadio2, checkBoxRadio3, checkBoxRadio4 };
            int[] sumChecks = { 0, 0, 0, 0 };
            for (uint i = 1; i <= 4; i++)
            {
                String sName = String.Format("AllowedBandsRadio{0}", i);
                double[] v = (double[])m_settings[sName];
                for (int j = 0; j < m_loadedBandsMhz.Count; j++)
                {
                    bool checkItem = false;
                    if (v == null || v.Length == 0)
                        checkItem = true;
                    else foreach (double s in v)
                        {
                            if (s == m_loadedBandsMhz[j])
                            {
                                checkItem = true;
                                break;
                            }
                        }
                    if (checkItem)
                        sumChecks[i - 1] += 1;
                    string bandString;
                    double bandEdge = m_loadedBandsMhz[j];
                    if (bandEdge < 1000.0)
                        bandString = bandEdge.ToString() + "M";
                    else
                        bandString = (bandEdge/1000).ToString() + "G";
                    listBoxes[i - 1].Items.Add(bandString, checkItem);
                }
            }
            for (uint i = 0; i < 4; i++)
            {
                if (sumChecks[i] == 0)
                        checkBoxes[i].CheckState = CheckState.Unchecked;
                else if (sumChecks[i] == m_loadedBandsMhz.Count)
                        checkBoxes[i].CheckState = CheckState.Checked;
                else
                       checkBoxes[i].CheckState = CheckState.Indeterminate;
           }
            disarm = false;
        }

        private void RunModeSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CheckedListBox[] listBoxes = { checkedListBoxRadio1,
                                             checkedListBoxRadio2,
                                             checkedListBoxRadio3,
                                             checkedListBoxRadio4};
            for (uint i = 1; i <= 4; i++)
            {
                String sName = String.Format("AllowedBandsRadio{0}", i);
                double[] v = null;
                var asChecked = listBoxes[i-1].CheckedIndices;
                if (asChecked != null && asChecked.Count != m_loadedBandsMhz.Count)
                {
                    v = new double[asChecked.Count];
                    int j = 0;
                    foreach (int idx in asChecked)
                        v[j++] = m_loadedBandsMhz[idx];
                }
                m_settings[sName] = v;
            }

            m_settings.Save();
        }


        private bool disarm = true;

        private void checkBoxToCheckListBox(CheckBox cb, CheckedListBox clb)
        {
            if (disarm)
                return;
            if (cb.CheckState == CheckState.Indeterminate)
                cb.CheckState = CheckState.Unchecked;
            else
            {
                disarm = true;
                for (int i = 0; i < clb.Items.Count; i++)
                    clb.SetItemCheckState(i, cb.CheckState);
                disarm = false;
            }
        }

        private void CheckListBoxToCheckBox(CheckedListBox clb, CheckBox cb, ItemCheckEventArgs e)
        {
            if (disarm)
                return;
            disarm = true;
            int sum = 0;
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (i == e.Index)
                {
                    if (e.NewValue == CheckState.Checked)
                        sum += 1;
                }
                else
                if (clb.GetItemChecked(i))
                    sum += 1;
            }
            if (sum == 0)
                    cb.CheckState = CheckState.Unchecked;
            else if (sum == clb.Items.Count)
                    cb.CheckState = CheckState.Checked;
            else
                    cb.CheckState = CheckState.Indeterminate;
            disarm = false;
        }

        private void checkBoxRadio1_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxToCheckListBox(checkBoxRadio1, checkedListBoxRadio1);
        }

        private void checkBoxRadio2_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxToCheckListBox(checkBoxRadio2, checkedListBoxRadio2);
        }

        private void checkBoxRadio3_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxToCheckListBox(checkBoxRadio3, checkedListBoxRadio3);
        }

        private void checkBoxRadio4_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxToCheckListBox(checkBoxRadio4, checkedListBoxRadio4);
        }

        private void checkedListBoxRadio1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckListBoxToCheckBox(checkedListBoxRadio1, checkBoxRadio1, e);
        }

        private void checkedListBoxRadio2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckListBoxToCheckBox(checkedListBoxRadio2, checkBoxRadio2, e);

        }

        private void checkedListBoxRadio3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckListBoxToCheckBox(checkedListBoxRadio3, checkBoxRadio3, e);

        }

        private void checkedListBoxRadio4_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckListBoxToCheckBox(checkedListBoxRadio4, checkBoxRadio4, e);
        }
     }
}
