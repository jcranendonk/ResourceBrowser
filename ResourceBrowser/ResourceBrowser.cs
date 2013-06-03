using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Collections;

namespace ResourceBrowser
{
    public partial class ResourceBrowser : Form
    {
        public ResourceBrowser()
        {
            InitializeComponent();
        }

        private void btnLoad_Click( object sender, EventArgs e )
        {
            if( ofdAssembly.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    ShowInfo( Assembly.LoadFile( ofdAssembly.FileName ) );
                }
                catch
                {
                    ShowInfo( null );
                    lblStatus.Text = "Failed to load assembly.";
                }
            }
        }

        private void ShowInfo( Assembly asm )
        {
            tvResources.Nodes.Clear();
            pbValue.Visible = false;
            tbValue.Visible = false;
            btnExport.Enabled = false;

            if( asm != null )
            {
                try
                {
                    lblStatus.Text = "Loaded: " + asm.FullName;

                    foreach( string resourceName in asm.GetManifestResourceNames() )
                    {
                        TreeNode root = new TreeNode( resourceName );
                        root.ImageIndex = 1;
                        root.SelectedImageIndex = 1;
                        tvResources.Nodes.Add( root );

                        using( Stream resourceStream = asm.GetManifestResourceStream( resourceName ) )
                        {
                            try
                            {
                                IDictionaryEnumerator enu = new ResourceSet( resourceStream ).GetEnumerator();

                                while( enu.MoveNext() )
                                {
                                    TreeNode node = new TreeNode( enu.Key.ToString() );
                                    root.Nodes.Add( node );
                                    node.ImageIndex = 0;
                                    node.SelectedImageIndex = 0;

                                    if( enu.Value is Icon || enu.Value is Bitmap )
                                    {
                                        node.Tag = enu.Value;
                                        node.ImageIndex = 2;
                                        node.SelectedImageIndex = 2;
                                    }
                                    else if( enu.Value is String )
                                    {
                                        node.Tag = enu.Value;
                                        node.ImageIndex = 3;
                                        node.SelectedImageIndex = 3;
                                    }
                                    else if( enu.Value is ImageListStreamer )
                                    {
                                        ImageList il = new ImageList();
                                        il.ImageStream = (ImageListStreamer)enu.Value;
                                        node.ImageIndex = 1;
                                        node.SelectedImageIndex = 1;

                                        for( int i = 0; i < il.Images.Count; i++ )
                                        {
                                            TreeNode imgNode = new TreeNode( i.ToString() );
                                            imgNode.Tag = il.Images[i];
                                            imgNode.ImageIndex = 2;
                                            imgNode.SelectedImageIndex = 2;

                                            node.Nodes.Add( imgNode );
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                try
                                {
                                    //------------------------------------------------------
                                    //  Try treating stream as a single image.
                                    //------------------------------------------------------
                                    root.Tag = new Bitmap( resourceStream );
                                    root.ImageIndex = 2;
                                    root.SelectedImageIndex = 2;
                                }
                                catch
                                {
                                    try
                                    {
                                        //------------------------------------------------------
                                        //  Try treating stream as plain text.
                                        //------------------------------------------------------
                                        using( TextReader tr = new StreamReader( resourceStream ) )
                                        {
                                            root.Tag = tr.ReadToEnd();
                                            root.ImageIndex = 0;
                                            root.SelectedImageIndex = 0;
                                        }
                                    }
                                    catch
                                    {
                                        lblStatus.Text = "Error reading resource file.";
                                    }
                                }
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    //------------------------------------------------------
                    //  Exception likely thrown by GetManifestResourceNames().
                    //------------------------------------------------------
                    lblStatus.Text = ex.Message;
                }
            }
            else
            {
                lblStatus.Text = "No assembly loaded.";
            }
        }

        private void tvResources_AfterSelect( object sender, TreeViewEventArgs e )
        {
            ShowOneObject( e.Node.Tag, e.Node.Text );
        }

        private void ShowOneObject( object obj, string name )
        {
            sfdAssembly.FileName = "";

            try
            {
                if( obj != null )
                {
                    if( obj is Icon )
                    {
                        tbValue.Visible = false;
                        pbValue.Visible = true;
                        cbFitImage.Enabled = true;
                        btnExport.Enabled = true;

                        pbValue.Image = ( (Icon)obj ).ToBitmap();
                        sfdAssembly.Filter = "Icon files|*.ico";
                        sfdAssembly.FileName = name + ".ico";
                    }
                    else if( obj is String )
                    {
                        tbValue.Visible = true;
                        pbValue.Visible = false;
                        btnExport.Enabled = true;

                        tbValue.Text = obj.ToString();
                        sfdAssembly.Filter = "Text files|*.txt";
                        sfdAssembly.FileName = name + ".txt";
                    }
                    else if( obj is Image || obj is Bitmap )
                    {
                        tbValue.Visible = false;
                        pbValue.Visible = true;
                        cbFitImage.Enabled = true;
                        btnExport.Enabled = true;

                        pbValue.Image = (Image)obj;
                        sfdAssembly.Filter = "PNG files|*.png|Bitmap files|*.bmp";
                        sfdAssembly.FileName = name + ".png";
                    }
                }
                else
                {
                    tbValue.Visible = false;
                    pbValue.Visible = false;
                    cbFitImage.Enabled = false;
                    btnExport.Enabled = false;
                }
            }
            catch( Exception ex )
            {
                tbValue.Visible = true;
                pbValue.Visible = false;
                btnExport.Enabled = false;

                tbValue.Text = ex.Message;
            }
        }

        private void btnExport_Click( object sender, EventArgs e )
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            sfdAssembly.FileName = new string( sfdAssembly.FileName.ToCharArray().Where( c => invalidChars.Contains( c ) == false ).ToArray() );

            if( sfdAssembly.ShowDialog() == DialogResult.OK )
            {
                if( pbValue.Visible == true )
                {
                    pbValue.Image.Save( sfdAssembly.FileName );
                }
                else if( tbValue.Visible == true )
                {
                    using( StreamWriter sw = new StreamWriter( sfdAssembly.FileName ) )
                    {
                        sw.WriteLine( tbValue.Text );
                    }
                }
            }
        }

        private void ResourceBrowser_DragDrop( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                string[] files = (string[])e.Data.GetData( DataFormats.FileDrop );

                try
                {
                    ShowInfo( Assembly.LoadFrom( files[0] ) );
                }
                catch
                {
                    ShowInfo( null );
                }
            }
        }

        private void ResourceBrowser_DragEnter( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void cbFitImage_CheckedChanged( object sender, EventArgs e )
        {
            switch( cbFitImage.CheckState )
            {
                case CheckState.Checked:
                    pbValue.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case CheckState.Indeterminate:
                case CheckState.Unchecked:
                default:
                    pbValue.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            }
        }
    }
}