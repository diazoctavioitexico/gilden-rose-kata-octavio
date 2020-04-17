namespace MyGildenRose.ExtensionMethods
{
    using System.Collections.Generic;

    public static class StringExtensions
    {
        public static bool NotIn(this string str, List<string> stringsToCompare)
        {
            bool found = false;

            foreach (var myString in stringsToCompare)
            {
                if (str.Contains(myString))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
