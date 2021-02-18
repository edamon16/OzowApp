using System;

namespace Sorting
{
    public class SortingFacade
    {
        public int[] Sorting(int[] array)
        {
            if (array.Length == 0)
            {
                return new int[] { };
            }



            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (var i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] <= array[i + 1]) continue;
                    Swap(i, i + 1, array);
                    isSorted = false;
                }
            }

            return array;
        }



        public string Sorting(string[] array)
        {
           
            var charValue = ConvertToChar(array);

            if (charValue.Length == 0)
            {
                return string.Empty;
            }

            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (var i = 0; i < charValue.Length - 1; i++)
                {
                    if (charValue[i] <= charValue[i + 1]) continue;
                    Swap(i, i + 1, charValue);
                    isSorted = false;
                }
            }
            string result = new string(charValue);
            
            return result.Replace(",","");

        }

        public static void Swap(int i, int j, int[] array)
        {
            int tempPosition = array[j];
            array[j] = array[i];
            array[i] = tempPosition;
        }

        public static void Swap(int i, int j, char[] array)
        {
            char tempPosition = array[j];
            array[j] = array[i];
            array[i] = tempPosition;
        }

        public static char[] ConvertToChar(string[] array)
        {
            char[] charater = string.Join(string.Empty, array).ToLower().ToCharArray();
            return charater;
        }

      
    }
}