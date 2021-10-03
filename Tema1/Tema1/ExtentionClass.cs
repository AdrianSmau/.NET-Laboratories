using System;
using System.Text.RegularExpressions;

namespace Tema1
{
    public static class ExtentionClass
    {
        public static string[] SplitIntoWords(this Employee E, string phrase)
        {
            return Regex.Replace(phrase, "[^a-zA-Z0-9% ._]", string.Empty).Split(' '); // We first remove special characters in order to assure we remain with only the array of words
        }
    }
}
