using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public interface IIsuService
{
    Group AddGroup(string name, int maxValueStudents);
    Student AddStudent(Group group, string? firstName, string? lastName);

    Student GetStudent(Guid id);
    Student? FindStudent(Guid id);
    List<Student> FindStudents(GroupName groupName);
    List<Student> FindStudents(CourseNumber courseNumber);

    Group? FindGroup(GroupName groupName);
    List<Group> FindGroups(CourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}