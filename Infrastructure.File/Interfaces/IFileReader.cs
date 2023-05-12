namespace Infrastructure.File
{
    public interface IFileReader
    {
        byte[] Read(string fullPhysicalPath);
    }
}
