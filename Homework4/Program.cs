using System;
using System.Collections.Generic;
using System.Text;

namespace Homework4
{
    public static class Program
    {
        private static readonly Dictionary<int, char> EnglishAlphabet = new Dictionary<int, char>()
            {
                { 1, 'a' }, { 2, 'b' }, { 3, 'c' }, { 4, 'd' }, { 5, 'e' }, { 6, 'f' }, { 7, 'g' }, { 8, 'h' }, { 9, 'i' }, { 10, 'j' }, { 11, 'k' }, { 12, 'l' },
                { 13, 'm' }, { 14, 'n' }, { 15, 'o' }, { 16, 'p' }, { 17, 'q' }, { 18, 'r' }, { 19, 's' }, { 20, 't' }, { 21, 'u' }, { 22, 'v' }, { 23, 'w' },
                { 24, 'x' }, { 25, 'y' }, { 26, 'z' }
            };

        private static readonly char[] UpperLetter = new char[]
            {
                'a', 'e', 'i', 'd', 'h', 'j'
            };

        public static void Main(string[] args)
        {
            int amountNumbers = InputString();
            int[] randomNumbers = CreateNumericArray(amountNumbers);
            StringBuilder oddNumber;
            StringBuilder evenNumber;
            FillingStrings(randomNumbers, out oddNumber, out evenNumber);
            Console.WriteLine($"\nString with odd values:\n{oddNumber.ToString()}");
            Console.WriteLine($"String with even values:\n{evenNumber.ToString()}");
            ReplaceSomeLetter(ref oddNumber, ref evenNumber);
            Console.WriteLine($"\nString with odd after replace values:\n{oddNumber.ToString()}");
            Console.WriteLine($"String with even after replace values:\n{evenNumber.ToString()}");
            Console.ReadKey();
        }

        public static int InputString()
        {
            bool isCorrect;
            int amountNumbers;
            do
            {
                Console.WriteLine("Input amount of numbers for create array: ");
                string tmp = Console.ReadLine();
                isCorrect = int.TryParse(tmp, out amountNumbers);
                if (!isCorrect)
                {
                    Console.WriteLine($"Sorry, but your string isn't number: {tmp}!\nTry again please!");
                }
            }
            while (!isCorrect);
            return amountNumbers;
        }

        public static int[] CreateNumericArray(int amountNumbers)
        {
            int[] randomNumbers = new int[amountNumbers];
            Random random = new Random();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(1, 26);
            }

            return randomNumbers;
        }

        public static void FillingStrings(in int[] randomNumbers, out StringBuilder oddNumber, out StringBuilder evenNumber)
        {
            int amountNumbers = randomNumbers.Length;
            oddNumber = new StringBuilder(amountNumbers / 2);
            evenNumber = new StringBuilder(amountNumbers / 2);
            foreach (int tmp in randomNumbers)
            {
                if (tmp % 2 == 0)
                {
                    evenNumber.Append(EnglishAlphabet[tmp]);
                    evenNumber.Append(' ');
                }
                else
                {
                    oddNumber.Append(EnglishAlphabet[tmp]);
                    oddNumber.Append(' ');
                }
            }
        }

        public static void ReplaceSomeLetter(ref StringBuilder oddNumber, ref StringBuilder evenNumber)
        {
            for (int i = 0; i < UpperLetter.Length; i++)
            {
                oddNumber = oddNumber.Replace(UpperLetter[i], char.ToUpper(UpperLetter[i]));
                evenNumber = evenNumber.Replace(UpperLetter[i], char.ToUpper(UpperLetter[i]));
            }
        }
    }
}
