namespace SampleProgram.UI
{
    partial class FeedbackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FeedbackForm ) );
            this.tbFeedback = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.btnSend = new System.Windows.Forms.Button( );
            this.sendFeedbackWorker = new System.ComponentModel.BackgroundWorker( );
            this.pbSending = new System.Windows.Forms.ProgressBar( );
            this.SuspendLayout( );
            // 
            // tbFeedback
            // 
            this.tbFeedback.Location = new System.Drawing.Point( 28, 38 );
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size( 371, 107 );
            this.tbFeedback.TabIndex = 0;
            this.tbFeedback.TextChanged += new System.EventHandler( this.tbFeedback_TextChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point( 12, 14 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 182, 16 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your feedback below";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 359, 156 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 25 );
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point( 280, 156 );
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size( 75, 25 );
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler( this.btnSend_Click );
            // 
            // sendFeedbackWorker
            // 
            this.sendFeedbackWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.sendFeedbackWorker_DoWork );
            this.sendFeedbackWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.sendFeedbackWorker_RunWorkerCompleted );
            // 
            // pbSending
            // 
            this.pbSending.Location = new System.Drawing.Point( 146, 156 );
            this.pbSending.MarqueeAnimationSpeed = 25;
            this.pbSending.Name = "pbSending";
            this.pbSending.Size = new System.Drawing.Size( 128, 25 );
            this.pbSending.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbSending.TabIndex = 8;
            this.pbSending.Value = 30;
            this.pbSending.Visible = false;
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 445, 195 );
            this.Controls.Add( this.pbSending );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSend );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.tbFeedback );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "FeedbackForm";
            this.Text = "Send feedback";
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.ComponentModel.BackgroundWorker sendFeedbackWorker;
        private System.Windows.Forms.ProgressBar pbSending;
    }
}