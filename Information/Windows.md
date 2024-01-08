# Windows
These are notes on Windows

## General Info

https://renenyffenegger.ch/notes/Windows/

Start Menu Locations
```
C:\ProgramData\Microsoft\Windows\Start Menu\Programs\
C:\Users\craig\AppData\Roaming\Microsoft\Windows\Start Menu\
```

## Investigate

Investigate These Paths as Windows seems to leave entries from uninstalled programs here
```
HKEY_USERS\S-1-5-21-4135085899-3670623898-1780540100-1001\Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache
HKEY_USERS\S-1-5-21-4135085899-3670623898-1780540100-1001\Control Panel\NotifyIconSettings
```

## Miscellaneous

When putting `Applications` in to Explorer, it will show the `Applications` folder.<br>
I need to figure out how to modify the files in this folder.<br>
As I believe this is where the `Start Menu` is stored when you click `All Apps`<br>
Sometimes Windows will leave entries in the `Start Menu` even after uninstalling the program.<br>

---
[Back to Readme](https://github.com/CraigCraig/CheetahToolbox/blob/main/README.md)
