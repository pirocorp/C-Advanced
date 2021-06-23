namespace _04._Copy_Binary_File
{
    using System.IO;
    using System.Threading.Tasks;

    public static class Program
    {
        public static async Task Main()
        {
            await using var inputFile = new FileStream("./copyMe.png", FileMode.Open);

            await using var outputFile = new FileStream("../../../output.png", FileMode.Create);

            await inputFile.CopyToAsync(outputFile);
        }
    }
}
