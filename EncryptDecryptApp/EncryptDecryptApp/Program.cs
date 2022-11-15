using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            EncryptDecrypt ED = new EncryptDecrypt();
            ED.PrintColorMessage(ConsoleColor.Cyan, "**********Welcome to the DecryptEncrypt App********");
            ED.PrintColorMessage(ConsoleColor.DarkMagenta,"Please Enter words to Encrypt:");
            string text = Console.ReadLine();
            Console.WriteLine();
            var encryptedText = ED.EncryptPlainTextToCipherText(text);
            var decryptedText = ED.DecryptCipherTextToPlainText(encryptedText);
            ED.PrintColorMessage(ConsoleColor.Yellow,"EncryptedText = " + encryptedText);
            ED.PrintColorMessage(ConsoleColor.Blue, "Hit the enter key to decrypt it to the original text");
            Console.ReadKey(true);
            ED.PrintColorMessage(ConsoleColor.Yellow, "DecryptedText = " + decryptedText);
            Console.ReadLine();

        }

        class EncryptDecrypt
        {
            //This security key should be very complex and Random for encrypting the text. This playing vital role in encrypting the text.
            public const string SecurityKey = "ComplexKeyHere_12121";
            
            
            //constructors
            public EncryptDecrypt(){}



            //methods
            public  string EncryptPlainTextToCipherText(string PlainText)
            {
                // Getting the bytes of Input String.
                byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

                MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
                //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
                byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
                //De-allocatinng the memory after doing the Job.
                objMD5CryptoService.Clear();

                var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
                //Assigning the Security key to the TripleDES Service Provider.
                objTripleDESCryptoService.Key = securityKeyArray;
                //Mode of the Crypto service is Electronic Code Book.
                objTripleDESCryptoService.Mode = CipherMode.ECB;
                //Padding Mode is PKCS7 if there is any extra byte is added.
                objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


                var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
                //Transform the bytes array to resultArray
                byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
                objTripleDESCryptoService.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }


            //This method is used to convert the Encrypted/Un-Readable Text back to readable  format.
            public  string DecryptCipherTextToPlainText(string CipherText)
            {
                byte[] toEncryptArray = Convert.FromBase64String(CipherText);
                MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

                //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
                byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
                objMD5CryptoService.Clear();

                var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
                //Assigning the Security key to the TripleDES Service Provider.
                objTripleDESCryptoService.Key = securityKeyArray;
                //Mode of the Crypto service is Electronic Code Book.
                objTripleDESCryptoService.Mode = CipherMode.ECB;
                //Padding Mode is PKCS7 if there is any extra byte is added.
                objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

                var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
                //Transform the bytes array to resultArray
                byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                objTripleDESCryptoService.Clear();

                //Convert and return the decrypted data/byte into string format.
                return UTF8Encoding.UTF8.GetString(resultArray);
            }


            //Get and display app Info
            public void GetAppInfo()
            {
                // Set app vars
                string appName = "EncryptDecrypt";
                string appVersion = "1.0.0";
                string appAuthor = "kendrck";

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;


                Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

                //reset text color
                Console.ResetColor();
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