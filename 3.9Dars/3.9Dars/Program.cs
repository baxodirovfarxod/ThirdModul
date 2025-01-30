
using System.Security.Cryptography.X509Certificates;

namespace _3._9Dars
{
    internal class Program
    {
        public delegate void SwapDelegate(ref int a, ref int b);
        static void Main(string[] args)
        {
            Func<int, int, int, int> func1 = Add;
            Func<int, int, int, int, int> func2 = Multiply;
            Func<double, double, double> func3 = Divide;
            Func<int, int, (int, int)> func4 = SumAndProduct;
            Predicate<int> predicate1 = IsEven;
            Func<string, string, string, string> func5 = ConcatThree;
            Func<string, (string, string)> func6 = GetUpperAndLower;
            Func<string, string, bool> predicate2 = ContainsSubstring;
            Func<string, string> func7 = ReverseString;
            Func<int[], int> func8 = GetMax;
            Func<int[], int> func9 = GetMin;
            Func<int[], int[]> func10 = GetSorted;
            Func<int[], (int, int)> func11 = GetMaxAndMin;
            Func<int[], int, bool> func12 = ContainsElement;
            Func<int, int, int> func13 = GetRandomNumber;
            Func<(int, int, int)> func14 = GetRandomTriple;
            Func<string> func15 = GetCurrentDateTime;
            predicate1 += IsOdd;
            predicate1 += IsPrime;
            Func<double, (double, double)> func16 = GetCircleAreaAndCircumference;
            Func<int[], (int, double)> func17 = SumAndAverage;
            SwapDelegate swapDelegate = Swap;
            Action<string> action1 = PrintMessage;
            Action<int[]> action2 = PrintArray;
            Func<List<int>, List<string>, Dictionary<int, string>> func18 = CreateDictionaryFromList;
        }

        // ✅ Dictionary Functions
        public static Dictionary<int, string> CreateDictionaryFromList(List<int> keys, List<string> values)
        {
            if (keys.Count != values.Count)
                throw new ArgumentException("Keys and values lists must have the same length.");

            return keys.Zip(values, (key, value) => new KeyValuePair<int, string>(key, value))
                       .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public static Dictionary<string, int> CountStringOccurrences(List<string> strings)
        {
            return strings.GroupBy(s => s)
                          .ToDictionary(group => group.Key, group => group.Count());
        }
        public static Dictionary<int, string> FilterDictionary(Dictionary<int, string> dictionary, string filter)
        {
            return dictionary.Where(pair => pair.Value.Contains(filter))
                             .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public static Dictionary<string, int> GetStringLengthDictionary(List<string> strings)
        {
            return strings.ToDictionary(str => str, str => str.Length);
        }

        // 🔄 Swapping & Printing
        public static void Swap(ref int a, ref int b) { int temp = a; a = b; b = temp; }
        public static void PrintMessage(string message) => Console.WriteLine(message);
        public static void PrintArray(int[] numbers) => Console.WriteLine(string.Join(", ", numbers));

        // 🚀 Tuple-Based Functions
        public static (double, double) GetCircleAreaAndCircumference(double radius)
        {
            double area = Math.PI * radius * radius;
            double circumference = 2 * Math.PI * radius;
            return (area, circumference);
        }
        public static (int sum, double average) SumAndAverage(int[] numbers)
        {
            int sum = numbers.Sum();
            double avg = numbers.Average();
            return (sum, avg);
        }

        // 💡 Boolean & Conditions
        public static bool IsOdd(int num) => num % 2 != 0;
        public static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i * i <= num; i++)
                if (num % i == 0) return false;
            return true;
        }

        // ⚡️ Random & Utility
        public static int GetRandomNumber(int min, int max) => new Random().Next(min, max);
        public static (int, int, int) GetRandomTriple() => (new Random().Next(1, 100), new Random().Next(1, 100), new Random().Next(1, 100));
        public static string GetCurrentDateTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // ✅ Array/List Functions
        public static int GetMax(params int[] numbers) => numbers.Max();
        public static int GetMin(params int[] numbers) => numbers.Min();
        public static int[] GetSorted(int[] numbers) => numbers.OrderBy(n => n).ToArray();
        public static (int max, int min) GetMaxAndMin(int[] numbers) => (numbers.Max(), numbers.Min());
        public static bool ContainsElement(int[] numbers, int value) => numbers.Contains(value);

        // 🔥 String Manipulation
        public static string ConcatThree(string s1, string s2, string s3) => $"{s1}{s2}{s3}";
        public static (string upper, string lower) GetUpperAndLower(string str) => (str.ToUpper(), str.ToLower());
        public static bool ContainsSubstring(string main, string sub) => main.Contains(sub);
        public static string ReverseString(string str) => new string(str.Reverse().ToArray());

        // 🚀 Math & Number Functions
        public static int Add(int a, int b, int c) => a + b + c;
        public static int Multiply(int a, int b, int c, int d) => a * b * c * d;
        public static double Divide(double a, double b) => b != 0 ? a / b : double.NaN;
        public static (int sum, int product) SumAndProduct(int a, int b) => (a + b, a * b);
        public static bool IsEven(int num) => num % 2 == 0;
    }
}
