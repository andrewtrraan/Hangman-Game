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
using System.Media;

namespace Hangman
{
    public partial class startForm : Form
    {
        //the sound player plays the sound when the user guesses a wrong letter
        private SoundPlayer _soundPlayer;
        private SoundPlayer _backGround;
        public startForm()
        {
            InitializeComponent();
            //when the form starts display the keyboard
            TheButtons();
           
            //when the form starts give the user a max of 6 guesses to get wrong
            givenGuessAmount = 6;
        
            //when the forms starts make the windows media player invisible
            axWindowsMediaPlayer1.Visible = false;
            //the sound that will be played when the user guesses a word letter
           _soundPlayer = new SoundPlayer("HIBONG.wav");
           _backGround = new SoundPlayer("Kanye West - Real Friends.wav");
            //all the pictures are invisble when the form starts
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            //resets the game
            ResetGame();
            //selects the word
            WordSelection();
            //generates a box that displays the word as the user guesses the word
            AddLabels();
            //make the windows media player invisble
            axWindowsMediaPlayer1.Visible = false;
            //remove the embedded buttons on the windows media player
            axWindowsMediaPlayer1.uiMode = "none";
        }
        //wrong guesses
        int guessAttemptsWrong = 0;
        //the number of guesses allowed
        int givenGuessAmount;
        //Holds the letters for the current word
        List<Label> labels = new List<Label>();

        //sets uiMode of the windows meida player
        public System.String uiMode { get; set; }
        //The current word
        public string theCurrentWord { get; set; }

        //hides the letter so the user can guess it
        public string HideTheChar { get { return "_"; } }

        //add the buttons to the layout panel
        private void TheButtons()
        {
            //generates a keyboard from A to Z using the flowLayoutPanel
            for (int i = (int)'A'; i <= (int)'Z'; i++)
            {
                //call the button
                Button theGuess = new Button();
                //the button that is chosen converts the char to a string
                theGuess.Text = ((char)i).ToString();
                //buttons are located in the flow layout panel
                theGuess.Parent = flowLayoutPanel1;
                //sets the font of the buttons
                theGuess.Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
                //sets the size of the bttons
                theGuess.Size = new Size(70, 70);
                //sets the colour of the buttons
                theGuess.BackColor = Color.Orange;
                //allows the button clicks to be read
                theGuess.Click += theGuess_Click;

            }
            flowLayoutPanel1.Enabled = false;
        }

        void theGuess_Click(object sender, EventArgs e)
        {

            Button theGuess = (Button)sender;
            //read the letter chosen
            char letterChosen = theGuess.Text.ToCharArray()[0];
            //make the letter chosen not allowed to be chosen again
            theGuess.Enabled = false;

            //if the user guesses the correct letter of the word
            if ((theCurrentWord = theCurrentWord.ToUpper()).Contains(letterChosen))
            {
                //output message if guess was correct
                lblTheResult.Text = "Correct!";
                lblTheResult.ForeColor = Color.Salmon;
                //creates a char array of the letters of the current word
                char[] charArray = theCurrentWord.ToCharArray();
                for (int i = 0; i < theCurrentWord.Length; i++)
                {
                    if (charArray[i] == letterChosen)
                        labels[i].Text = letterChosen.ToString();


                }

                //if the user guesses all the letters of the word correctly
                if (labels.Where(x => x.Text.Equals(HideTheChar)).Any())
                    return;
                //output message if user won
                lblTheResult.Text = "You win!";
                lblTheResult.ForeColor = Color.Tomato;
                //disable the keyboard
                flowLayoutPanel1.Enabled = false;



            }
            //if the user chooses the wrong answer
            else
            {
                //add 1 to the varible for every wrong guess
                guessAttemptsWrong++;
                //output message if guess was wrong
                lblTheResult.Text = "wrong";
                lblTheResult.ForeColor = Color.Green;
                //output the number of guesses that are left for the user
                lblNumGuessLeft.Text = (givenGuessAmount - guessAttemptsWrong).ToString();
               //displays the wrong guesses
                lblTheWrongGuess.Text += string.IsNullOrWhiteSpace(lblTheWrongGuess.Text) ? letterChosen.ToString() : "," + letterChosen;




                //if the user has 1 wrong guess attempt
                if (guessAttemptsWrong == 1)
                {
                    //play the video for when the user reaches 1 wrong guess
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = "torso movement.MOV";
                    //play the sound when wrong guess
                    _soundPlayer.Play();
                    //call the timer to start
                    tmrDelayClicks.Start();


                }
                //if the user has 2 wrong guess attempts
                if (guessAttemptsWrong == 2)
                {
                    //play the video for when the user reaches 2 wrong guesses 
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = "Head Movement.MOV";
                    //play the sound when wrong guess
                    _soundPlayer.Play();
                    //makes the previous picture invisible
                    pictureBox1.Visible = false;
                    //call the timer to start
                    tmrDelayClicks.Start();

                }
                //if the user has 3 wrong guess attempts
                if (guessAttemptsWrong == 3)
                {
                    //play the video for when the user reaches 3 wrong guesses 
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = "left arm movement.MOV";
                    //play the sound when wrong guess
                   _soundPlayer.Play();
                    //makes the previous picture invisible
                    pictureBox2.Visible = false;
                    //call the timer to start
                    tmrDelayClicks.Start();
                }
                //if the user has 4 wrong guess attempts
                if (guessAttemptsWrong == 4)
                {
                    //play the video for when the user reaches 4 wrong guesses 
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = "right arm movement.MOV";
                    //play the sound when wrong guess
                    _soundPlayer.Play();
                    //makes the previous picture invisible
                    pictureBox3.Visible = false;
                    tmrDelayClicks.Start();
                }
                //if the user has 5 wrong guess attempts
                if (guessAttemptsWrong == 5)
                {
                    //play the video for when the user reaches 5 wrong guesses 
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = "left leg movement.MOV";
                    //play the sound when wrorng guess
                     _soundPlayer.Play();
                    //makes the previous picture invisible
                    pictureBox4.Visible = false;
                    //call the timer to start
                    tmrDelayClicks.Start();

                }
                //if the user has 6 wrong guess attempts
                if (guessAttemptsWrong == 6)
                {
                    lblTheResult.Text = "you lose";

                    //play the video for when the user reaches 6 wrong guesses 
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = "right leg movement.MOV";
                    //play sound when wrong guess
                    _soundPlayer.Play();
                    //makes the previous picture invisible
                    pictureBox5.Visible = false;
                    //reveal the word
                    for (int i = 0; i < theCurrentWord.Length; i++)
                    {
                        if (labels[i].Text.Equals(HideTheChar))
                        {

                            labels[i].Text = theCurrentWord[i].ToString();
                            labels[i].ForeColor = Color.Red;
                        }
                        tmrDelayClicks.Start();

                    }
                }
            }
            //disable the keyboard after the user loses
            flowLayoutPanel1.Enabled = false;
        }

