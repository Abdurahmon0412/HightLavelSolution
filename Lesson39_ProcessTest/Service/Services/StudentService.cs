using Lesson39_ProcessTest.Domain.Entities;
using Lesson39_ProcessTest.Service.Interfaces;

namespace Lesson39_ProcessTest.Service.Services
{
    internal class StudentService : IStudentService
    {
        private List<Student> _students;
        public StudentService()
        {
            _students = new List<Student>();
        }
        public Student Create(Student student)
        {
            _students.Add(student);
            return student;

        }

        public bool Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            string source = File.ReadAllText("student.db");
            List<Student> students = new List<Student>();
            return students;
        }

        public Student GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
