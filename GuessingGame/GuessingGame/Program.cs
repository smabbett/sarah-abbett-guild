using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer = 0;
            int playerGuess;
            string playerInput;
            string playerName;
            string playLevel;
            int guesscount;
            int level = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What is your name? ");
            playerName = Console.ReadLine();
            do
            {

                guesscount = 0;

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Select your level of play, {0}: Easy(E), Normal(N) or Hard(H)", playerName);
                    playLevel = Console.ReadLine().ToUpper();
                    
                    if (playLevel == "E")
                    {
                        Random r = new Random();
                        theAnswer = r.Next(1, 6);
                        level = 5;
                        break;
                    }
                    else if (playLevel == "N")
                    {
                        Random r = new Random();
                        theAnswer = r.Next(1, 21);
                        level = 20;
                        break;
                    }
                    else if (playLevel == "H")
                    {
                        Random r = new Random();
                        theAnswer = r.Next(1, 51);
                        level = 50;
                        break;
                    }                 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That is not a valid selection. Please try again.");

                    }
                }
                



                do
                {

                    // get player input
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter your guess, {0}(1-{1}): ", playerName, level);
                    playerInput = Console.ReadLine().ToUpper();

                    if (playerInput == "Q")
                    {
                        break;
                    }



                    //attempt to convert the string to a number
                    if (int.TryParse(playerInput, out playerGuess))
                    {
                        if (playerGuess > level)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"That number is not in the valid range. Try again!");
                        }
                        else
                        {

                        
                        guesscount += 1;

                        if (playerGuess == theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{theAnswer} was the number.  You Win, {playerName}!");
                            if (guesscount == 1)
                            {
                                Console.WriteLine($"Congratulations, {playerName}! You guessed it on the first try!");
                            }
                            else
                            {
                                Console.WriteLine($"It took you {guesscount} guesses, {playerName}.");
                            }

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press Q to quit. ");
                            playerInput = Console.ReadLine().ToUpper();
                                if (playerInput == "Q")
                                {
                                    break;
                                }

                            }
                        else
                        {
                            if (playerGuess > theAnswer)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Your guess was too High, {0}!", playerName);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Your guess was too Low, {0}!", playerName);
                            }
                        }
                    }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That wasn't a number, {0}!", playerName);
                    }


                } while (playerGuess != theAnswer);


            } while (playerInput != "Q");




        }
    }
}
