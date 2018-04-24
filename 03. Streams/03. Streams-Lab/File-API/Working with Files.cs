using System;
using System.IO;

public class WorkingWithFiles
{
    private const string FilePath = "../../text.txt";

    public static void Main()
    {
        var text = File.ReadAllText(FilePath);
        Console.WriteLine(text);        
        
        File.WriteAllText("../../new.txt", "New line");

        var fileExists = File.Exists("../../Working with Files.cs");
        Console.WriteLine(fileExists);

        var fileStream = File.Create("temp.bin");
        fileStream.Close();

        File.Move("temp.bin", "renamed.bin");

        File.Delete("renamed.bin");

        var fileInfo = new FileInfo("../../Working with Files.cs");
        Console.WriteLine("Name: {0}, Extension: {1}, Size: {2}b, Last Accessed: {3}",
            fileInfo.Name, fileInfo.Extension, fileInfo.Length, fileInfo.LastAccessTime);

        var files = Directory.GetFiles(Directory.GetCurrentDirectory());

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }

        var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Console.WriteLine(path);
    }
}
