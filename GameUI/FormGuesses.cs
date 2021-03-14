using System;
using System.Windows.Forms;


namespace GameUI
{
    public partial class FormGuesses : Form
    {
        private byte m_NumOfGuesses = 4;

        private System.Windows.Forms.Button numOfGuessesButton;
        private System.Windows.Forms.Button startButton;

        public FormGuesses()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public byte NumOfGuesses
        {
            get
            {
                return m_NumOfGuesses;
            }
        }


        private void InitializeComponent()
        {
            this.numOfGuessesButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numOfGuessesButton
            // 
            this.numOfGuessesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numOfGuessesButton.Location = new System.Drawing.Point(67, 18);
            this.numOfGuessesButton.Name = "numOfGuessesButton";
            this.numOfGuessesButton.Size = new System.Drawing.Size(148, 23);
            this.numOfGuessesButton.TabIndex = 0;
            this.numOfGuessesButton.Text = "Number of chances: 4";
            this.numOfGuessesButton.UseVisualStyleBackColor = true;
            this.numOfGuessesButton.Click += new System.EventHandler(this.numOfGuessesButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startButton.Location = new System.Drawing.Point(98, 58);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // FormGuesses
            // 
            this.ClientSize = new System.Drawing.Size(290, 106);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.numOfGuessesButton);
            this.Name = "FormGuesses";
            this.Text = "Mastermind";
            this.ResumeLayout(false);

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGame newGame = new FormGame(m_NumOfGuesses);
            newGame.ShowDialog();
            this.Close();
        }

        private void numOfGuessesButton_Click(object sender, EventArgs e)
        {
            if (m_NumOfGuesses == 10)
            {
                m_NumOfGuesses = 4;
            }
            else
            {
                m_NumOfGuesses++;
            }

            (sender as Button).Text = string.Format("Number of chances: {0}", m_NumOfGuesses);
        }
    }
}
