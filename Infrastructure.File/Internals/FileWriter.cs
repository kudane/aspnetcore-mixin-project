namespace Infrastructure.File
{
    internal class FileWriter : IFileWriter
    {
        public void Write(string fullPhysicalPath, byte[] file)
        {
            if (System.IO.File.Exists(fullPhysicalPath))
            {
                throw new Exception("File Name Duplicate.");
            }

            System.IO.File.WriteAllBytes(fullPhysicalPath, file);
        }
    }
}
