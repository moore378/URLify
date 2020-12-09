using System;

/// <summary>
/// Write a method to replace all spaces in a string with '%20'. 
/// You may assume that the string has sufficient space at the end to 
/// hold the additional characters, and that you are given the "true" 
/// length of the string.
/// 
/// EXAMPLE
/// Input:     "Mr John Smith    ", 13
/// Output:    "Mr%20John%20Smith"
/// </summary>
namespace URLify
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Mr John Smith    ";
            Console.WriteLine(s);

            Console.WriteLine(Urlify2(s));
        }

        public static string Urlify1(string s)
        {
            return s.Replace(" ", "%20");
        }

        /// <summary>
        /// Using the performance from string.Create() to create the new string. This uses Span<T>.
        /// 
        /// This is only possible with .NET 5.0 Core. The string functionality is not possible in .NET Framework.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Urlify2(string s)
        {
            string rs;
            int position = 0;
            rs = String.Create(s.Length, s.ToCharArray(), (chars, buf) =>
            {
                for (int i = 0; position < chars.Length; i++)
                {

                    if (buf[i] == ' ')
                    {
                        
                        chars[position++] = '%';
                        chars[position++] = '2';
                        chars[position++] = '0';
                    }                        
                    else
                        chars[position++] = buf[i];
                }
            });

            return rs;
        }
    }
}
