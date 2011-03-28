using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Resources;

namespace FogCreek
{
    /// <summary>
    /// Some utility functions by the bug reporter.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Returns a list of all loaded assemblies.
        /// </summary>
        public static string GetAssemblyList( )
        {
            StringBuilder assemblies = new StringBuilder( );
            assemblies.Append( new ResourceManager( typeof( BugReport ) ).GetString( "Assemblies" ) + Environment.NewLine );
            foreach ( Assembly asm in AppDomain.CurrentDomain.GetAssemblies( ) )
                assemblies.AppendFormat( "   {0}, {1}" + Environment.NewLine, asm.GetName( ).Name, asm.GetName( ).Version.ToString( ) );
            return assemblies.ToString( );
        }

        /// <summary>
        /// Given an exception, returns where in the code that exception occurred (eg "(BugReport.cs:67) Submit()").
        /// </summary>
        public static string GetExceptionLineNumber( Exception e )
        {
            Regex reSourceReference = new Regex( "at\\s+.+\\.(?<methodname>[^)]+)\\(.*\\)\\s+in\\s+.+\\\\(?<filename>[^:\\\\]+):line\\s+(?<linenumber>[0-9]+)", RegexOptions.IgnoreCase );
            if ( e.StackTrace != null )
            {
                foreach ( string line in e.StackTrace.Split( '\n', '\r' ) )
                {
                    Match ma = reSourceReference.Match( line );
                    if ( ma.Success )
                        return String.Format( "({0}:{1}) {2}()", ma.Groups["filename"].Value, ma.Groups["linenumber"].Value, ma.Groups["methodname"].Value);
                }
            }

            // If we didn't get a source reference (perhaps this is a release compile?), try to find a non-System.* reference 
            Regex reMethodReference = new Regex( "at\\s+(?<methodname>[^(]+)\\(.*\\)", RegexOptions.IgnoreCase );
            if ( e.StackTrace != null )
            {
                foreach ( string line in e.StackTrace.Split( '\n', '\r' ) )
                {
                    Match ma = reMethodReference.Match( line );
                    if ( ma.Success )
                    {
                        if ( !ma.Groups["methodname"].Value.ToUpper( ).StartsWith( "SYSTEM." ) )
                            return String.Format( "({0})", ma.Groups["methodname"].Value );
                    }
                }
            }

            return "(Unknown)";
        }
    }
}
