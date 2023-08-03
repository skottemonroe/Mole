# Mole
Burrow into a fFilesystem and get a listing of fFiletypes and sizes.


# Example Usage
> mole.exe "C:\Workspace\zoo\sloth\sloth\sloth"

# Example output

I ran this tool on one of my other tools, called The Sloth.  Nevermind that, here's what the output of the MOLE looks like:

```
======================================
C:\Workspace\zoo\sloth\sloth\sloth
======================================

  ..\
  |     Contains 9 subfolders.
  |       (no .extension)      2      66.00 B
  |       *.cache              7      19.35 KB  *
  |       *.config             3     567.00 B
  |       *.cs                 7       6.84 KB  *
  |       *.csproj             1       2.14 KB  *
  |       *.exe                4      21.50 KB  *
  |       *.pdb                4      79.87 KB  *
  |       *.txt                2     920.00 B


======================================
C:\Workspace\zoo\sloth\sloth\sloth
======================================

  ..\
  |       *.config             1     189.00 B
  |       *.cs                 1       5.00 KB  *
  |       *.csproj             1       2.14 KB  *
  |
  |  ..\bin
  |  |     Contains 2 subfolders.
  |  |       *.config             2     378.00 B
  |  |       *.exe                2      10.75 KB  *
  |  |       *.pdb                2      39.94 KB  *
  |
  |  ..\obj
  |  |     Contains 4 subfolders.
  |  |       (no .extension)      2      66.00 B
  |  |       *.cache              7      19.35 KB  *
  |  |       *.cs                 5     428.00 B
  |  |       *.exe                2      10.75 KB  *
  |  |       *.pdb                2      39.94 KB  *
  |  |       *.txt                2     920.00 B
  |
  |  ..\Properties
  |  |       *.cs                 1       1.42 KB  *


======================================
C:\Workspace\zoo\sloth\sloth\sloth
======================================

  ..\
  |       *.config             1     189.00 B
  |       *.cs                 1       5.00 KB  *
  |       *.csproj             1       2.14 KB  *
  |
  |  ..\bin
  |  |
  |  |  ..\bin\Debug
  |  |  |       *.config             1     189.00 B
  |  |  |       *.exe                1       5.63 KB  *
  |  |  |       *.pdb                1      19.97 KB  *
  |  |
  |  |  ..\bin\Release
  |  |  |       *.config             1     189.00 B
  |  |  |       *.exe                1       5.12 KB  *
  |  |  |       *.pdb                1      19.97 KB  *
  |
  |  ..\obj
  |  |
  |  |  ..\obj\Debug
  |  |  |     Contains 1 subfolders.
  |  |  |       (no .extension)      1      32.00 B
  |  |  |       *.cache              4      12.34 KB  *
  |  |  |       *.cs                 4     214.00 B
  |  |  |       *.exe                1       5.63 KB  *
  |  |  |       *.pdb                1      19.97 KB  *
  |  |  |       *.txt                1     453.00 B
  |  |
  |  |  ..\obj\Release
  |  |  |     Contains 1 subfolders.
  |  |  |       (no .extension)      1      34.00 B
  |  |  |       *.cache              3       7.01 KB  *
  |  |  |       *.cs                 1     214.00 B
  |  |  |       *.exe                1       5.12 KB  *
  |  |  |       *.pdb                1      19.97 KB  *
  |  |  |       *.txt                1     467.00 B
  |
  |  ..\Properties
  |  |       *.cs                 1       1.42 KB  *


======================================

Press any key to continue ...
```
