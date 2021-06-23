namespace _06._Zip_and_Extract
{
    using System.IO.Compression;

    public static class Program
    {
        public static void Main()
        {
            var zipFolder = "./";
            var zipDestination = "../../../output.zip";
            var unZipFolder = "../../../output";

            ZipFile.CreateFromDirectory(zipFolder, zipDestination);
            ZipFile.ExtractToDirectory(zipDestination, unZipFolder);
        }
    }
}
