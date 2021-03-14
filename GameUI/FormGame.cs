using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GameLogic;

namespace GameUI
{
    public partial class FormGame : Form
    {
        public const byte k_ButtonSize = 40;
        private readonly byte r_NumOfGuesses;
        private Button[,] m_GuessButtons;
        private Button[,] m_ResButtons;
        private Button[] m_Arrows;
        private FormColorPlate m_ColorPlate = new FormColorPlate();
        private GameManager m_GameManager = new GameManager();

        public FormGame(byte i_NumOfGuesses)
        {
            r_NumOfGuesses = i_NumOfGuesses;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            setBoard();
        }

        private void setBoard()
        {
            Button newButton;
            int i = 0, j = 0;

            m_GuessButtons = new Button[r_NumOfGuesses, GameManager.k_SequenceLength];
            m_ResButtons = new Button[r_NumOfGuesses, GameManager.k_SequenceLength];
            m_Arrows = new Button[r_NumOfGuesses];
            for (i = 0; i < r_NumOfGuesses; i++)
            {
                for (j = 0; j < GameManager.k_SequenceLength; j++)
                {
                    newButton = createButton(70, i, j, new Size(k_ButtonSize, k_ButtonSize), string.Empty, new EventHandler(button_Click));
                    m_GuessButtons[i, j] = newButton;
                }
                newButton = createButton(80, i, j, new Size(k_ButtonSize, k_ButtonSize/2), "→", new EventHandler(arrow_Click));
                m_Arrows[i] = newButton;
                createResultButtons(color4.Left+15, i, 5, new Size(15, 15), String.Empty, null);

            }

            for (i = 0; i < GameManager.k_SequenceLength; i++)
            {
                m_GuessButtons[0, i].Enabled = true;
            }
            this.Size = PreferredSize;
        }

        private void createResultButtons(int i_top, int i_Row, int i_Column, Size i_Size, string i_Text, EventHandler i_EventHandler)
        {
            Button tempButton;
            for (int i = 0; i < 2; i++)
            {
                tempButton = createButton(70, i_Row, i_Column + i*0.5, i_Size, string.Empty, i_EventHandler);
                m_ResButtons[i_Row,  i] = tempButton;
            }

            for (int i = 0; i < 2; i++)
            {
                tempButton = createButton(70 + 20, i_Row, i_Column+i*0.5, i_Size, string.Empty, i_EventHandler);
                m_ResButtons[i_Row, 2 + i] = tempButton;
            }

        }

        private Button createButton(int i_Top, int i_Row, double i_Column, Size i_Size, string i_Text, EventHandler i_EventHandler)
        {
            Button button = new Button();
            button.Size = i_Size;
            button.Location = new Point((int)(color1.Left + i_Column * 45), i_Top + i_Row * 45);
            button.Text = i_Text;
            button.Enabled = false;
            button.Font = new Font("Arial Rounded MT Bold", 15F);
            button.Click += i_EventHandler;
            this.Controls.Add(button);
            return button;         

        }

        private void arrow_Click(object sender, EventArgs e)
        {
            eColor[] currentGuess = new eColor[4];
            for(int i = 0; i < GameManager.k_SequenceLength; i++)
            {
                currentGuess[i] =(eColor)Enum.Parse(typeof(eColor),(m_GuessButtons[m_GameManager.CurrentTurn, i].BackColor.Name));
            }
            m_GameManager.CheckCurrentGuess(currentGuess);
            showResult();
            nextTurn();
        }

        private void showResult()
        {
            byte columnIndex = 0;
            for(int i = 0; i < m_GameManager.CurrentGuessResult[0]; i++)
            {
                m_ResButtons[m_GameManager.CurrentTurn, columnIndex].BackColor = Color.Black;
                columnIndex++;
            }

            for (int i = 0; i < m_GameManager.CurrentGuessResult[1]; i++)
            {
                m_ResButtons[m_GameManager.CurrentTurn, columnIndex].BackColor = Color.Yellow;
                columnIndex++;
            }
        }

        private void nextTurn()
        {
            m_ColorPlate.Close();
            m_ColorPlate = new FormColorPlate();
            m_Arrows[m_GameManager.CurrentTurn].Enabled = false;
            if (m_GameManager.CurrentTurn + 1 == r_NumOfGuesses || m_GameManager.GameResult == true)
            {
                endGame();
            }
            else
            {
                m_GameManager.CurrentTurn++;
                for (int i = 0; i < GameManager.k_SequenceLength; i++)
                {
                    m_GuessButtons[m_GameManager.CurrentTurn - 1, i].Enabled = false;
                    m_GuessButtons[m_GameManager.CurrentTurn, i].Enabled = true;
                }
            }
        }

