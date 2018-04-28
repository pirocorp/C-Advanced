namespace MyStudentClass
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public int Fn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Group { get; set; }
        public List<int> Grades { get; set; }
        public string Phone { get; set; }

        public Student(int fn, string firstName, string lastName, string email, int age, int group, List<int> grades, string phone)
        {
            Fn = fn;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Group = group;
            Grades = grades;
            Phone = phone;
        }

        public static Student Parse(string inputString)
        {
            var tokens = inputString.Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);
            var fn = int.Parse(tokens[0]);
            var firstName = tokens[1];
            var lastName = tokens[2];
            var email = tokens[3];
            var age = int.Parse(tokens[4]);
            var group = int.Parse(tokens[5]);
            var grade1 = int.Parse(tokens[6]);
            var grade2 = int.Parse(tokens[7]);
            var grade3 = int.Parse(tokens[8]);
            var grade4 = int.Parse(tokens[9]);
            var grades = new List<int> {grade1, grade2, grade3, grade4};
            var phone = tokens[10];

            return new Student(fn, firstName, lastName, email, age, group, grades, phone);
        }

        public override string ToString()
        {
            return $"{Fn:D6}, {Group} - {FirstName} {LastName}: {Age}, {Email}, {Phone}, Grades: {{{string.Join(", ", Grades)}}}";
        }
    }
}
