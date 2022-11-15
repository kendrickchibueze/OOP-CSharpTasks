using System.Security.Cryptography.X509Certificates;

namespace NumberGuessingGameTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an object instance of the Game  class
            Game game = new Game(1,100);
            game.PrintColorMessage(ConsoleColor.DarkCyan, "*************WELCOME TO THE GUESSING GAME**********************");
            //run GetAppInfo function
            game.GetAppInfo();

            //Ask for user name and greet
            game.GreetUser();
           
            game.PlayMyGuessGame();
            Console.ReadLine();
        }

        class Game
        {
            //data field members
            public const bool playAgain = true;
            public int min;
            public int max;
            public int guesses;

            //constructors
            public Game() { } //default constructor


            //custom constructor
            public Game(int minValue, int MaxValue)
            {
                min = minValue;
                max = MaxValue;


            }


            //methods
            public void PlayMyGuessGame()
            {

                while (playAgain)
                {

                    //Create a new Random object
                    Random random = new Random();

                    //init correct number
                    int correctNumber = random.Next(min, max + 1);

                    //init guess var
                    int guess = 0;

                    while (guess != correctNumber)
                    {

                        //ask user for number
                        Console.WriteLine("Guess a number between 1 and 100");


                        //get users input
                        string input = Console.ReadLine();

                        //make sure its a number
                        if (!int.TryParse(input, out guess))
                        {
                            //print error message
                            PrintColorMessage(ConsoleColor.Red, "Please use an actual number");

                            //keep going
                            continue;
                        }

                        //cast to int and put in guess
                        guess = Int32.Parse(input);

                        //match guess to correct number
                        if (guess > correctNumber)
                        {

                            //print error message
                            PrintColorMessage(ConsoleColor.Blue, "guess too high");

                        }
                        else if (guess < correctNumber)
                        {
                            PrintColorMessage(ConsoleColor.Yellow, "guess too low");
                        }
                        guesses++;
                    }
                    //print success message
                    PrintColorMessage(ConsoleColor.Yellow, "You Win!!!");
                    Console.WriteLine("Number : " + correctNumber);
                    Console.WriteLine("Guesses: " + guesses);


                    //Ask to play again
                    Console.WriteLine("Play again? [Y or  N]");


                    //Get answer
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        continue;

                    }
                    else if (answer == "N")
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }


                }

            }

            //Get and display app Info method
            public void GetAppInfo()
            {
                // Set app vars
                string appName = "Number Guesser";
                string appVersion = "1.0.0";
                string appAuthor = "kendrick Bezao";

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;


                Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

                //reset text color
                Console.ResetColor();
            }

            //get user name and greet method
            public void GreetUser()
            {
                //ask users name
                Console.WriteLine("what is your name?");

                //Get user input
                string inputName = Console.ReadLine();
                Console.WriteLine("Hello {0}, let's play game...", inputName);

            }
            // print color message
            public void PrintColorMessage(ConsoleColor color, string message)
            {
                //tell user it is the wrong number
                Console.ForegroundColor = color;

                //tell user its not a number
                Console.WriteLine(message);

                //reset text color
                Console.ResetColor();
            }

        }
    }
}