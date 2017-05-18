if exist ConfigureShortcuts.exe (
  ConfigureShortcuts WriteLogKeyProcessor KeyProcessor /install
) else (
  msg * "You need to Extract All to install"
)
