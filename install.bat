if exist ConfigureShortcuts.exe (
ConfigureShortcuts WriteLogKeyProcessor KeyProcessor /install
exit
)
mshta javascript:alert("You need to Extract All to install");close();