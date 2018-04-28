namespace _01._Students_by_Group
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using MyStudentClass;
    using MySpeciality;

    public class LinqExercises
    {
        public static void Main()
        {
            var listOfStudents = ReadStudentsFromFile("../../../../StudentData.txt");
            var listOfSpecialities = ReadSpecialitieFromFile("../../../../SpecialtyData.txt");

            //FilterStudentsByGroup(listOfStudents);
            //StudentsByFirstAndLastName(listOfStudents);
            //StudentsByAge(listOfStudents);
            //SortStudents(listOfStudents);
            //FilterStudentsByEmailDomain(listOfStudents);
            //FilterStudentsByPhone(listOfStudents);
            //ExcellentStudents(listOfStudents);
            //WeakStudents(listOfStudents);
            //StudentsEnrolled(listOfStudents);
            //GroupByGroup(listOfStudents);
            //StudentsJoinedToSpecialties(listOfStudents, listOfSpecialities);
            //PopulateSpecialityData(listOfStudents);
        }

        private static List<Speciality> ReadSpecialitieFromFile(string path)
        {
            var inputData = File.ReadAllLines(path);

            var listOfSpecialities = new List<Speciality>();

            for (var i = 1; i < inputData.Length; i++)
            {
                var currentLine = inputData[i];

                var currentSpeciality = Speciality.Parse(currentLine);

                listOfSpecialities.Add(currentSpeciality);
            }

            return listOfSpecialities;
        }

        private static void PopulateSpecialityData(List<Student> listOfStudents)
        {
            var listFn = listOfStudents.Select(s => s.Fn).ToArray();

            var listOFSpecialities = new[] 
            {
                "Web Developer",
                "PHP Developer",
                "QA Engineer",
                "JAVA Developer",
                "C# Developer",
                "JS Developer",
                "Python Developer",
                "Mobile Developer"
            };

            var random = new Random();

            var linesToWriteInFile = new List<string>(listFn.Length);
            linesToWriteInFile.Add($"FN\tSpeciality");

            foreach (var fn in listFn)
            {
                var randomIndex = random.Next(0, listOFSpecialities.Length);
                var currentLine = $"{fn}\t{listOFSpecialities[randomIndex]}";
                linesToWriteInFile.Add(currentLine);
            }

            File.WriteAllLines("../../../../SpecialtyData.txt", linesToWriteInFile);
        }

        private static void StudentsJoinedToSpecialties(List<Student> listOfStudents, List<Speciality> listOfSpecialities)
        {
            var resultJoin = listOfStudents.Join(listOfSpecialities, student => student.Fn,
                    speciality => speciality.Fn, (student, speciality) => new
                    {
                        Name = student.FirstName + " " + student.LastName,
                        student.Fn,
                        speciality.SpecialityName
                    })
                .ToArray();

            foreach (var result in resultJoin)
            {
                Console.WriteLine($"{result.Name} - {result.Fn} - {result.SpecialityName}");
            }
        }

        private static void GroupByGroup(List<Student> listOfStudents)
        {
            var resultGroups = listOfStudents
                .GroupBy(s => s.Group)
                .OrderBy(x => x.Key)
                .ToList();

            foreach (var group in resultGroups)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
        }

        private static void StudentsEnrolled(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => s.Fn.ToString().EndsWith("14") || s.Fn.ToString().EndsWith("15"))
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void WeakStudents(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => s.Grades.Count(g => g <= 3) >= 2)
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void ExcellentStudents(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => s.Grades.Any(g => g == 6))
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void FilterStudentsByPhone(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void FilterStudentsByEmailDomain(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => s.Email.Contains("@gmail.com"))
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void SortStudents(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName)
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void StudentsByAge(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => s.Age >= 18 && s.Age <= 24)
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void StudentsByFirstAndLastName(List<Student> listOfStudents)
        {
            var resultStudents = listOfStudents
                .Where(s => String.Compare(s.FirstName, s.LastName) < 0)
                .ToArray();

            PrintStudents(resultStudents);
        }

        private static void FilterStudentsByGroup(List<Student> listOfStudents)
        {
            var studentsInGivenGroup = listOfStudents
                .Where(s => s.Group == 2)
                .ToArray();

            PrintStudents(studentsInGivenGroup);
        }

        private static List<Student> ReadStudentsFromFile(string filePath)
        {
            var inputData = File.ReadAllLines(filePath);

            var listOfStudents = new List<Student>(inputData.Length);

            for (var i = 1; i < inputData.Length; i++)
            {
                var currentLine = inputData[i];

                listOfStudents.Add(Student.Parse(currentLine));
            }

            return listOfStudents;
        }

        private static void PrintStudents(Student[] resultStudents)
        {
            foreach (var student in resultStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
