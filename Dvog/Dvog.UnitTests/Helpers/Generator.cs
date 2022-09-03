using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvog.UnitTests.Helpers
{
    public static class Generator
    {
        public static string GenerateString(int lengthString)
        {
            string result = String.Empty;

            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuwxyz".ToCharArray();
            char[] numbers = "0123456789".ToCharArray();
            char[] symbols = ";.,-_".ToCharArray();

            List<char> list = new List<char>();
            list.AddRange(letters);
            list.AddRange(numbers);
            list.AddRange(symbols);

            Random rand = new Random();

            for (int i = 0; i < lengthString; i++)
            {
                result += list[rand.Next(0, list.Count - 1)];
            }

            return result;
        }
    }
}
