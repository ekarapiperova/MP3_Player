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
    public partial class FirstForm : Form
    {
         
        public FirstForm()
        {
            InitializeComponent();
           
        }
       

        private void btnPlay_Click(object sender, EventArgs e)
        {

            MainForm ftm = new MainForm();
            ftm.ShowDialog();

            this.Close();
        }


    }

        
}
