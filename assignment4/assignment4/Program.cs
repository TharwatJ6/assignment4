using System.Reflection.Emit;
using System.Text;
using System.Transactions;

namespace assignment4
{
    internal class Program
    {
        static double CalculateAverage(List<double> grades)
        {
            double sum = 0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            return sum / grades.Count;
        }
        static GradeLevel DetermineGradeLevel(double average)
        {
            if(average>=0 && average <= 20)
            {
                return GradeLevel.Freshman;
            }
            else if(average > 20 && average <= 40)
            {
                return GradeLevel.Sophomore;
            }
            else if(average > 40 && average <= 60)
            {
                return GradeLevel.Junior;
            }
            else
            {
                return GradeLevel.Senior;
            }
        }
        enum GradeLevel
        {
            Freshman,
            Sophomore,
            Junior,
            Senior
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            Dictionary<string, string> levels = new Dictionary<string, string>();
            double grade;
            int numStudents;
            Console.Write("Enter the number of students:  ");
            while (!int.TryParse(Console.ReadLine(), out numStudents) || numStudents <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for the number of students:");
                Console.Write("Enter the number of students:  ");
            }
            for (int i = 0; i < numStudents; i++)
            {
                Console.Write($"Enter the name of student {i + 1}: ");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                    Console.Write($"Enter the name of student {i + 1}: ");
                    name = Console.ReadLine();
                }
                Console.WriteLine("Enter his grades: ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Grade {j + 1}: ");
                    while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 100 for the grade.");
                        Console.Write($"Grade {j + 1}: ");
                    }
                    if (!students.ContainsKey(name))
                    {
                        students[name] = new List<double>();
                    }
                    students[name].Add(grade);
                }
            }
            foreach (var student in students)
            {
                double average = CalculateAverage(student.Value);
                GradeLevel level = DetermineGradeLevel(average);
                levels[student.Key] = level.ToString();
            }
            Console.WriteLine("\nStudent Grades and Levels:");
            foreach (var student in students)
            {
                foreach (var level in levels)
                {
                    if (level.Key == student.Key)
                    {
                        Console.WriteLine($"Student: {student.Key}, Grades: {string.Join(", ", student.Value)}, Average: {CalculateAverage(student.Value)}, Grade Level: {level.Value} ");
                    }
                }
            }
        }
    }
}
