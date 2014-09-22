AssemblyInfo
============

Queries the AssemblyInfo of a .NET assembly and formats the output according to you.  This is very useful for things like build scripts.

[Download Latest Release](https://github.com/SaggioTechnologies/AssemblyInfo/releases/)

<a href="https://travis-ci.org/SaggioTechnologies/AssemblyInfo"><img src="https://travis-ci.org/SaggioTechnologies/AssemblyInfo.svg" title="Build Status Images"></a>

Usage:

    AssemblyInfo.exe MyAssembly.dll -t "$major-$minor\r\nI like spaghetti"

Outputs:

    1-2
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


### How to use it in a batch file (like a build script)

    for /f "delims=" %%i in ('AssemblyInfo MyAssembly.dll -t $informationalversion') do set VERSION=%%i
    ECHO %VERSION%



