using LinqPractices.DbOperations;
using LinqPractices.Entities;

namespace LinqPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Find()
            Console.WriteLine("***** Find *****");
            var student = _context.Students.Where(student => student.StudentId ==1).FirstOrDefault();  //ilk veriyi getirdi!

        }
    }
}