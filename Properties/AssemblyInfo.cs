using ChecksumBypass;
using MelonLoader;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(ModBuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(ModBuildInfo.Company)]
[assembly: AssemblyProduct(ModBuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + ModBuildInfo.Author)]
[assembly: AssemblyTrademark(ModBuildInfo.Company)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9d02aa87-5222-4c13-9b79-daed77acf4c4")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(ModBuildInfo.Version)]
[assembly: AssemblyFileVersion(ModBuildInfo.Version)]
[assembly: MelonInfo(typeof(ChecksumBypass.Main), ModBuildInfo.Name, ModBuildInfo.Version, ModBuildInfo.Author, ModBuildInfo.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.Magenta)]
// Removed so it can also be loaded in the chinese version
// [assembly: MelonGame(ModBuildInfo.GameDeveloper, ModBuildInfo.Game)]