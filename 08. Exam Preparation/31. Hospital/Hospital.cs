namespace _31._Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static List<string> FullDepartments = new List<string>();
        public static void Main()
        {
            var hospital = new Dictionary<string, Department>();
            var doctors = new List<Doctor>();

            var inputLine = Console.ReadLine();

            while (inputLine != "Output")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var departmentName = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];

                if (!hospital.ContainsKey(departmentName))
                {
                    var newDepartment = new Department();
                    hospital[departmentName] = newDepartment;
                }

                if (FullDepartments.Contains(departmentName))
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                var patientIsAccepted = TryToAcceptPatient(hospital, departmentName, patient);

                if (patientIsAccepted)
                {
                    if (!doctors.Any(x => x.FirstName == firstName && x.LastName == lastName))
                    {
                        var newDoctor = new Doctor(firstName, lastName);
                        doctors.Add(newDoctor);
                    }

                    var currentDoctor = doctors.Single(x => x.FirstName == firstName && x.LastName == lastName);
                    currentDoctor.Patients.Add(patient);
                }
                else
                {
                    FullDepartments.Add(departmentName);
                }

                inputLine = Console.ReadLine();
            }

            var inputCommand = Console.ReadLine();

            while (inputCommand != "End")
            {
                var tokens = inputCommand.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 1)
                {
                    var departmentName = tokens[0];
                    var departmentRooms = hospital[departmentName].Rooms;

                    PrintPatients(departmentRooms);
                }
                else
                {
                    if (int.TryParse(tokens[1], out var roomId))
                    {
                        var departmentName = tokens[0];
                        var currentDepartmentRoom = hospital[departmentName].Rooms[roomId - 1];

                        currentDepartmentRoom = currentDepartmentRoom
                            .Where(x => !string.IsNullOrEmpty(x))
                            .OrderBy(x => x)
                            .ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, currentDepartmentRoom));
                    }
                    else
                    {
                        var firstName = tokens[0];
                        var lastName = tokens[1];

                        var currentDoctor = doctors.Single(x => x.FirstName == firstName && x.LastName == lastName);
                        var patientsForCurrentDoctor = currentDoctor.Patients.OrderBy(x => x).ToArray();

                        Console.WriteLine(string.Join(Environment.NewLine, patientsForCurrentDoctor));
                    }
                }

                inputCommand = Console.ReadLine();
            }
        }

        private static void PrintPatients(string[][] departmentRooms)
        {
            for (var roomIndex = 0; roomIndex < departmentRooms.Length; roomIndex++)
            {
                var currentRoom = departmentRooms[roomIndex];

                for (var patientIndex = 0; patientIndex < currentRoom.Length; patientIndex++)
                {
                    var currentPatient = departmentRooms[roomIndex][patientIndex];

                    if (string.IsNullOrEmpty(currentPatient))
                    {
                        return;
                    }

                    Console.WriteLine(currentPatient);
                }
            }
        }

        private static bool TryToAcceptPatient(Dictionary<string, Department> hospital, string departmentName, string patient)
        {
            var currentDepartmentRooms = hospital
                .Single(x => x.Key == departmentName)
                .Value
                .Rooms;

            for (var roomIndex = 0; roomIndex < currentDepartmentRooms.Length; roomIndex++)
            {
                var currentRoom = currentDepartmentRooms[roomIndex];

                for (var patientIndex = 0; patientIndex < currentRoom.Length; patientIndex++)
                {
                    var currentPatient = currentDepartmentRooms[roomIndex][patientIndex];

                    if (string.IsNullOrEmpty(currentPatient))
                    {
                        currentDepartmentRooms[roomIndex][patientIndex] = patient;
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public class Department
    {
        public string[][] Rooms { get; set; } //[room id][patients]
        
        public Department()
        {
            Rooms = new string[20][];

            for (var i = 0; i < Rooms.Length; i++)
            {
                Rooms[i] = new string[3];
            }
        }
    }

    public class Doctor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Patients { get; set; }

        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Patients = new List<string>();
        }
    }
}
    