using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mp3Player
{
    public partial class MainForm : Form
    {
        OpenFileDialog player;


        string[] files, paths;

       public string[] allpaths=new string[50];

        public  int k = 0;
        public MainForm()
        {
            InitializeComponent();
            _Form1 = this;
        }
        public static MainForm _Form1;
        public void AddItem(string value)
        {
            lbplayList.Items.Add(value);

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.FileName = String.Empty;
            player.InitialDirectory = "C:\\";
            player.Filter = "MP3|*.mp3";

            player.RestoreDirectory = true;
            if (player.ShowDialog() == DialogResult.OK)
            {
                if (lbplayList.Items.Contains(player.FileName) == false)
                {
                    
                    axWindowsMediaPlayer1.URL = player.FileName;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    lbplayList.Items.Add(player.FileName);
                    
                    allpaths[k] = player.FileName;
                    k++;
                }
                else
                {
                    MessageBox.Show("Duplicate the song!!");
                }

                    

            }
        }
    


        private void lbplayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.URL = lbplayList.SelectedItem.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Няма избрана песен");
            }
        }
            
            

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            player.Multiselect = true;
            player.Title = "Create Playlist";
            player.Filter = "MP3|*.mp3";
            if (player.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    
                    files = player.SafeFileNames;
                    paths = player.FileNames;
                    for (int i = 0; i <paths.Length; i++)
                    {
                        if (lbplayList.Items.Contains(paths[i].ToString())==false)
                        {
                            lbplayList.Items.Add(paths[i]);
                            allpaths[k] = paths[i];
                            k++;
                        }
                       else MessageBox.Show("Duplicate the song!!");
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Не е избран файл");
                }
            }

        }

        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
                StreamWriter Write;
                SaveFileDialog savePlaylist = new SaveFileDialog();
                savePlaylist.RestoreDirectory = false;
                try
                {

                    savePlaylist.Filter = ("Text|*.txt");
                    savePlaylist.ShowDialog();
                    Write = new StreamWriter(savePlaylist.FileName);
                for (int i = 0; i < allpaths.Length; i++)
                {
                   Write.WriteLine((allpaths[i]));
                }
                Write.Close();
                    MessageBox.Show("Playlist saved!");
                }

                catch (Exception )
                {
                    MessageBox.Show("Няма запазен плейлист.");
                }
           
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                lbplayList.Items.Clear();


                using (FileStream fs = new FileStream(open.FileName, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            lbplayList.Items.Add(line);

                        }
                    }
                }

               
            }
        }

        private void AddForm_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.ShowDialog();


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                MessageBox.Show("The song already stopped.");
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(axWindowsMediaPlayer1.settings.mute == true)
            {
                axWindowsMediaPlayer1.settings.mute = false;
            }
            else if (axWindowsMediaPlayer1.settings.mute == false)
            {
                axWindowsMediaPlayer1.settings.mute = true;
            }

        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                MessageBox.Show("The song already paussed.");
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }
        private void PlayNextSong()
        {
            if ((lbplayList.SelectedIndex + 1) < lbplayList.Items.Count)
            {
                lbplayList.SelectedItem = lbplayList.Items[lbplayList.SelectedIndex + 1];
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        private void nextSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayNextSong();
        }
        private void PlayPreviousSong()
        {
            if ((lbplayList.SelectedIndex - 1) >=0)
            {
                lbplayList.SelectedItem = lbplayList.Items[lbplayList.SelectedIndex - 1];
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        private void previousSomgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayPreviousSong();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopToolStripMenuItem_Click(sender, e);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            PlayNextSong();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
             PlayPreviousSong();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutAplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info infoApplication = new Info();
            infoApplication.ShowDialog();


        }

        private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAuthor infAuthor = new InfoAuthor();
            infAuthor.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
             player = new OpenFileDialog();

            

        }
    }
}
