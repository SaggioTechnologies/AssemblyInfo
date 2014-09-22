AssemblyInfo
============

Queries the AssemblyInfo of a .NET assembly and formats the output according to you

Usage:

    AssemblyInfo.exe MyAssembly.dll -t "$major-$minor\r\nI like spaghetti"

Outputs:

    1.2
    I like spaghetti

###Token List
- $major - Major version number
- $minor - Minor version number
- $revision - Revision version number
- $build - Build version number
- $productversion - The full production version
- $informationalversion - The informational version (e.g. 2.3 Hotfix1 or 3.4-rc1)
- $fullname - (MyAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=de53a01bd32ea25b)

Example:

    AssemblyInfo.exe MyAssembly.dll -t "$fullname"
    
Outputs:

    MyAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=de53a01bd32ea25b

Example:    
    
    AssemblyInfo.exe MyAssembly.dll -t "$informationalversion"
    
Outputs:

    3.5-rc1
    
(works if the assembly has the AssembyInformationalVersion attribute set)

