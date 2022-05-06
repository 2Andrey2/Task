using System.Collections.Generic;
using System.Drawing;
using Task_Client_.Models.Actions;
using Task_Data_.Entities;
using Task_Data_.Media;
using Xunit;

namespace TestTask.TestData.MediaTest
{
    public class WorkingImagesTest
    {
        [Fact]
        public void ImageEncoding()
        {
            Actions actions = new();
            var bmp = new Bitmap(256, 256);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.DarkGreen);
            }
            var paramss = (Image)bmp;
            var result = WorkingImages.ImageEncoding(paramss);
            Assert.Equal(1653, result.Length);
        }
        [Fact]
        public void ImageDecoding()
        {
            Actions actions = new();
            var bmp = new Bitmap(256, 256);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.DarkGreen);
            }
            var paramss = (Image)bmp;
            var temp = WorkingImages.ImageEncoding(paramss);
            var result = WorkingImages.ImageDecoding(temp);
            Assert.Equal(paramss.Size, result.Size);
        }
    }
}
