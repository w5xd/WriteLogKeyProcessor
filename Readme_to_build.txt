WriteLog will load a .NET assembly and plug it in to its keyboard processing.
Once installed, WriteLog's Setup/Keyboard-shortcuts will show new entries
labeld "External: <name>" based on what it finds in the assembly.

Separate from the shortcuts, WriteLog will also call the IEntryNotification 
interface on the module. Each method is called at a defined step in 
WriteLog's keyboard processing. However, the functionality in this demo doesn't need 
an implementation of IEntryNotification so the necessary source is excluded via
the project Properties compile-time symbol IMPLEMENT_ENTRYSTATE.

To build this from source, it should work with Visual Studio Express 2010 as-is
...with one exception...
The References to the three WriteLog assemblies will need to be manually added.

To get started:
Run Visual C# 2010 Express
File Open Project WriteLogRunKeyProcessor.csproj
View Solution Explorer
Under WriteLogKeyProcessor in the Solution Explorer, right click References and then Add Reference...
In the "Add Reference" dialog, switch to the Browse tab.
In Look In control, browse to WriteLog's Programs installation directory.
Click the Name column to sort by Name
Scroll to and CTRL+left-mouse click these three:
	WriteLogClrTypes.dll
	WriteLogExternalShortcuts.dll
	WriteLogSHortcutHelper.dll

Click OK and the project should build

