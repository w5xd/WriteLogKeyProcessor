using System;
using System.Collections.Generic;
using System.Text;

/*
 * WriteLog run mode processor
 * 
 * This assembly plugs in to WriteLog's external keyboard interface  
 */

namespace WriteLogKeyProcessor
{
    //class RunModeProcessor is the connection from WriteLog 
    public class KeyProcessor :
#if IMPLEMENT_ENTRYSTATE
        // This demo doesn't need the interfaces from EntryStateHelper
        WriteLogShortcutHelper.EntryStateHelper /* shortcut helper is distributed with WriteLog */
#else
        WriteLogShortcutHelper.ShortcutHelper /* ditto */
#endif
    {
        /* These are the names of the commands as they will appear
           in WriteLog's Keyboard Shortcuts "Command to run" list: */
        string[] CommandNames = new string[] { 
                "Setup", // this is which == 0
                  
                // ... and you can add as many as you like.
                // They will appear in WriteLog with "External:" prepended.
                // Look in the E's in that menu.
                "VhfBandUp", 
                "VhfBandDown",
                "VhfBandUpRetainCall",
                "VhfBandDownRetainCall",
         };

        private BandsInContest m_bands;

        void ChangeBand(WriteLogClrTypes.IWriteL wl, string Command)
        {
            if (m_bands == null)
                m_bands = new BandsInContest(wl);
            WriteLogClrTypes.ISingleEntry wle =
                wl.GetCurrentEntry() as WriteLogClrTypes.ISingleEntry;
            short curId = wle.GetEntryId();
            // 1 through 4
            if ((curId >= 1) && (curId <= 4))
            {
                String sName = String.Format("AllowedBandsRadio{0}", curId);
                int maxCycles = m_bands.BandIdxToBand.Count + 1;
                do
                {
                    // invoke the "Normal" Band up or down
                    wl.InvokeKeyboardCommand(Command);
                    // and repeat until it cycles to where we want.
                }
                while (
                    !m_bands.IsAllowed(wle.GetBand(), (double[])m_Settings[sName]) 
                    && maxCycles-- > 0 // handle case where built-in fails to move an out-of-band freq.
                    );
            }
        }

        // add "case" in the "switch" below
        public override void InvokeShortcut(
            int which, // corresponds to values in CommandNames
            WriteLogClrTypes.IWriteL wl // the root of the WriteLog object hierarchy
            )
        {
             // you can call methods on the wl object here. 
            switch (which)
            {
                case 0: // "setup"
                     using (KeyProcessorSettingsForm f = 
                         new KeyProcessorSettingsForm(m_Settings, m_bands = new BandsInContest(wl)))
                            f.ShowDialog();
                    break;

                case 1: // "VhfBandUp"
                    ChangeBand(wl, "BandsBandUp");
                    break;

                case 2: // "VhfBandDown"
                    ChangeBand(wl, "BandsBandDown");
                    break;

                case 3: // "VhfBandUpRetainCall"
                    ChangeBand(wl, "BandsBandUpRetainCall");
                    break;

                case 4: // "VhfBandDownRetainCall"
                    ChangeBand(wl, "BandsBandDownRetainCall");
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }
        }

        // you must have this property. The code here should be OK without change.
        public override int ShortcutCount
        { get { return CommandNames.Length; } }


        // and you must have this one. The code here should be OK without change.
        public override string this[int which]
        {
            get
            {
                if ((which < 0) || (which >= CommandNames.Length))
                    throw new IndexOutOfRangeException();
                return CommandNames[which];
            }
        }

        #region object state
        private KeyProcessorSettings m_Settings = new KeyProcessorSettings();
        #endregion

        #region IEntryNotification Members

#if IMPLEMENT_ENTRYSTATE 
        
        // Called when WriteLog finishes sending an f-key message on the given Entry Window
        public override void OnProgramMessageCompleted(WriteLogClrTypes.ISingleEntry rEntry, WriteLogClrTypes.IWriteL rWl)
        {        }

        // The timed-CQ interval has elapsed since the end of any f-key transmission
        public override void OnListenIntervalComplete(WriteLogClrTypes.ISingleEntry rEntry, WriteLogClrTypes.IWriteL rWl)
        {        }

       // a program F-key message is starting
       public override void OnStartMessage(WriteLogClrTypes.ISingleEntry rEntry, 
            WriteLogClrTypes.IWriteL rWl, 
           int msg,  // which message 1 is F1, 2 is F2, etc.
           int stillActive // non-zero means the "red box" is on--operator has caret in CALL field
           )
        {        }

        // If we return non-zero, WriteLog won't send this message, and forgets the operator typed the f-key
        // presumeably, this shortcut processor will do something less mysterious,
        // like maybe remember that key press and send it later.
        public override short DelayStartMessage(WriteLogClrTypes.ISingleEntry rEntry, WriteLogClrTypes.IWriteL rWl, int msg)
        {
             return 0;
        }

        // the red box in WriteLog went away. (message transmission still in progress, but the CALL sent can no longer be changed)
        // This can be because the operator moved the caret out of CALL, or because the CALL is now being sent.
        public override void OnMessageCALLComplete(WriteLogClrTypes.ISingleEntry rEntry, WriteLogClrTypes.IWriteL rWl)
        {         }

        // The operator logged a QSO (but no call here if operator held down CTRL or SHIFT)
        public override void OnLoggedQso(WriteLogClrTypes.ISingleEntry rEntry, WriteLogClrTypes.IWriteL rWl)
        {        }

        // every operator keystroke sent to the Entry Window characters calls us here. 
        public override void OnEntryWindowUpdated(WriteLogClrTypes.ISingleEntry rentry, 
            short isblank, // this is non-zero if there are no operator-entered characters in the Entry Window
            WriteLogClrTypes.IWriteL wl)
        {        }
#endif
        #endregion

    }
}
