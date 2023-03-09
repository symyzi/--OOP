using Isu.Exceptions;

namespace Isu.Services.Parsing
{
    internal class ParseGroupNumber
    {
        public static int? TryParse(string groupName)
        {
            string str = groupName.Substring(3, 2);
            if (int.TryParse(str, out int number))
            {
               if (number is < 0 or > 50)
                    return null;
               return number;
            }
            else
            {
                throw new InvalidGroupNameException(groupName);
            }
        }
    }
}
