using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SampleProgram.UI
{
    public partial class ErrorForm : Form
    {
        private Exception Exception;

        private const string DefaultReportText = "What were you doing when the error occured?";

        private bool ErrorIsFatal;

        public ErrorForm( Exception e, bool fatal )
        {
            InitializeComponent( );
            this.Exception = e;

            // Style the form differently for fatal errors.
            this.ErrorIsFatal = fatal;
            if ( ErrorIsFatal )
            {
                 pbIcon.Image = global::SampleProgram.Properties.Resources.exclamation;
                lblTitle.Text = "We're sorry...";
                lblDescription.Text = "SampleApp has encountered a fatal error and must restart.";
                btnRestart.Text = "Restart";
            }

            lblExceptionDescription.Text = e.Message;
            Size = MinimumSize;
            UpdateState( );
            BringToFront( );
        }

        private void UpdateState( )
        {
            lblTopDivide.Width = lblBottomDivide.Width = Width;
            lblExceptionDescription.Width = Width - lblExceptionDescription.Left - btnExit.Width - btnRestart.Width - 40;

            if ( ErrorIsFatal )             
                    MainForm.Instance.Hide( );
        }       

        private void btnRestart_Click( object sender, EventArgs e )
        {
            if ( ErrorIsFatal )
            {
                ErrorHandler.RestartApplication( );
                Environment.Exit( 0 );
            }
            Close( );
        }

        private void btnExit_Click( object sender, EventArgs e )
        {
            Environment.Exit( -1 );
        }

        private void ErrorForm_Resize( object sender, EventArgs e )
        {
            UpdateState( );
        }
    }
}