        private void endGame()
        {
            color1.BackColor = Color.FromName(m_GameManager.ComputerSequence[0].ToString());
            color2.BackColor = Color.FromName(m_GameManager.ComputerSequence[1].ToString());
            color3.BackColor = Color.FromName(m_GameManager.ComputerSequence[2].ToString());
            color4.BackColor = Color.FromName(m_GameManager.ComputerSequence[3].ToString());
            showEndOfGameMessages();
        }

        private void showEndOfGameMessages()
        {
            DialogResult result;

            if (m_GameManager.GameResult == true)
            {
                result = MessageBox.Show("You Win! \n Would you like to play another round?", "Game Over", MessageBoxButtons.YesNo);
            }
            else
            {
                result = MessageBox.Show("Would you like to play another round?", "Game Over",
                     MessageBoxButtons.YesNo);
            }

            afterGameOptions(result);
        }

        private void afterGameOptions(DialogResult i_Result)
        {
            if (i_Result == DialogResult.Yes)
            {
                startAnotherGame();
            }
            else
            {
                this.Close();
            }
        }

        private void startAnotherGame()
        {
            m_GameManager = new GameManager();
            foreach(Button button in m_GuessButtons)
            {
                button.BackColor = default(Color);
                button.Enabled = false;
    
            }
            foreach (Button button in m_ResButtons)
            {
                button.BackColor = default(Color);
            }

            for (int i = 0; i < GameManager.k_SequenceLength; i++)
            {
                m_GuessButtons[0, i].Enabled = true;
            }

            color1.BackColor = Color.Black;
            color2.BackColor = Color.Black;
            color3.BackColor = Color.Black;
            color4.BackColor = Color.Black;
        }

        private void button_Click(object sender, EventArgs e)
        {
            bool endTurn = true;
            m_ColorPlate.CurrentButton = sender as Button;
            m_ColorPlate.StartPosition = FormStartPosition.Manual;
            m_ColorPlate.Location = PointToScreen(new Point((sender as Button).Left - m_ColorPlate.Width, (sender as Button).Top + (sender as Button).Height));
            m_ColorPlate.ShowDialog();
            for(int i = 0; i < GameManager.k_SequenceLength; i++)
            {
                if (m_GuessButtons[m_GameManager.CurrentTurn, i].BackColor.Name == "Control")
                {
                    endTurn = false;
                }
            }
            if(endTurn == true)
            {
                m_Arrows[m_GameManager.CurrentTurn].Enabled = true;
            }
        }

        private void InitializeComponent()
        {
            this.color1 = new System.Windows.Forms.Button();
            this.color2 = new System.Windows.Forms.Button();
            this.color3 = new System.Windows.Forms.Button();
            this.color4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // color1
            // 
            this.color1.BackColor = System.Drawing.Color.Black;
            this.color1.Enabled = false;
            this.color1.Location = new System.Drawing.Point(12, 12);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(40, 40);
            this.color1.TabIndex = 3;
            this.color1.UseVisualStyleBackColor = false;
            // 
            // color2
            // 
            this.color2.BackColor = System.Drawing.Color.Black;
            this.color2.Enabled = false;
            this.color2.Location = new System.Drawing.Point(57, 12);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(40, 40);
            this.color2.TabIndex = 4;
            this.color2.UseVisualStyleBackColor = false;
            // 
            // color3
            // 
            this.color3.BackColor = System.Drawing.Color.Black;
            this.color3.Enabled = false;
            this.color3.Location = new System.Drawing.Point(102, 12);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(40, 40);
            this.color3.TabIndex = 5;
            this.color3.UseVisualStyleBackColor = false;
            // 
            // color4
            // 
            this.color4.BackColor = System.Drawing.Color.Black;
            this.color4.Enabled = false;
            this.color4.Location = new System.Drawing.Point(147, 12);
            this.color4.Name = "color4";
            this.color4.Size = new System.Drawing.Size(40, 40);
            this.color4.TabIndex = 6;
            this.color4.UseVisualStyleBackColor = false;
            // 
            // FormGame
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.color4);
            this.Controls.Add(this.color3);
            this.Controls.Add(this.color2);
            this.Controls.Add(this.color1);
            this.Name = "FormGame";
            this.Text = "Mastermind";
            this.ResumeLayout(false);

        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }
    }
}
