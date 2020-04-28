namespace MyGildenRose.ExtensionMethods
{

    public static class StringExtensions
    {
        public static bool In(this string str, params string[] stringsToCompare)
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
