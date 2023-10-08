namespace UnitTesting
{
    public class CharsCounter
    {
        public int CountDifferentChars(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String is null or empty!", nameof(str));
            }

            int counter = 1;
            List<int> maximumLengths = new List<int>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
                {
                    counter++;
                }
                else
                {
                    maximumLengths.Add(counter);
                    counter = 1;
                }
            }

            maximumLengths.Add(counter);

            return maximumLengths.Max();
        }

        public int CountSameChars(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String is null or empty!", nameof(str));
            }

            int counter = 1;
            List<int> maximumLengths = new List<int>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    counter++;
                }
                else
                {
                    maximumLengths.Add(counter);
                    counter = 1;
                }
            }

            maximumLengths.Add(counter);

            return maximumLengths.Max();
        }

        public int CountSameDigits(string str)
        {
            int counter = 1;

            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String is null or empty!", nameof(str));
            }

            if (!str.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException($"String must contain at least one digit!", nameof(str));
            }

            List<int> maximumLengths = new List<int>();

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
                    maximumLengths.Add(counter);
                    counter = 1;
                }
            }

            maximumLengths.Add(counter);

            return maximumLengths.Max();
        }
    }
}