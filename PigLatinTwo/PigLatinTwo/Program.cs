namespace PigLatinTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //we create an instance of our class
            RetrieveWordInPigLatin pl = new RetrieveWordInPigLatin();
            pl.PrintColorMessage(ConsoleColor.Yellow, "******************PIGLATIN TRANSLATE******************");
            pl.GetAppInfo();
            Console.WriteLine();
            pl.CallRetrieveWordInPigLatin();
            Console.ReadLine();
        }
    
    
    }
       
    class RetrieveWordInPigLatin
        {
            //data field variables
            public string Wordsentence;
            const string vowels = "AEIOUaeio";


            //constructors


            //default constructor
            public RetrieveWordInPigLatin(){}

            //custom constructor
            public RetrieveWordInPigLatin(string sentence)
            {
                Wordsentence = sentence;

            }


            //methods
            public string CanRetrieveWord( string sentence)
            {
                var returnSentence = "";
                foreach (var word in sentence.Split())
                {
                    var firstLetter = word.Substring(0, 1);
                    var restOfWord = word.Substring(1, word.Length - 1);
                    var currentLetter = vowels.IndexOf(firstLetter, StringComparison.Ordinal);

                    if (currentLetter == -1)
                    {
                        returnSentence += restOfWord + firstLetter + "ay ";
                    }
                    else
                    {
                        returnSentence += word + "way ";
                    }
                }
                return returnSentence;

            }

        //method
        public void CallRetrieveWordInPigLatin()
        {

            PrintColorMessage(ConsoleColor.DarkCyan, "Enter a sentence to convert to PigLatin:");
            string sentence = Console.ReadLine();
            var pigLatin = CanRetrieveWord(sentence);
            PrintColorMessage(ConsoleColor.Yellow, pigLatin);

            //---------------**CONVERT PIG LATIN TO ENGLISH**---------------------------//
            PrintColorMessage(ConsoleColor.DarkCyan, "Press Enter to flip the sentence back.");
            Console.ReadKey(true);
            string clonedString = null;
            clonedString = (String)sentence.Clone();
            PrintColorMessage(ConsoleColor.Yellow, clonedString);
            Console.ReadLine();

        }
        //Get and display app Info method
        public void GetAppInfo()
        {
            // Set app vars
            string appName = "Pig Latin";
            string appVersion = "1.0.0";
            string appAuthor = "kendrck";

            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;


            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            //reset text color
            Console.ResetColor();
        }


        // print color message method
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
