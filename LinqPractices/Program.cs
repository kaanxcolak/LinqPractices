using LinqPractices.DbOperations;
using LinqPractices.Entities;
using Microsoft.Extensions.Logging;

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
            Console.WriteLine("***** FirstOrDefault *****");
            student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
            Console.WriteLine(student.Name);

            student = _context.Students.FirstOrDefault(x => x.Surname == "Arda"); //First veya Default yaparız çünkü veri yoksa null döndürecek çünkü default da demiş oluyoruz aynı zamanda!
            Console.WriteLine(student.Name);

            //SingleOrDefault()
            Console.WriteLine();
            Console.WriteLine("***** SingleOrDefault *****");
            student = _context.Students.SingleOrDefault(student => student.Name == "Deniz"); //Tek veri döndüreceğini anlıyoruz!

            //ToList()
            Console.WriteLine();
            Console.WriteLine("***** ToList *****");
            var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);

            //OrderBy
            Console.WriteLine();
            Console.WriteLine("***** OrderBy *****");

            students = _context.Students.OrderBy(x=>x.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + "-"+ st.Name+ "-" + st.Surname);
            }

            //OrderByDescending         --> verilen kolonu descending olarak sıralar
            Console.WriteLine();
            Console.WriteLine("***** OrderByDescending *****");

            students = _context.Students.OrderByDescending(x => x.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + "-" + st.Name + "-" + st.Surname);
            }


            //Anonymous Object Result
            Console.WriteLine();
            Console.WriteLine("***** Anonymous Object Result *****");

            var anonymousObject = _context.Students.Where(x => x.ClassId == 2).Select(x => new { Id = x.StudentId, FullName = x.Name + " " + x.Surname });

            foreach (var obj in anonymousObject)
            {
                Console.WriteLine(obj.Id + "-" + obj.FullName);
            }
        }
    }
}