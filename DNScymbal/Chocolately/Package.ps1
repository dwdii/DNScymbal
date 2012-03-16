$Nuspec = "DNScymbal.nuspec";

# Update Nuget and packages
Invoke-Expression -Command "Nuget.exe update -self"



# Build our package
Invoke-Expression -Command "Nuget.exe pack $Nuspec -BasePath download\package\dnscymbal -o download"