        //crate the box where the letters that need to be guessed
        private void AddLabels()
        {
            //start the game with no letters shown
            groupBox1.Controls.Clear();
            labels.Clear();
            char[] wordsChar = theCurrentWord.ToCharArray();
            //check the length of the word
            int theLengthOfWord = wordsChar.Length;

            //generates the display of the word
            for (int i = 0; i < theLengthOfWord; i++)
            {
                //the word to guess that will be hidden
                Label theLength = new Label();
                //allow the number of number of letters in the word to become the number of chars to guess
                theLength.Text = HideTheChar;
                //how far each char is spereated
                theLength.Location = new Point(10 + i * 20, groupBox1.Height - 30);
                //displays the chars chosen in the groupbox
                theLength.Parent = groupBox1;
                //display the correct number of underscores for each letter of the word
                theLength.BringToFront();
                //display the chars that are chosen from the groupbox
                labels.Add(theLength);
            }

            //writing the text boxes
            lblWordLength.Text = theLengthOfWord.ToString();


        }

        private void ResetGame()
        {
            //clear the letters that were chosen from the previous game
            flowLayoutPanel1.Controls.Clear();
            //generatae the keybaord
            TheButtons();
            //clear the number of wrong guesses
            lblTheWrongGuess.Text = "";
            //clear the display messages
            lblTheResult.Text = "";
            //allow the keyboard to be enabled
            flowLayoutPanel1.Enabled = true;
            //clear the number of guess attempts left
            guessAttemptsWrong -= guessAttemptsWrong;
            //clear the number of guesses
            lblNumGuessLeft.Text = "";
            //make the photos invisble when the game resets
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;

        }
        private void WordSelection()
        {
            //choose the word to be guessed from Word.Txt file
            string filePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Words.txt");
            using (TextReader theFile = new StreamReader(filePath, Encoding.ASCII))
            {
                //radnomly chooses the word and splits the word up into letters
                Random WordSelected = new Random();
                //replace the underscores with the correctly guessed letters 
                var allWords = theFile.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                theCurrentWord = allWords[WordSelected.Next(0, allWords.Length - 1)];
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void axWindowsMediaPlayer_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void tmrDelayClicks_Tick(object sender, EventArgs e)
        {
          
        }

        private void startForm_Load(object sender, EventArgs e)
        {

        }

        private void tmrDelayClicks_Tick_1(object sender, EventArgs e)
        {
            //make the windows media player invisble 
            axWindowsMediaPlayer1.Visible = false;
           _backGround.Play();
            //display a screenshot of the video that would play if the user has 1 wrong guess and reenabled the keyboard after 3 seconds
            if (guessAttemptsWrong == 1)
            {
                pictureBox1.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
            //display a screenshot of the video that would play if the user has 2 wrong guesss and reenabled the keyboard 
            if (guessAttemptsWrong == 2)
            {
                pictureBox2.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
            //display a screenshot of the video that would play if the user has 3 wrong guesss and reenabled the keyboard 

            if (guessAttemptsWrong == 3)
            {
                pictureBox3.Visible = true;

                flowLayoutPanel1.Enabled = true;
            }
            //display a screenshot of the video that would play if the user has 4 wrong guesss and reenabled the keyboard 
            if (guessAttemptsWrong == 4)
            {
                pictureBox4.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
            //display a screenshot of the video that would play if the user has 5 wrong guesss and reenabled the keyboard 

            if (guessAttemptsWrong == 5)
            {
                pictureBox5.Visible = true;
                flowLayoutPanel1.Enabled = true;
            }
            //display a screenshot of the video that would play if the user has 6 wrong guesss 

            if (guessAttemptsWrong == 6)
            {
                pictureBox6.Visible = true;

            }
            //end the if statement after 3 seconds
            tmrDelayClicks.Stop();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resets the game
            ResetGame();
            //selects the word
            WordSelection();
            //generates a box that displays the word as the user guesses the word
            AddLabels();
            //make the windows media player invisble
            axWindowsMediaPlayer1.Visible = false;
            //remove the embedded buttons on the windows media player
            axWindowsMediaPlayer1.uiMode = "none";
        }

        private void startForm_Load_1(object sender, EventArgs e)
        {

        }

        private void startForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        
        }

        private void returnToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            new mainForm().ShowDialog();
            this.Close();
          
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}