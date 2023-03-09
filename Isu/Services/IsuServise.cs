using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private readonly List<Student> _students;
    private readonly List<Group> _groups;
    private int _lastGroupId;
    private int _lastStudentId;
    public IsuService()
    {
        _students = new List<Student>();
        _groups = new List<Group>();
    }

    public Group AddGroup(string name, int maxValueStudents)
    {
        var group = new Group(name, maxValueStudents);
        _groups.Add(group);
        _lastGroupId++;
        return group;
    }

    public Student AddStudent(Group group, string? firstName, string? lastName)
    {
        if (group == null)
            throw new NullGroupException();

        group.StudentLimitReached();

        var student = new Student(firstName, lastName, group.GroupName);
        _students.Add(student);
        group.AddStudent(student);
        _lastStudentId++;
        return student;
    }

    public Student GetStudent(Guid id)
    {
        Student? findStudent = FindStudent(id);
        if (findStudent == null)
        {
            throw new StudentNotFoundException();
        }
        else
        {
            return findStudent;
        }
    }

    public Student? FindStudent(Guid id) => _students.SingleOrDefault(student => id == student.Id);

    public List<Student> FindStudents(GroupName groupName)
    {
        Group? findGroup = FindGroup(groupName);

        if (findGroup == null)
        {
            throw new GroupNotFoundException();
        }
        else
        {
            return (List<Student>)findGroup.Students;
        }
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        var findStudents = new List<Student>();
        List<Group> findGroups = FindGroups(courseNumber);
        foreach (Group findGroup in findGroups)
        {
            findStudents.AddRange(findGroup.Students);
        }

        return findStudents;
    }

    public Group? FindGroup(GroupName groupName) => _groups.Find(x => x.GroupName == groupName);

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        return _groups.Where(group => group.GroupName.CourseNumber == courseNumber).ToList();
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        newGroup.StudentLimitReached();

        Group? oldGroup = FindGroup(student.GroupName);
        oldGroup?.RemoveStudent(student);
        student.GroupName = newGroup.GroupName;
        newGroup.AddStudent(student);
    }
}