using System.Drawing;
using System.IO;

namespace Task_Data_.Media
{
    public static class WorkingImages
    {
        public static byte[] ImageEncoding (Image data)
        {
            byte[] byteArray = new byte[10000];
            Image image = (Image)data;
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }
        public static Image ImageDecoding (byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }
    }
}
