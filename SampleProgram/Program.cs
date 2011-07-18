using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using SampleProgram.UI;
using System.IO;
using System.Reflection;

namespace SampleProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            try
            {
                Application.EnableVisualStyles( );
                Application.SetCompatibleTextRenderingDefault( false );

                // Set up error reporting.
                Application.SetUnhandledExceptionMode( UnhandledExceptionMode.CatchException );
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler( CurrentDomain_AssemblyResolve );
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );
                Application.ThreadException += new ThreadExceptionEventHandler( Application_ThreadException );

                Application.Run( new MainForm( ) );
            }
            catch ( Exception ex ) // Exceptions in Main() aren't caught by either Application_ThreadException or CurrentDomain_UnhandledException.
            {
                ErrorHandler.HandleUncaughtException( ex, true );               
            }
        }

        /// <summary>
        /// Occurs when the application references an assembly that's missing (IE, the user copied only the EXE file).
        /// </summary>
        static Assembly CurrentDomain_AssemblyResolve( object sender, ResolveEventArgs args )
        {
            if ( args.Name.StartsWith( "BugzScout" ) )
            {
                MessageBox.Show( "There was an error loading some of this program's components.\nPlease download a new version.", "SampleApp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                Environment.Exit( -2 );
            }
            
            return null;
        }

        static void Application_ThreadException( object sender, ThreadExceptionEventArgs e )
        {
            ErrorHandler.HandleUncaughtException( e.Exception, false );
        }

        static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            ErrorHandler.HandleUncaughtException( (Exception) e.ExceptionObject, true );
        }
    }
}
