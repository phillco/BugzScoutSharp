namespace SampleProgram.UI
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ErrorForm ) );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.lblBottomDivide = new System.Windows.Forms.Label( );
            this.lblExceptionDescription = new System.Windows.Forms.Label( );
            this.btnExit = new System.Windows.Forms.Button( );
            this.btnRestart = new System.Windows.Forms.Button( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.lblDescription = new System.Windows.Forms.Label( );
            this.lblTopDivide = new System.Windows.Forms.Label( );
            this.pbIcon = new System.Windows.Forms.PictureBox( );
            this.panel2.SuspendLayout( );
            this.panel1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbIcon ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point( 49, 10 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 132, 16 );
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Just so you know...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.lblBottomDivide );
            this.panel2.Controls.Add( this.lblExceptionDescription );
            this.panel2.Controls.Add( this.btnExit );
            this.panel2.Controls.Add( this.btnRestart );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0, 105 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 437, 47 );
            this.panel2.TabIndex = 10;
            // 
            // lblBottomDivide
            // 
            this.lblBottomDivide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBottomDivide.Location = new System.Drawing.Point( -2, 0 );
            this.lblBottomDivide.Name = "lblBottomDivide";
            this.lblBottomDivide.Size = new System.Drawing.Size( 500, 2 );
            this.lblBottomDivide.TabIndex = 14;
            this.lblBottomDivide.Text = " ";
            // 
            // lblExceptionDescription
            // 
            this.lblExceptionDescription.AutoEllipsis = true;
            this.lblExceptionDescription.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblExceptionDescription.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblExceptionDescription.Location = new System.Drawing.Point( 8, 17 );
            this.lblExceptionDescription.Name = "lblExceptionDescription";
            this.lblExceptionDescription.Size = new System.Drawing.Size( 224, 13 );
            this.lblExceptionDescription.TabIndex = 6;
            this.lblExceptionDescription.Text = "Exception";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point( 350, 10 );
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size( 75, 25 );
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler( this.btnExit_Click );
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnRestart.Location = new System.Drawing.Point( 271, 10 );
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size( 75, 25 );
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Continue";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler( this.btnRestart_Click );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.pbIcon );
            this.panel1.Controls.Add( this.lblDescription );
            this.panel1.Controls.Add( this.lblTitle );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 437, 56 );
            this.panel1.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point( 49, 30 );
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size( 248, 13 );
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "SampleApp had a slight hickup, but should be fine.";
            // 
            // lblTopDivide
            // 
            this.lblTopDivide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTopDivide.Location = new System.Drawing.Point( -2, 54 );
            this.lblTopDivide.Name = "lblTopDivide";
            this.lblTopDivide.Size = new System.Drawing.Size( 500, 2 );
            this.lblTopDivide.TabIndex = 13;
            this.lblTopDivide.Text = " ";
            // 
            // pbIcon
            // 
            this.pbIcon.Image = global::SampleProgram.Properties.Resources.brick_delete;
            this.pbIcon.Location = new System.Drawing.Point( 11, 12 );
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size( 32, 32 );
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbIcon.TabIndex = 2;
            this.pbIcon.TabStop = false;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 437, 152 );
            this.Controls.Add( this.lblTopDivide );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.panel2 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 430, 190 );
            this.Name = "ErrorForm";
            this.Text = "SampleApp Error";
            this.Resize += new System.EventHandler( this.ErrorForm_Resize );
            this.panel2.ResumeLayout( false );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbIcon ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblExceptionDescription;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblBottomDivide;
        private System.Windows.Forms.Label lblTopDivide;
    }
}