using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace SampleProgram
{
    public class Util
    {
        public static string GetProgramVersion( )
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly( );
            if ( entryAssembly != null )
            {
                AssemblyName entryAssemblyName = entryAssembly.GetName( );
                if ( entryAssemblyName != null && entryAssemblyName.Version != null )
                    return String.Format( "{0}.{1}.{2}", entryAssemblyName.Version.Major, entryAssemblyName.Version.Minor, entryAssemblyName.Version.Build );
            }

            return "Unknown";
        }

        public static DateTime GetProgramBuildDate( )
        {
            return new FileInfo( Assembly.GetExecutingAssembly( ).Location ).LastWriteTime;
        }

        private static int GetOSArchitecture( )
        {
            string pa = Environment.GetEnvironmentVariable( "PROCESSOR_ARCHITECTURE" );
            return ( ( String.IsNullOrEmpty( pa ) || String.Compare( pa, 0, "x86", 0, 3, true ) == 0 ) ? 32 : 64 );
        }

        private static string GetBaseWindowsVersion( )
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            if ( os.Platform == PlatformID.Win32Windows )
            {
                // A pre-NT version of Windows.
                switch ( vs.Minor )
                {
                    case 0:
                        return "95";
                    case 10:
                        if ( vs.Revision.ToString( ) == "2222A" )
                            return "98SE";
                        else
                            return "98";
                    case 90:
                        return "Me";
                }
            }
            else if ( os.Platform == PlatformID.Win32NT )
            {
                switch ( vs.Major )
                {
                    case 3:
                        return "NT 3.51";
                    case 4:
                        return "NT 4.0";
                    case 5:
                        if ( vs.Minor == 0 )
                            return "2000";
                        else
                            return "XP";
                    case 6:
                        if ( vs.Minor == 0 )
                            return "Vista";
                        else
                            return "7";
                }
            }

            return "Unknown";
        }

        /// <summary>
        /// Returns the version of Windows the local computer is running (ex: "Windows XP SP3 32-bit").
        /// Adapted from http://andrewensley.com/2009/06/c-detect-windows-os-part-1/
        /// </summary>
        public static string GetWindowsVersion( )
        {
            // Start with the Windows version.
            string operatingSystem = "Windows " + GetBaseWindowsVersion( );

            // Add the service pack, if any.
            if ( Environment.OSVersion.ServicePack.Length > 0 )
                operatingSystem += " " + Environment.OSVersion.ServicePack;

            // Add the architecture (32-bit/64-bit).
            operatingSystem += " " + GetOSArchitecture( ).ToString( ) + "-bit";

            return operatingSystem.Trim( );
        }
    }
}
