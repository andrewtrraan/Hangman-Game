using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Hangman
{
    public partial class mainForm : Form
    {
        private SoundPlayer intro;
        public mainForm()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.URL = "penguins walking.MOV";
            axWindowsMediaPlayer1.uiMode = "none";
            intro = new SoundPlayer("Kanye West - Real Friends.wav");
            intro.Play();
        }
        public System.String uiMode { get; set; }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //this.Hide();
            
            new startForm().ShowDialog();
            this.Close();
            //this.Show();
            //intro.Stop();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            this.Hide();
            new instructionsForm().ShowDialog();
        
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            new startForm().Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
      
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
           
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
            
        }
    }
}
