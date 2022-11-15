namespace NextTwentyLeapYearTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            LeapYear ly =new LeapYear();
            ly.PrintColorMessage(ConsoleColor.DarkCyan, "**********A Program That Prints Next 20 Leap Years********");
            ly.GetAppInfo();
            ly.CalculateLeapYear();
            Console.ReadLine();
           
        }
    }

    class LeapYear
    {
        //data field variables
        public int count = 0;
        public int presentYear = 0;


        //default constructor
        public LeapYear(){}

      
       
            //method
       public void CalculateLeapYear()
            {

            while (true)
            {
                Console.WriteLine("Enter a Year:");
                if (int.TryParse(Console.ReadLine(), out presentYear))
                {
                    break;
                }
                else
                {
                    // if the parse was unsuccessful, display an error message and try again
                    PrintColorMessage(ConsoleColor.Red, "Invalid Year. Try again.");
                }
                
            }

              //if (presentYear % 4 != 0)
               Console.WriteLine($"Although {presentYear} is not a leap year!");
               Console.WriteLine("The next 20 leap years from " + presentYear.ToString() + " are :");


            while (count < 20)
            {
                if ((presentYear % 4 == 0) && (presentYear % 100 != 0) || (presentYear % 400 == 0))
                {
                    //print success message
                    PrintColorMessage(ConsoleColor.Yellow, presentYear.ToString());
                    count++;
                }

                presentYear++;
            }
        }

        //Get and display app Info method
        public void GetAppInfo()
        {
            // Set app vars
            string appName = "Next 20 Leap Years";
            string appVersion = "1.0.0";
            string appAuthor = "kendrck";

            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;


            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            //reset text color
            Console.ResetColor();
        }

        public void PrintColorMessage(ConsoleColor color, string message)
        {
            //tell user it is not a valid year
            Console.ForegroundColor = color;

            //tell user its not a number
            Console.WriteLine(message);

            //reset text color
            Console.ResetColor();
        }
    }
}