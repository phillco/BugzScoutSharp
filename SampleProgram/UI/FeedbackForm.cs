using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FogBugz;

namespace SampleProgram.UI
{
    /// <summary>
    /// Lets the user submit simple text feedback to FogBugz.
    /// </summary>
    public partial class FeedbackForm : Form
    {
        public FeedbackForm( )
        {
            InitializeComponent( );
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void tbFeedback_TextChanged( object sender, EventArgs e )
        {
            btnSend.Enabled = tbFeedback.Text.Length > 0;
        }

        private void btnSend_Click( object sender, EventArgs e )
        {
            btnSend.Enabled = false;
            imgLoadingIndicator.Visible = true;
            sendFeedbackWorker.RunWorkerAsync( );
        }

        private void sendFeedbackWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            BugReport report = new BugReport
            {
                FogBugzUrl = "https://philltest.fogbugz.com/ScoutSubmit.asp",
                UserName = "Exception Reporter",
                Title = "User feedback",
                Project = "BugzScoutSharp",
                Area = "Feedback",
                DefaultMessage = ErrorHandler.DEFAULT_BUGZSCOUT_MESSAGE,
            };
            report.AddMachineDetails( "Feedback sent by" );
            report.Description += Environment.NewLine + tbFeedback.Text;
            e.Result = report.Submit( );
        }

        private void sendFeedbackWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            BugReport.Result result = (BugReport.Result) e.Result;
            
            if ( result.Succeeded )
                MessageBox.Show( "Thanks - your feedback was received successfully!", "Send Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information );
            else
                MessageBox.Show( "Sorry - we were unable to send your feedback.", "Send Feedback", MessageBoxButtons.OK, MessageBoxIcon.Warning );

            Close( );
        }
    }
}
