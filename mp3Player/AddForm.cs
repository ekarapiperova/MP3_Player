using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp3Player
{
    public partial class AddForm : Form
    {
        OpenFileDialog openFileDialogPlayer = new OpenFileDialog();


       // int p = MainForm._Form1.k;

        public AddForm()
        {
            InitializeComponent();
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            openFileDialogPlayer.FileName = String.Empty;
            openFileDialogPlayer.Filter = "MP3 File (*.mp3*)|*.mp3*";
            openFileDialogPlayer.FilterIndex = 2;
            openFileDialogPlayer.RestoreDirectory = true;
            if (openFileDialogPlayer.ShowDialog() == DialogResult.OK)

                try
                {
                    if(MainForm._Form1.lbplayList.Items.Contains(openFileDialogPlayer.FileName)==false)
                    {
                        MainForm._Form1.axWindowsMediaPlayer1.URL = openFileDialogPlayer.FileName;
                    MainForm._Form1.axWindowsMediaPlayer1.Ctlcontrols.play();

                    MainForm._Form1.lbplayList.Items.Add(openFileDialogPlayer.FileName);
                        MainForm._Form1.allpaths[MainForm._Form1.k] =openFileDialogPlayer.FileName;
                        MainForm._Form1.k++;




                    }
                    else
                    {
                        MessageBox.Show("Duplicate the song!");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка ! Не може да бъде прочетен такъв файл" + ex.Message, "Съобщение за грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            this.Close();
            



        }
        }
    }

