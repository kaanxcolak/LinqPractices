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
            student = _context.Students.Find(1);
            Console.WriteLine(student.Name);

            //FirstOrDefault()
            Console.WriteLine();
            Console.WriteLine("***** Find *****");
            student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
            Console.WriteLine(student.Name);

            student = _context.Students.FirstOrDefault(x => x.Surname == "Arda"); //First veya Default yaparız çünkü veri yoksa null döndürecek çünkü default da demiş oluyoruz aynı zamanda!
            Console.WriteLine(student.Name);

            //SingleOrDefault()
            Console.WriteLine();
            Console.WriteLine("***** SingleOrDefault *****");
            student = _context.Students.SingleOrDefault(student => student.Name == "Deniz"); //Tek veri döndüreceğini anlıyoruz!



        }
    }
}