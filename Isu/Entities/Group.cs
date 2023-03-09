using Isu.Exceptions;
using Isu.Models;

namespace Isu.Entities;

public class Group
{
    private List<Student> _students;

    public Group(string groupName, int maxValueStudents)
    {
        NullOrEmptyGroupName(groupName);
        ValidationMaxValueStudents(groupName, maxValueStudents);

        GroupName = new GroupName(groupName);
        MaxValueStudents = maxValueStudents;
        _students = new List<Student>();
    }

    public int MaxValueStudents { get; set; }
    public GroupName GroupName { get; set; }
    public Guid Id { get; } = Guid.NewGuid();
    public IReadOnlyList<Student> Students => _students;
    public void StudentLimitReached()
    {
        if (Students.Count >= MaxValueStudents)
            throw new GroupOverflowException(GroupName);
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
    }

    private static void ValidationMaxValueStudents(string groupName, int maxValueStudents)
    {
        if (maxValueStudents < 1)
            throw new ArgumentOutOfRangeException(groupName);
    }

    private static void NullOrEmptyGroupName(string groupName)
    {
        if (string.IsNullOrEmpty(groupName))
        {
            throw new NullGroupNameException();
        }
    }
}