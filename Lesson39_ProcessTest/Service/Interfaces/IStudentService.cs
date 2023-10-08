using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson39_ProcessTest.Domain.Entities;

namespace Lesson39_ProcessTest.Service.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(Student student);
        bool Delete(long Id);
        Student GetById(long id);
        IEnumerable<Student> GetAll();

    }
}
