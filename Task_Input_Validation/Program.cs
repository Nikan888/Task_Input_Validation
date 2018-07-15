using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_Input_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            string testStringFilePath1 = "c:\\folder\\file.txt";
            string testStringFilePath2 = "c:\\folder\\fileWithoutExtension";
            string testStringURL1 = "http://www.google.com";
            string testStringURL2 = "hp://ww.google.com";
            string testStringEmail1 = "ma1a@hostname.com";
            string testStringEmail2 = "ma1a@hostname.com9";

            ValidateEmail(testStringEmail1);
            ValidateEmail(testStringEmail2);
            ValidateURL(testStringURL1);
            ValidateURL(testStringURL2);
            ValidateFilePath(testStringFilePath1);
            ValidateFilePath(testStringFilePath2);

            Console.ReadKey();
        }

        static void ValidateEmail(string input)
        {
            if (IsValidEmailRegEx(input))
                Console.WriteLine(@"Email '{0}' is valid", input);
            else Console.WriteLine(@"Email '{0}' is invalid", input);
        }

        static void ValidateURL(string input)
        {
            if (IsValidURLRegEx(input))
                Console.WriteLine(@"URL '{0}' is valid", input);
            else Console.WriteLine(@"URL '{0}' is invalid", input);
        }

        static void ValidateFilePath(string input)
        {
            if (IsValidFilePathRegEx(input))
                Console.WriteLine(@"File path '{0}' is valid", input);
            else Console.WriteLine(@"File path '{0}' is invalid", input);
        }

        static bool IsValidEmailRegEx(string email)
        {
            Match match = Regex.Match(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return match.Success;
        }

        static bool IsValidURLRegEx(string url)
        {
            Match match = Regex.Match(url, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return match.Success;
        }

        static bool IsValidFilePathRegEx(string path)
        {
            Match match = Regex.Match(path, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");
            return match.Success;
        }
    }
}
