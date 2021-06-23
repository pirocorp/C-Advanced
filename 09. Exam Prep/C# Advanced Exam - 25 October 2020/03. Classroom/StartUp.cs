namespace ClassroomProject
{
    using System;

    public static class StartUp
    {
        public static void Main()
        {
            // Initialize the repository
            var classroom = new Classroom(10);

            // Initialize entities
            var student = new Student("Peter", "Parker", "Geometry");
            var studentTwo = new Student("Sarah", "Smith", "Algebra");
            var studentThree = new Student("Sam", "Winchester", "Algebra");
            var studentFour = new Student("Dean", "Winchester", "Music");

            // Print Student
            Console.WriteLine(student); // Student: First Name = Peter, Last Name = Parker, Subject = Geometry
            
            // Register Student
            var register = classroom.RegisterStudent(student);

            Console.WriteLine(register); // Added student Peter Parker
            var registerTwo = classroom.RegisterStudent(studentTwo);
            var registerThree = classroom.RegisterStudent(studentThree);
            var registerFour = classroom.RegisterStudent(studentFour);

            // Dismiss Student
            var dismissed = classroom.DismissStudent("Peter", "Parker");

            Console.WriteLine(dismissed); // Dismissed student Peter Parker
            var dismissedTwo = classroom.DismissStudent("Ellie", "Goulding");

            Console.WriteLine(dismissedTwo); // Student not found

            // Subject info
            var subjectInfo = classroom.GetSubjectInfo("Algebra");
            Console.WriteLine(subjectInfo);

            // Subject: Algebra
            // Students:
            // Sarah Smith
            // Sam Winchester
            var anotherInfo = classroom.GetSubjectInfo("Art");
            Console.WriteLine(anotherInfo); // No students enrolled for the subject

            // Get Student
            Console.WriteLine(classroom.GetStudent("Dean", "Winchester"));
            // Student: First Name = Dean, Last Name = Winchester, Subject = Music
        }
    }
}