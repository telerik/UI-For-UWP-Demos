using System;
using System.Linq;

namespace QSF.Infrastructure
{
    public static class StringExtensions
    {
        /// <summary>
        /// Shows whether a string contains a search query, using an ignore-case comparison.
        /// </summary>
        /// <param name="text">The string object to search on.</param>
        /// <param name="searchText">The text to search for.</param>
        /// <returns></returns>
        public static bool ContainsLowerCase(this string text, string searchText)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return text.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        /// <summary>
        /// Extension method that gets the rest of the string, after the last occurence of a search term.<br/>
        /// Ex. "abcdefgh".GetTextAfterLastOccurence("e") returns "fgh".
        /// </summary>
        /// <param name="text">The string object to search on.</param>
        /// <param name="textToFind">The text whose last occurence to search for.</param>
        /// <returns>Returns the rest of the text after the last occurence.</returns>
        public static string GetTextAfterLastOccurence(this string text, string textToFind)
        {
            return StringExtensions.GetTextAfterLastOccurence(text, textToFind, false);
        }

        /// <summary>
        /// Gets the rest of the string, after the last occurence of a search term, possibly skipping the next character.<br/>
        /// Ex. "abcdefgh".GetTextAfterLastOccurence("e", true) returns "gh".
        /// Ex. "abcdefgh".GetTextAfterLastOccurence("e", false) returns "fgh".
        /// </summary>
        /// <param name="text">The string object to search on.</param>
        /// <param name="textToFind">The text whose last occurence to search for.</param>
        /// <param name="skipCharAfterEndOfLastOccurence">Whether to skip the character right after end of last occurence.</param>
        /// <returns>Returns the rest of the text after the last occurence.</returns>
        public static string GetTextAfterLastOccurence(this string text, string textToFind, bool skipCharAfterEndOfLastOccurence)
        {
            if (string.IsNullOrEmpty(textToFind))
            {
                return string.Empty;
            }

            int lastIndex = text.LastIndexOf(textToFind);
            if (lastIndex == -1)
            {
                return string.Empty;
            }

            int position = lastIndex + textToFind.Length;
            if (skipCharAfterEndOfLastOccurence)
            {
                position++;
            }

            return text.Substring(position);
        }
    }
}