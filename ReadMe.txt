This is a simple keyboard processor for WriteLog. It is written to the published WriteLog
interfaces for a plugin and "simple" with the exception that it implements a couple of
keyboard shortcuts that will limit WriteLog's Entry Window to a selected subset of the
bands in the contest.

To Install:
In Windows File Manager, right click the downloaded file WriteLogKeyProcessorVn.m.zip 
(where n and m are the major and minor version numbers of the download.)
Choose Exctract All.
Double click install.bat. If it needs an admin password, it will ask for one.

The result just puts a dll file in WriteLog's Programs directory 
and sets a couple of registry entries.

The next time you run WriteLog, take a look at the menu entry Setup/Keyboard-Shortcuts.
Under "CommandToRun" there are now three new commands due to this installation:

External: Setup
External: VhfBandDown
External: VhfBandUp

You will want to use that dialog to map the 3 above shortcuts to one or another keyboard
key. Recommendations:
	External: Setup should go to a not-often-used key.
	External: VhfBandDown should go to Alt+F01
	External: VhfBandUp should go to Alt+F02

Try the key mapped to Setup first. It allows you to exclude bands from the given
radio. OK the Setup dialog.

Now Alt+F01 and Alt+F02 go only to the bands you checked in Setup.