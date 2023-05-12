namespace Infrastructure.File
{
    public interface IFileWriter
    {
        void Write(string fullPhysicalPath, byte[] file);
    }
}
