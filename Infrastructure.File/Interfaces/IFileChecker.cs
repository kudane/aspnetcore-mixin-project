namespace Infrastructure.File
{
    public interface IFileChecker
    {
        bool Exists(string fullPhysicalPath);
    }
}
