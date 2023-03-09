using Isu.Models;

namespace Isu.Exceptions
{
    public class GroupOverflowException : Exception
    {
        public GroupOverflowException(GroupName groupName)
        {
            GroupName = groupName;
        }

        public GroupName GroupName { get; set; }
    }
}
