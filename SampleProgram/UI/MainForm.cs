using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SampleProgram.UI
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }

        public MainForm( )
        {
            InitializeComponent( );
            Instance = this;
        }

        private void btnThrowException_Click( object sender, EventArgs e )
        {
            throw new IOException( "This is a test exception!" );
        }

        private void fogbugzLogo_Click( object sender, EventArgs e )
        {
            using ( Process proc = new Process( ) )
            {
                proc.StartInfo.FileName = "http://fogbugz.com";
                proc.Start( );
            }
        }

        private void btnThrowFatal_Click( object sender, EventArgs e )
        {
            // "Fatal" exceptions are those that are thrown in threads other than the UI.
            new Thread(() => ThrowEvilException()).Start();
        }

        private void ThrowEvilException( )
        {
            throw new AccessViolationException( "Oh no!" );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            new FeedbackForm( ).ShowDialog( this );
        }
    }
}
