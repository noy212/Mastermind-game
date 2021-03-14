using System;

namespace GameLogic
{
    public class GameManager
    {
        public const int k_SequenceLength = 4;
        private readonly Computer r_GameComputer = new Computer();
        private readonly byte[] r_CurrentGuessResult = new byte[2];
        private byte m_CurrentTurn;
        private bool m_GameResult;

        public byte CurrentTurn
        {
            get { return m_CurrentTurn; }
            set { m_CurrentTurn = value; }
        }

        public byte[] CurrentGuessResult
        {
            get { return r_CurrentGuessResult; }
        }

        public bool GameResult
        {
            get { return m_GameResult; }
        }

        public eColor[] ComputerSequence
        {
            get { return r_GameComputer.ColorsSequence; }
        }

        public void CheckCurrentGuess(eColor[] i_CurrentGuess)
        {
            byte yellowCounter = 0;
            byte blackCounter = 0;
            
            for (int i = 0; i < k_SequenceLength; i++)
            {
                int colorIndex = Array.IndexOf(r_GameComputer.ColorsSequence, i_CurrentGuess[i]);
                if (colorIndex == i)
                {
                    blackCounter++;
                }
                else if (colorIndex != -1)
                {
                    yellowCounter++;
                }
            }

            r_CurrentGuessResult[0] = blackCounter;
            r_CurrentGuessResult[1] = yellowCounter;
            if(blackCounter == k_SequenceLength)
            {
                m_GameResult = true;
            }
        }
    }
}
