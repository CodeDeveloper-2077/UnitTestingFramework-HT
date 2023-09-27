using System.Data;
using System.Reflection;

namespace UnitTesting
{
    public class CharsCounter
    {
        public int CountDifferentChars(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str == string.Empty)
            {
                throw new ArgumentException($"{nameof(str)} can't be empty", nameof(str));
            }

            int counter = 1;
            List<int> maximumLength = new List<int>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
                {
                    counter++;
                }
                else
                {
                    maximumLength.Add(counter);
                    counter = 1;
                }
            }

            maximumLength.Add(counter);

            return maximumLength.Max();
        }

        public int CountSameChars(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str == string.Empty)
            {
                throw new ArgumentException($"{nameof(str)} can't be empty", nameof(str));
            }

            int counter = 1;
            List<int> maximumLength = new List<int>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    counter++;
                }
                else
                {
                    maximumLength.Add(counter);
                    counter = 1;
                }
            }

            maximumLength.Add(counter);

            return maximumLength.Max();
        }

        public int CountSameDigits(string str)
        {
            int counter = 1;

            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str == string.Empty)
            {
                throw new ArgumentException($"{nameof(str)} cannot be empty", nameof(str));
            }

            if (!str.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException($"{nameof(str)} must contain at least one digit!", nameof(str));
            }

            List<int> maximumLength = new List<int>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                char c1 = str[i];
                char c2 = str[i + 1];
                if (c1 == c2 && char.IsDigit(c1) && char.IsDigit(c2))
                {
                    counter++;
                }
                else
                {
                    maximumLength.Add(counter);
                    counter = 1;
                }
            }

            maximumLength.Add(counter);

            return maximumLength.Max();
        }
    }
}