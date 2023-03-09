using Isu.Exceptions;
using Isu.Services.Parsing;

namespace Isu.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        if (!TryParse(groupName))
        {
            throw new InvalidGroupNameException(groupName);
        }
    }

    public CourseNumber? CourseNumber { get; private set; }
    public int? GroupNumber { get; private set; }
    public string? Specialization { get; private set; }
    public int? Stream { get; private set; }

    public bool TryParse(string groupName)
    {
        if (groupName.Length is < 5 or > 6)
        {
            return false;
        }
        else
        {
            Specialization = ParseSpecialization.TryParse(groupName[0]);
            if (groupName[1] != '3')
                return false;
            GroupNumber = ParseGroupNumber.TryParse(groupName);
            CourseNumber = ParseCourseNumber.TryParse(groupName[2]);
            Stream = null;
            if (groupName.Length > 5)
            {
                Stream = ParseStream.TryParse(groupName[5].ToString());
            }

            return CourseNumber != null && GroupNumber != null && Specialization != null;
        }
    }
}