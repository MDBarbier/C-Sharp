using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensions
{
    public static class ExtensionMethods
    {
        public static int WordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?' },StringSplitOptions.RemoveEmptyEntries);

            int wordCount = userString.Length;

            return wordCount;
        }

        public static int TotalCharWithoutSpace(this string str)
        {
            int totalCharWithoutSpace = 0;
            string[] userString = str.Split(' ');
            foreach (string stringValue in userString)
            {
                totalCharWithoutSpace += stringValue.Length;
            }
            return totalCharWithoutSpace;
        }
    }
}
