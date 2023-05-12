namespace Infrastructure.Image.Processing
{
    internal class WebPCreator : IWebPCreator
    {
        public byte[] Create(byte[] image, WebPFormat? format = null)
        {
            using (var outStream = new MemoryStream())
            {
                using (var imageFactory = new ImageFactory(preserveExifData: true))
                {
                    imageFactory.Load(image)
                                .Format(format ?? WebPConstants.DEFUALT_WEBP_FORMAT)
                                .Save(outStream);
                }

                return outStream.ToArray();
            }
        }
    }
}
