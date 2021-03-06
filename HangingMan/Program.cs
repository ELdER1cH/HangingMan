﻿using System;
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
            string[] wordsFromFile = File.ReadAllLines(@"wordlibaryGerman.txt");
            int counter = 0;
            bool wordComplete = false;
            char userCharakter = ' ';
            bool error = false;
            int counterGuessedTrueCharakters = 0;
            int counterGuessedFalseCharakters = 0;
            string wordlist;
            //--------------------------------------------------------------------------------------------------------
            Console.WriteLine("You are playing against the Computer!");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Which wordlist do you want to use?");
            Console.WriteLine("(Default: German)");
            Console.WriteLine("- German");
            Console.WriteLine("- English");
            Console.WriteLine("- your own");
            wordlist = Console.ReadLine();
            switch (wordlist)
            {
                case ("German"):
                    wordsFromFile = File.ReadAllLines(@"wordlibaryGerman.txt");
                    break;
                case ("English"):
                    wordsFromFile = File.ReadAllLines(@"wordsLibary.txt");
                    break;
                //----------------------------------------------------------------------
                case ("my own"):
                    string repeat = "y";
                    Console.Clear();
                    do
                    {

                        Console.WriteLine("You habe choosen your own List");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("You have the Options:");
                        Console.WriteLine("- Clear list");
                        Console.WriteLine("- Import another list");
                        Console.WriteLine("- add words");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("To move on just type in skip");
                        string ownListOptions;
                        //----------------------------------------------------------------------
                        switch (ownListOptions = Console.ReadLine())
                        {
                            //----------------------------------------------------------------------
                            case ("Import another list"):
                                Console.WriteLine("Do you want to import another list? (y/n)");
                                Console.WriteLine("! Be warned your words will be overritten !");
                                string importList;
                                if ((importList = Console.ReadLine()) == "y")
                                {
                                    Console.Write("Which one (German or English): ");
                                    string importListChoose;
                                    switch (importListChoose = Console.ReadLine())
                                    {
                                        case ("German"):
                                            File.Copy("wordlibaryGerman.txt", "myownLibary.txt", true);
                                            break;
                                        case ("English"):
                                            File.Copy("wordsLibaryEnglisch.txt", "myownLibary.txt", true);
                                            break;
                                        default:
                                            Console.WriteLine("Unkown List!");
                                            Thread.Sleep(1500);
                                            Console.Clear();
                                            Alone();
                                            break;
                                    }
                                }
                                break;
                            //----------------------------------------------------------------------
                            case ("Clear List"):
                                File.Delete("myownLibary.txt");
                                File.Create("myownLibary.txt");
                                break;
                            //----------------------------------------------------------------------
                            case ("skip"):
                                repeat = " ";
                                break;
                            //----------------------------------------------------------------------
                            case ("add words"):
                                string repeat1 = "y";
                                while (repeat1 == "y")
                                {
                                    Console.Write("Please type in your word: ");
                                    var writeLine = from line in File.ReadLines("myownLibary.txt")
                                                       where File.ReadLines("myownLibary.txt") == null
                                                       select line;
                                    File.AppendAllLines("myownLibary.txt", writeLine);
                                    Console.WriteLine("Do you want to add another word ? (y/n)");
                                    repeat1 = Console.ReadLine();

                                }
                                
                                break;
                            //----------------------------------------------------------------------
                            default:
                                Console.WriteLine("Unknown!");
                                Thread.Sleep(1000);
                                break;
                        }
                        Console.Clear();
                        //----------------------------------------------------------------------
                    } while (repeat == "y");
                    break;
                default:
                    Console.WriteLine("Unkown List!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Alone();
                    break;
            }
            Console.WriteLine();
            //----------------------------------------------------------------
            wort = wordsFromFile[wordSelect.Next(0,wordsFromFile.Length)];
            var guessedWord = new StringBuilder(new String('-', wort.Length));
            //----------------------------------------------------------------
            char[] guessedTrueCharakters = new char[100];
            char[] guessedFalseCharakters = new char[100];
            //----------------------------------------------------------------
            Thread.Sleep(1000);
            Console.WriteLine("The word is set! (Press Enter)");
            Console.ReadLine();
            Console.Clear();
            //--------------------------------------------------------------------------------------------------------

            while (counter < 10 && wordComplete == false)
            {

                Console.WriteLine("It's your Turn! ");
                Console.WriteLine("----------------");
                //----------------------------------------------------------
                Console.WriteLine();
                HangingManPicture(counter);
                Console.WriteLine();
                //----------------------------------------------------------
                Console.Write("Your word is:");
                Console.WriteLine(guessedWord);
                //----------------------------------------------------------
                Console.Write("Already guessed true Charakters:");
                Console.WriteLine(guessedTrueCharakters);
                //----------------------------------------------------------
                Console.Write("Already guessed false Charakters:");
                Console.WriteLine(guessedFalseCharakters);
                //----------------------------------------------------------
                Console.Write("Please enter a Charakter: ");
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
                if (userCharakter == '*')
                {
                    counter = Cheat(counter);
                }
                else { 

                if (
                    guessedTrueCharakters.Contains(userCharakter) ||
                    guessedTrueCharakters.Contains(char.ToUpper(userCharakter)) ||
                    guessedTrueCharakters.Contains(char.ToLower(userCharakter)) ||
                    guessedFalseCharakters.Contains(userCharakter) ||
                    guessedFalseCharakters.Contains(char.ToUpper(userCharakter)) ||
                    guessedFalseCharakters.Contains(char.ToLower(userCharakter))
                   )
                {
                    Console.WriteLine("Already guessed charakter!!");
                    Console.WriteLine();
                    //----------------------------------------------------------
                    Console.WriteLine("Your guessed Word is: ");
                    Console.WriteLine(guessedWord);
                    //----------------------------------------------------------
                    Console.Write("Already guessed true Charakters:");
                    Console.WriteLine(guessedTrueCharakters);
                    //----------------------------------------------------------
                    Console.Write("Already guessed false Charakters:");
                    Console.WriteLine(guessedFalseCharakters);
                    //----------------------------------------------------------
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {

                        if (wort.Contains(char.ToUpper(userCharakter)) || wort.Contains(char.ToLower(userCharakter)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("----------");
                            Console.WriteLine("Well Done!");
                            Console.WriteLine();
                            int i = 0;
                            if (wort.Contains(char.ToUpper(userCharakter)))
                            {
                                for (i = 0; i < wort.Length; i++)
                                {
                                    if (char.ToUpper(userCharakter) == wort[i])
                                        guessedWord[i] = char.ToUpper(userCharakter);
                                }
                            }
                            //----------------------------------------------------------
                            if (wort.Contains(char.ToLower(userCharakter)))
                            {
                                for (i = 0; i < wort.Length; i++)
                                {
                                    if (userCharakter == wort[i])
                                        guessedWord[i] = userCharakter;
                                }
                            }
                            //----------------------------------------------------------
                            Console.Write("Your guessed Word is: ");
                            Console.WriteLine(guessedWord);
                            //----------------------------------------------------------
                            guessedTrueCharakters[counterGuessedTrueCharakters] = char.ToLower(userCharakter);
                            Console.Write("Already guessed true Charakters: ");
                            Console.WriteLine(guessedTrueCharakters);
                            counterGuessedTrueCharakters++;
                            //----------------------------------------------------------
                            if (guessedWord.ToString() == wort)
                            {
                                wordComplete = true;
                            }

                            Console.ReadLine();
                            Console.Clear();

                        }
                        else
                        {
                            if (error == true)
                            {
                                Console.WriteLine("You made a mistake!");
                                error = false;
                                Console.ReadLine();
                            }
                            //----------------------------------------------------------
                            else
                            {
                                Console.WriteLine("What a pity!");
                                Console.WriteLine("Your Charakter is not in the Word!");
                                counter++;
                                guessedFalseCharakters[counterGuessedFalseCharakters] = char.ToLower(userCharakter);
                                counterGuessedFalseCharakters++;

                                if (guessedWord.ToString() == wort)
                                {
                                    wordComplete = true;
                                }

                                Console.ReadLine();
                            }
                        }
                        Console.Clear();
                    }
                    Console.Clear();
                }
                Console.Clear();
            }
            //--------------------------------------------------------------------------------------------------------

            if (wort == guessedWord.ToString())
            {
                Console.WriteLine("Game Over");
                Console.WriteLine("---------");
                Console.WriteLine();
                Console.WriteLine("You beat the Computer!");
                Console.WriteLine();
                Console.WriteLine("The word is: " + wort);
                Console.WriteLine();
                Console.Write("Do you want to play again(y/n):");
                string repeat = Console.ReadLine();
                if (repeat == "y")
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Together();
                }
                else
                    Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Game Over");
                HangingManPicture(11);
                Console.WriteLine();
                Console.WriteLine("The Computer has won!");
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
                else Environment.Exit(0);
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
            var guessedWord = new StringBuilder(new String('-', wort.Length));
            char[] guessedTrueCharakters = new char[100];
            char[] guessedFalseCharakters = new char[100];
            Console.WriteLine("The word is saved!");
            Thread.Sleep(3000);
            Console.Clear();
            //--------------------------------------------------------------------------------------------------------

            while (counter < 10 && wordComplete == false)
            {

                Console.WriteLine("Player 2 it's your Turn! ");
                Console.WriteLine("-------------------------");
                //----------------------------------------------------------
                Console.WriteLine();
                HangingManPicture(counter);
                Console.WriteLine();
                //----------------------------------------------------------
                Console.Write("Your word is:");
                Console.WriteLine(guessedWord);
                //----------------------------------------------------------
                Console.Write("Already guessed true Charakters:");
                Console.WriteLine(guessedTrueCharakters);
                //----------------------------------------------------------
                Console.Write("Already guessed false Charakters:");
                Console.WriteLine(guessedFalseCharakters);
                //----------------------------------------------------------
                Console.Write("Please enter a Charakter: ");
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
                if (userCharakter == '*')
                {
                    counter = Cheat(counter);
                }
                else
                {
                    if (
                    guessedTrueCharakters.Contains(userCharakter) ||
                    guessedTrueCharakters.Contains(char.ToUpper(userCharakter)) ||
                    guessedTrueCharakters.Contains(char.ToLower(userCharakter)) ||
                    guessedFalseCharakters.Contains(userCharakter) ||
                    guessedFalseCharakters.Contains(char.ToUpper(userCharakter)) ||
                    guessedFalseCharakters.Contains(char.ToLower(userCharakter))
                   )
                    {
                        Console.WriteLine("Already guessed charakter!!");
                        Console.WriteLine();
                        //----------------------------------------------------------
                        Console.WriteLine("Your guessed Word is: ");
                        Console.WriteLine(guessedWord);
                        //----------------------------------------------------------
                        Console.Write("Already guessed true Charakters:");
                        Console.WriteLine(guessedTrueCharakters);
                        //----------------------------------------------------------
                        Console.Write("Already guessed false Charakters:");
                        Console.WriteLine(guessedFalseCharakters);
                        //----------------------------------------------------------
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {

                        if (wort.Contains(char.ToUpper(userCharakter)) || wort.Contains(char.ToLower(userCharakter)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("----------");
                            Console.WriteLine("Well Done!");
                            Console.WriteLine();
                            int i = 0;
                            if (wort.Contains(char.ToUpper(userCharakter)))
                            {
                                for (i = 0; i < wort.Length; i++)
                                {
                                    if (char.ToUpper(userCharakter) == wort[i])
                                        guessedWord[i] = char.ToUpper(userCharakter);
                                }
                            }
                            //----------------------------------------------------------
                            if (wort.Contains(char.ToLower(userCharakter)))
                            {
                                for (i = 0; i < wort.Length; i++)
                                {
                                    if (userCharakter == wort[i])
                                        guessedWord[i] = userCharakter;
                                }
                            }
                            //----------------------------------------------------------
                            Console.Write("Your guessed Word is: ");
                            Console.WriteLine(guessedWord);
                            //----------------------------------------------------------
                            guessedTrueCharakters[counterGuessedTrueCharakters] = char.ToLower(userCharakter);
                            Console.Write("Already guessed true Charakters: ");
                            Console.WriteLine(guessedTrueCharakters);
                            counterGuessedTrueCharakters++;
                            //----------------------------------------------------------
                            if (guessedWord.ToString() == wort)
                            {
                                wordComplete = true;
                            }

                            Console.ReadLine();
                            Console.Clear();

                        }
                        else
                        {
                            if (error == true)
                            {
                                Console.WriteLine("You made a mistake!");
                                error = false;
                                Thread.Sleep(1000);
                            }
                            //----------------------------------------------------------
                            else
                            {
                                Console.WriteLine("What a pity!");
                                Console.WriteLine("Your Charakter is not in the Word!");
                                counter++;
                                guessedFalseCharakters[counterGuessedFalseCharakters] = char.ToLower(userCharakter);
                                counterGuessedFalseCharakters++;

                                if (guessedWord.ToString() == wort)
                                {
                                    wordComplete = true;
                                }

                                Console.ReadLine();
                            }
                            Console.Clear();
                        }
                        Console.Clear();
                    }
                }Console.Clear();
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
                    else Environment.Exit(0);
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
                    else Environment.Exit(0);
                    //--------------------------------------------------------------------------------------------------------
                    Console.ReadLine();

                }
            
        }
        static int Cheat(int counter)
        {
            int newCounter = counter;
            Console.WriteLine("You opened the Cheat Console!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("You can do these things:");
            Console.WriteLine("- Change counter?");
            Console.WriteLine("- Show Word");
            string cheatOptions = Console.ReadLine();
            switch (cheatOptions)
            {
                case ("Change Counter"):
                    Console.Write("Please type in your new Counter: ");
                    newCounter = Convert.ToInt32(Console.ReadLine());
                    break;
                case ("Show Word"):
                    Console.WriteLine("The word is:" + wort);
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Unknown!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Cheat(counter);
                    break;
            }
           
            return newCounter;
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
