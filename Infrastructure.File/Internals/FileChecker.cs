namespace Infrastructure.File
{
    internal class FileChecker : IFileChecker
    {
        public bool Exists(string fullPhysicalPath)
        {
            return System.IO.File.Exists(fullPhysicalPath);
        }
    }
}
