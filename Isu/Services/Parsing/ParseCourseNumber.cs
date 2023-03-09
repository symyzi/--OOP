using Isu.Models;

namespace Isu.Services.Parsing
{
    internal class ParseCourseNumber
    {
        private static readonly Dictionary<char, CourseNumber> _courses = new Dictionary<char, CourseNumber>()
        {
            { '1', CourseNumber.First },
            { '2', CourseNumber.Second },
            { '3', CourseNumber.Third },
            { '4', CourseNumber.Fourth },
        };
        public static CourseNumber? TryParse(char number)
        {
            if (!_courses.ContainsKey(number))
                return null;
            return _courses[number];
        }
    }
}
