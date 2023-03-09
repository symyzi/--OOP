using Isu.Exceptions;
using Isu.Models;

namespace Isu.Entities;

public class Student
{
    public Student(string? firstName, string? lastName, GroupName groupName)
    {
        NullOrEmptyStudentName(firstName, lastName);

        FirstName = firstName;
        LastName = lastName;
        GroupName = groupName;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid Id { get; } = Guid.NewGuid();
    public GroupName GroupName { get; set; }

    private static void NullOrEmptyStudentName(string? firstName, string? lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            throw new NullStudentNameException();
        }
    }
}