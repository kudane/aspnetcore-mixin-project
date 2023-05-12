namespace Infrastructure.File
{
    internal class FileReader : IFileReader
    {
        public byte[] Read(string fullPhysicalPath)
        {
            if (!System.IO.File.Exists(fullPhysicalPath))
            {
                throw new Exception("File Not Found.");
            }

            return System.IO.File.ReadAllBytes(fullPhysicalPath);  
        }
    }
}
