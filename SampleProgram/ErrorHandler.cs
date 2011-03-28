using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using FogCreek;
using SampleProgram.UI;

namespace SampleProgram
{
    /// <summary>
    /// Handles any uncaught exceptions the program generates.
    /// </summary>
    class ErrorHandler
    {
        public const string DEFAULT_BUGZSCOUT_MESSAGE = "Thanks - the report was sent successfully.";

        public static void HandleUncaughtException( Exception e, bool fatal )
        {            
            // Create an error report.            
            BugReport report = new BugReport
            {
                FogBugzUrl = "https://philltest.fogbugz.com/ScoutSubmit.asp",
                UserName = "Exception Reporter",
                Project = "BugzScoutSharp",
                Area = "Reports",
                DefaultMessage = DEFAULT_BUGZSCOUT_MESSAGE,
            };
            report.AddMachineDetails( "Opened by" );
            report.AddExceptionDetails( e );
            report.Description += "Fatal: " + ( fatal ? "Yes" : "No" ) + Environment.NewLine;
            report.Description += "Version: " + Util.GetProgramVersion( ) + " (built on " + Util.GetProgramBuildDate( ).ToShortDateString( ) + ")" + Environment.NewLine;
            report.Description += "OS: " + Util.GetWindowsVersion( ) + Environment.NewLine;

            // Show the error form with the report.
            ErrorForm form = new ErrorForm( e, report, fatal );
            form.ShowDialog( );
        }

        public static void RestartApplication( )
        {
            using ( Process proc = new Process( ) )
            {
                proc.StartInfo.FileName = Application.ExecutablePath;
                proc.Start( );
            }
        }
    }
}
