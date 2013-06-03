namespace ResourceBrowser
{
    partial class ResourceBrowser
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
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ResourceBrowser ) );
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvResources = new System.Windows.Forms.TreeView();
            this.ilResources = new System.Windows.Forms.ImageList( this.components );
            this.tbValue = new System.Windows.Forms.TextBox();
            this.pbValue = new System.Windows.Forms.PictureBox();
            this.ofdAssembly = new System.Windows.Forms.OpenFileDialog();
            this.sfdAssembly = new System.Windows.Forms.SaveFileDialog();
            this.cbFitImage = new System.Windows.Forms.CheckBox();
            ( (System.ComponentModel.ISupportInitialize)( this.splitContainer1 ) ).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.pbValue ) ).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point( 12, 12 );
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size( 75, 23 );
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load file";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler( this.btnLoad_Click );
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point( 12, 452 );
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size( 75, 23 );
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Save value";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler( this.btnExport_Click );
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point( 93, 17 );
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size( 0, 13 );
            this.lblStatus.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point( 12, 41 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.tvResources );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.tbValue );
            this.splitContainer1.Panel2.Controls.Add( this.pbValue );
            this.splitContainer1.Size = new System.Drawing.Size( 709, 405 );
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 3;
            // 
            // tvResources
            // 
            this.tvResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResources.ImageIndex = 0;
            this.tvResources.ImageList = this.ilResources;
            this.tvResources.Location = new System.Drawing.Point( 0, 0 );
            this.tvResources.Name = "tvResources";
            this.tvResources.SelectedImageIndex = 0;
            this.tvResources.Size = new System.Drawing.Size( 264, 405 );
            this.tvResources.TabIndex = 0;
            this.tvResources.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvResources_AfterSelect );
            // 
            // ilResources
            // 
            this.ilResources.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ilResources.ImageStream" ) ) );
            this.ilResources.TransparentColor = System.Drawing.Color.Transparent;
            this.ilResources.Images.SetKeyName( 0, "empty.png" );
            this.ilResources.Images.SetKeyName( 1, "folder.png" );
            this.ilResources.Images.SetKeyName( 2, "image.png" );
            this.ilResources.Images.SetKeyName( 3, "text.png" );
            // 
            // tbValue
            // 
            this.tbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValue.Location = new System.Drawing.Point( 0, 0 );
            this.tbValue.Multiline = true;
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new System.Drawing.Size( 441, 405 );
            this.tbValue.TabIndex = 1;
            this.tbValue.Visible = false;
            // 
            // pbValue
            // 
            this.pbValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbValue.Location = new System.Drawing.Point( 0, 0 );
            this.pbValue.Name = "pbValue";
            this.pbValue.Size = new System.Drawing.Size( 441, 405 );
            this.pbValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbValue.TabIndex = 0;
            this.pbValue.TabStop = false;
            this.pbValue.Visible = false;
            // 
            // ofdAssembly
            // 
            this.ofdAssembly.DefaultExt = "dll";
            this.ofdAssembly.Filter = "Assembly files|*.dll;*.exe";
            // 
            // sfdAssembly
            // 
            this.sfdAssembly.Filter = "All files|*.*";
            this.sfdAssembly.FilterIndex = 0;
            this.sfdAssembly.SupportMultiDottedExtensions = true;
            // 
            // cbFitImage
            // 
            this.cbFitImage.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.cbFitImage.AutoSize = true;
            this.cbFitImage.Enabled = false;
            this.cbFitImage.Location = new System.Drawing.Point( 653, 16 );
            this.cbFitImage.Name = "cbFitImage";
            this.cbFitImage.Size = new System.Drawing.Size( 68, 17 );
            this.cbFitImage.TabIndex = 4;
            this.cbFitImage.Text = "Fit image";
            this.cbFitImage.UseVisualStyleBackColor = true;
            this.cbFitImage.CheckedChanged += new System.EventHandler( this.cbFitImage_CheckedChanged );
            // 
            // ResourceBrowser
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 733, 487 );
            this.Controls.Add( this.cbFitImage );
            this.Controls.Add( this.splitContainer1 );
            this.Controls.Add( this.lblStatus );
            this.Controls.Add( this.btnExport );
            this.Controls.Add( this.btnLoad );
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.Name = "ResourceBrowser";
            this.Text = "Resource Browser";
            this.DragDrop += new System.Windows.Forms.DragEventHandler( this.ResourceBrowser_DragDrop );
            this.DragEnter += new System.Windows.Forms.DragEventHandler( this.ResourceBrowser_DragEnter );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.Panel2.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.splitContainer1 ) ).EndInit();
            this.splitContainer1.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)( this.pbValue ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvResources;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.PictureBox pbValue;
        private System.Windows.Forms.OpenFileDialog ofdAssembly;
        private System.Windows.Forms.SaveFileDialog sfdAssembly;
        private System.Windows.Forms.ImageList ilResources;
        private System.Windows.Forms.CheckBox cbFitImage;
    }
}

