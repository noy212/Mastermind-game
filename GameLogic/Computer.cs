using System;

namespace GameLogic
{
    public class Computer
    {
        public const byte k_NumOfColors = 8;
        private readonly eColor[] r_ColorSequence = new eColor[GameManager.k_SequenceLength];

        public Computer()
        {
            makeRandomSequence();
        }

        public eColor[] ColorsSequence
        {
            get
            {
                return r_ColorSequence;
            }
        }

        private void makeRandomSequence()
        {
            byte[] possibleColorsArray = new byte[k_NumOfColors] { 0, 1, 2, 3, 4, 5, 6, 7 };

            shuffleArray(possibleColorsArray);
            for (int i = 0; i < r_ColorSequence.Length; i++)
            {
                r_ColorSequence[i] = (eColor)possibleColorsArray[i];
            }
        }

        private void shuffleArray(byte[] i_PossibleColorsArray)
        {
            Random rand = new Random();

            for (int i = 0; i < i_PossibleColorsArray.Length; i++)
            {
                int randomIndex = rand.Next(i_PossibleColorsArray.Length);

                swap(ref i_PossibleColorsArray[randomIndex], ref i_PossibleColorsArray[i]);
            }
        }

        private void swap(ref byte io_Num1, ref byte io_Num2)
        {
            byte temp = io_Num1;

            io_Num1 = io_Num2;
            io_Num2 = temp;
        }
    }
}
