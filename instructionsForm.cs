using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class instructionsForm : Form
    {
        public instructionsForm()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            Console.WriteLine("Instructions\n1. Click start to begin playing\n2. Click the letters that you think will spell the hidden word.\n3. You are only allowed to guess 6 incorrect letters. Everytime you guess an incorrect letter, a piece of the penguin will be shown.\n4. Once you take up all your guesses and the penguin is shown, the hidden word will be revealed.\n5. If you guess the word without the penguin being shown, you win.\n6. Have fun!");
    
        }
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
           
            this.Close();
            new startForm().ShowDialog();
         
        }

        private void btnReturnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            new mainForm().ShowDialog();
        }
    }
}
