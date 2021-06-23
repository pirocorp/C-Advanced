namespace DefiningClasses
{
    public static class StartUp
    {
        public static void Main()
        {
            var person = new Person("Asen", 5);
            var person2 = new Person("Pesho", 25);
        }

        public class Person
        {
            private string name;

            private int age;

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public string Name => this.name;

            public int Age => this.age;
        }
    }
}
