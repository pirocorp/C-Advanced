namespace ClassroomProject
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class Classroom
    {
        private readonly int capacity;
        private readonly IList<Student> students;

        public Classroom(int capacity)
        {
            this.capacity = capacity;
            this.students = new List<Student>(capacity);
        }

        public int Capacity => this.capacity;

        public int Count => this.students.Count;

        public IEnumerable<Student> Students => this.students;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.capacity)
            {
                this.students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.GetStudent(firstName, lastName);

            if (student is null)
            {
                return "Student not found";
            }

            this.students.RemoveAt(this.students.IndexOf(student));
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            var studentsInCourse = this.students
                .Where(s => s.Subject.Equals(subject));

            if (!studentsInCourse.Any())
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in studentsInCourse)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
            => this.students
                .FirstOrDefault(s => s.FirstName.Equals(firstName)
                                     && s.LastName.Equals(lastName));
    }
}
