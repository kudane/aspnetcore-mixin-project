namespace Infrastructure.Image.Processing
{
    internal class QRCodeCreator : IQRCodeCreator
    {
        public byte[] Create(string data)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q))
                {
                    using (var qrBytes = new BitmapByteQRCode(qrData))
                    {
                        return qrBytes.GetGraphic(20).ToArray();
                    }
                }
            }
        }
    }
}
