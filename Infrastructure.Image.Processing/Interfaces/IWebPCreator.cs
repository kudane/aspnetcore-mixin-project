namespace Infrastructure.Image.Processing
{
    public interface IWebPCreator
    {
        byte[] Create(byte[] image, WebPFormat? format);
    }
}
