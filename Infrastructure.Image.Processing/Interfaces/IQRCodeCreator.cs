namespace Infrastructure.Image.Processing
{
    public interface IQRCodeCreator
    {
        byte[] Create(string qrData);
    }
}
