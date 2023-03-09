namespace Isu.Services.Parsing
{
    internal class ParseSpecialization
    {
        private static readonly Dictionary<char, string> Specialization = new Dictionary<char, string>()
        {
            { 'M', "ITiP" },
            { 'P', "PIiKT" },
            { 'R', "SUiR" },
        };

        public static string? TryParse(char str)
        {
            return !Specialization.ContainsKey(str) ? null : Specialization[str];
        }
    }
}
