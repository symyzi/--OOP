namespace Isu.Services.Parsing
{
    internal class ParseStream
    {
        public static int? TryParse(string str)
        {
            int number = int.Parse(str);
            if (number is < 1 or > 3)
                return null;
            return number;
        }
    }
}
