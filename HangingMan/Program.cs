using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangingMan
{
    class Program
    {
        public static string wort;
        static void Main(string[] args)
        {
            Start();
            Console.ReadLine();

        }
        static void Start()
        {
            string playstyle;
            //--------------------------------------------------------------------------------------------------------
            Console.WriteLine("You are playing Hanging Man");
            Console.Write("Do you play alone or with a friend:");
            playstyle = Console.ReadLine();
            //--------------------------------------------------------------------------------------------------------
            switch (playstyle)
            {
                case ("Alone"):
                    Console.Clear();
                    Alone();
                    return;
                case ("alone"):
                    Console.Clear();
                    Alone();
                    return;
                case ("with a friend"):
                    Console.Clear();
                    Together();
                    return;
                case ("Together"):
                    Console.Clear();
                    Together();
                    return;
                case ("Yes"):
                    Console.Clear();
                    Together();
                    return;
                case ("No"):
                    Console.Clear();
                    Alone();
                    return;
                default:
                    Console.WriteLine("Unknown!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Start();

                    return;
            }
        }
        static void Alone()
        {
           
        }
        static void Together()
        {
            string winner;
            int counter = 0;
            bool wordComplete = false;
            char userCharakter = 'a';
            
            Console.WriteLine("You are playing together!");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.Write("Player 1 please enter you word: ");
            wort = Console.ReadLine();
            char[] buchstaben = new char[wort.Length];
            char[] guessedWord = new char[wort.Length];
            //--------------------------------------------------------------------------------------------------------
            using (StringReader sr = new StringReader(wort))
            {
                sr.Read(buchstaben, 0, wort.Length);
            }
            Console.WriteLine("The word is saved!");
            Thread.Sleep(3000);
            Console.Clear();
            //--------------------------------------------------------------------------------------------------------
           
                while(counter < 10 & wordComplete == false)
                {
                
                    Console.WriteLine("Player 2 it's your Turn! ");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine();
                    HangingManPicture(counter);
                    Console.WriteLine();
                    Console.Write("Your word is:");
                    Console.Write(guessedWord);
                    Console.WriteLine();
                    Console.WriteLine("Please enter a Charakter: ");
                    try
                    {
                        userCharakter = Convert.ToChar(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error" + e.Message);
                    }
                    //--------------------------------------------------------------------------------------------------------
                    if (Array.Exists(buchstaben, element => element == userCharakter))
                    {
                        Console.WriteLine("Well Done");
                        guessedWord[Array.IndexOf(buchstaben, userCharakter)] = userCharakter;
                        Console.Write("Your guessed Word is: ");
                        Console.Write(guessedWord);
                        Console.ReadLine();
                            if (guessedWord == buchstaben)
                            {
                                wordComplete = true;
                            }
                    }
                    else
                    {
                        Console.WriteLine("What a pity!");
                        Console.WriteLine("Your Charakter is not in the Word!");
                        counter = counter + 1;
                        Console.ReadLine();
                            if (guessedWord == buchstaben)
                            {
                                wordComplete = true;
                            }
                }
                    
                //--------------------------------------------------------------------------------------------------------
                Console.Clear();
                }
            //--------------------------------------------------------------------------------------------------------
            if (buchstaben == guessedWord)
            {
                Console.WriteLine("Game Over");
                Console.WriteLine("---------");
                Console.WriteLine();
                Console.WriteLine("Player 2 has won!");
            }
            else
            {
                Console.WriteLine("Game Over");
                HangingManPicture(11);
                Console.WriteLine();
                Console.WriteLine("Player 1 has won!");
                wordComplete = true;
            }
            //--------------------------------------------------------------------------------------------------------
            Console.ReadLine();
        }
        static void HangingManPicture (int counter)
        {
            switch (counter)
            {
                case (0):
                    Console.WriteLine(" _____________________ ");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|                     |");
                    Console.WriteLine("|_____________________|");
                    return;
                case (1):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|   _______________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (2):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (3):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (4):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /         |");
                    Console.WriteLine(@"|        I /          |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (5):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (6):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I       0    |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (7):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I       0    |");
                    Console.WriteLine(@"|        I       1    |");
                    Console.WriteLine(@"|        I            |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (8):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I       0    |");
                    Console.WriteLine(@"|        I       1    |");
                    Console.WriteLine(@"|        I        \   |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (9):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I       0    |");
                    Console.WriteLine(@"|        I       1    |");
                    Console.WriteLine(@"|        I      / \   |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (10):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I       0/   |");
                    Console.WriteLine(@"|        I       1    |");
                    Console.WriteLine(@"|        I      / \   |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
                case (11):
                    Console.WriteLine(@" _____________________ ");
                    Console.WriteLine(@"|                     |");
                    Console.WriteLine(@"|        _________    |");
                    Console.WriteLine(@"|        I  /    I    |");
                    Console.WriteLine(@"|        I /     I    |");
                    Console.WriteLine(@"|        I      \0/   |");
                    Console.WriteLine(@"|        I       1    |");
                    Console.WriteLine(@"|        I      / \   |");
                    Console.WriteLine(@"|   _____I_________   |");
                    Console.WriteLine(@"|  /               \  |");
                    Console.WriteLine(@"|_/_________________\_|");
                    return;
            }
        }
    }
}
