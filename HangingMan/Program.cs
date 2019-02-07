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
            Random wordSelect = new Random();
            string[] wordsFromFile = File.ReadAllLines(@"C:\Users\maximilian.wimmer\Documents\Programming\HangingMan\HangingMan\Test.txt");
            char[] guessedTrueCharakters = new char[wort.Length * 2];
            
            int counter = 0;
            bool wordComplete = false;
            char userCharakter = ' ';
            bool error = false;
            //--------------------------------------------------------------------------------------------------------
            Console.WriteLine("You are playing against the Computer!");
            Console.WriteLine("-------------------------------------");
            wort = wordsFromFile[wordSelect.Next(0, wordsFromFile.Length)];
            var guessedWord = new StringBuilder(new String('_', wort.Length));
            Thread.Sleep(2000);
            Console.Clear();
            //--------------------------------------------------------------------------------------------------------
            while (counter < 10 && wordComplete == false)
            {

                Console.WriteLine("It's your Turn! ");
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                HangingManPicture(counter);
                Console.WriteLine();
                Console.Write("Your word is:");
                Console.Write(guessedWord);
                Console.WriteLine();
                Console.WriteLine("Please enter a Charakter: ");
                //--------------------------------------------------------------------------------------------------------
                try
                {
                    userCharakter = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e.Message);
                    error = true;
                }
                //--------------------------------------------------------------------------------------------------------
                if (wort.Contains(char.ToUpper(userCharakter)))
                {
                    int i;
                    for ( i = 0; i < wort.Length; i++)
                    {
                        if (char.ToUpper(userCharakter) == wort[i])
                            guessedWord[i] = char.ToUpper(userCharakter);
                    }
                    Console.WriteLine("Your guessed Word is: ");
                    Console.WriteLine(guessedWord);
                    guessedTrueCharakters[i + wort.Length] = char.ToUpper(userCharakter);
                    if (guessedWord.ToString() == wort)
                    {
                        wordComplete = true;
                    }
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                //--------------------------------------------------------------------------------------------------------
                else
                {
                    if (wort.Contains(userCharakter))
                    {
                        Console.WriteLine("Well Done");
                        for (int i = 0; i < wort.Length; i++)
                        {
                            if (userCharakter == wort[i])
                                guessedWord[i] = userCharakter;
                        }

                        Console.WriteLine("Your guessed Word is: ");
                        Console.WriteLine(guessedWord);

                        if (guessedWord.ToString() == wort)
                        {
                            wordComplete = true;
                        }

                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    //--------------------------------------------------------------------------------------------------------
                    else
                    {
                            if (error == true)
                            {
                                Console.WriteLine("You made a mistake!");
                                error = false;
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine("What a pity!");
                                Console.WriteLine("Your Charakter is not in the Word!");
                                counter = counter + 1;
                                if (guessedWord.ToString() == wort)
                                {
                                    wordComplete = true;
                                }
                                Thread.Sleep(1000);
                            }
                        Console.Clear();
                    }
                
               } 
            }
            //--------------------------------------------------------------------------------------------------------

            if (wort == guessedWord.ToString())
            {
                Console.WriteLine("Game Over");
                Console.WriteLine("---------");
                Console.WriteLine();
                Console.WriteLine("You beat the Computer!");
                Console.Write("Do you want to play again(y/n):");
                string repeat = Console.ReadLine();
                if (repeat == "y")
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Alone();
                }
            }
            else
            {
                Console.WriteLine("Game Over");
                HangingManPicture(11);
                Console.WriteLine();
                Console.WriteLine("The Computer has won!");
                Console.Write("Do you want to play again(y/n):");
                string repeat = Console.ReadLine();
                if (repeat == "y")
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Alone();
                }
                //--------------------------------------------------------------------------------------------------------
                Console.ReadLine();

            }
        }
        static void Together()
        {
                int counter = 0;
                bool wordComplete = false;
                char userCharakter = ' ';
                bool error = false;
                int counterGuessedTrueCharakters = 0;
                int counterGuessedFalseCharakters = 0;

            //--------------------------------------------------------------------------------------------------------
            Console.WriteLine("You are playing together!");
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                Console.WriteLine("Player 1 please enter you word: ");
                wort = Console.ReadLine();
                var guessedWord = new StringBuilder(new String('_', wort.Length));
                char[] guessedTrueCharakters = new char[wort.Length * 2];
                char[] guessedFalseCharakters = new char[100];
                Console.WriteLine("The word is saved!");
                Thread.Sleep(3000);
                Console.Clear();
            //--------------------------------------------------------------------------------------------------------

            while (counter < 10 && wordComplete == false)
            {

                Console.WriteLine("Player 2 it's your Turn! ");
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                HangingManPicture(counter);
                Console.WriteLine();
                Console.Write("Your word is:");
                Console.Write(guessedWord);
                Console.WriteLine();
                Console.WriteLine("Already guessed true Charakters:");
                Console.WriteLine(guessedTrueCharakters);
                Console.WriteLine("Already guessed false Charakters:");
                Console.WriteLine(guessedFalseCharakters);
                Console.WriteLine("Please enter a Charakter: ");
                //--------------------------------------------------------------------------------------------------------
                try
                {
                    userCharakter = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e.Message);
                    error = true;

                }
                //--------------------------------------------------------------------------------------------------------

                if (guessedTrueCharakters.Contains(userCharakter) || guessedTrueCharakters.Contains(char.ToUpper(userCharakter)))
                {
                    Console.WriteLine("Already guessed charakter!!");
                    Console.WriteLine();
                    Console.WriteLine("Your guessed Word is: ");
                    Console.WriteLine(guessedWord);
                    Console.WriteLine("Already guessed true Charakters:");
                    Console.WriteLine(guessedTrueCharakters);
                    Console.WriteLine("Already guessed false Charakters:");
                    Console.WriteLine(guessedFalseCharakters);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                { 

                    if (wort.Contains(char.ToUpper(userCharakter)))
                    {
                        int i = 0;
                        for (i = 0; i < wort.Length; i++)
                        {
                            if (char.ToUpper(userCharakter) == wort[i])
                                guessedWord[i] = char.ToUpper(userCharakter);
                        }
                        
                        Console.WriteLine("Your guessed Word is: ");
                        Console.WriteLine(guessedWord);
                        guessedTrueCharakters[counterGuessedTrueCharakters] = char.ToUpper(userCharakter);
                        Console.WriteLine("Already guessed true Charakters:");
                        Console.WriteLine(guessedTrueCharakters);
                        counterGuessedTrueCharakters++;

                        if (guessedWord.ToString() == wort)
                        {
                            wordComplete = true;
                        }
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    //--------------------------------------------------------------------------------------------------------
                    else
                    {
                        if (wort.Contains(userCharakter))
                        {
                            Console.WriteLine("Well Done");
                            int i = 0;
                            
                            for (i = 0; i < wort.Length; i++)
                            {
                                if (userCharakter == wort[i])
                                    guessedWord[i] = userCharakter;
                            }
                            
                            Console.WriteLine("Your guessed Word is: ");
                            Console.WriteLine(guessedWord);
                            guessedTrueCharakters[counterGuessedTrueCharakters] = userCharakter;
                            Console.WriteLine("Already guessed Charakters:");
                            Console.WriteLine(guessedTrueCharakters);
                            counterGuessedTrueCharakters++;
                            if (guessedWord.ToString() == wort)
                            {
                                wordComplete = true;
                            }

                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        //--------------------------------------------------------------------------------------------------------
                        else
                        {
                            if (error == true)
                            {
                                Console.WriteLine("You made a mistake!");
                                error = false;
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine("What a pity!");
                                Console.WriteLine("Your Charakter is not in the Word!");
                                counter++;
                                guessedFalseCharakters[counterGuessedFalseCharakters] = userCharakter;
                                counterGuessedFalseCharakters++;
                                if (guessedWord.ToString() == wort)
                                {
                                    wordComplete = true;
                                }

                                Thread.Sleep(1000);
                            }
                            Console.Clear();
                        }

                    }
                }
            }
                //--------------------------------------------------------------------------------------------------------

                if (wort == guessedWord.ToString())
                {
                    Console.WriteLine("Game Over");
                    Console.WriteLine("---------");
                    Console.WriteLine();
                    Console.WriteLine("Player 2 has won!");
                    Console.WriteLine();
                    Console.WriteLine("The word is: " + wort);
                    Console.Write("Do you want to play again(y/n):");
                    string repeat = Console.ReadLine();
                    if (repeat == "y")
                    {
                        Thread.Sleep(2000);
                        Console.Clear();
                        Together();
                    }
                }
                else
                {
                    Console.WriteLine("Game Over");
                    HangingManPicture(11);
                    Console.WriteLine();
                    Console.WriteLine("Player 1 has won!");
                    Console.WriteLine();
                    Console.WriteLine("The word would have been: " + wort);
                    Console.Write("Do you want to play again(y/n):");
                    string repeat = Console.ReadLine();
                    if (repeat == "y")
                    {
                        Thread.Sleep(2000);
                        Console.Clear();
                        Together();
                    }
                    //--------------------------------------------------------------------------------------------------------
                    Console.ReadLine();
                }
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
