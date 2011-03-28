using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using SampleProgram.UI;
using System.IO;

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
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            // Set up error reporting.
            Application.SetUnhandledExceptionMode( UnhandledExceptionMode.CatchException );
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );
            Application.ThreadException += new ThreadExceptionEventHandler( Application_ThreadException );

            Application.Run( new MainForm( ) );
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
