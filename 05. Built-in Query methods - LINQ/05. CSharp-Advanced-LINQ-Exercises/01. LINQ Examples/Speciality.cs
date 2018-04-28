namespace MySpeciality
{
    using System;

    public class Speciality
    {
        public int Fn { get; set; }
        public string SpecialityName { get; set; }

        public Speciality(int fn, string specialityName)
        {
            Fn = fn;
            SpecialityName = specialityName;
        }

        public static Speciality Parse(string inputString)
        {
            var tokens = inputString.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);

            var fn = int.Parse(tokens[0]);
            var specialityName = tokens[1];

            return new Speciality(fn, specialityName);
        }

        public override string ToString()
        {
            return $"{SpecialityName}";
        }
    }
}
