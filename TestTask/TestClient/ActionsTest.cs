using System.Collections.Generic;
using System.Drawing;
using Task_Client_.Models.Actions;
using Task_Data_.Entities;
using Xunit;

namespace TestTask.TestClient
{
    public class ActionsTest
    {
        [Fact]
        public void SerializationStringMass ()
        {
            Actions actions = new();
            var result = actions.TestSerializationString(new string[1] { "garet" });
            Assert.Equal(34, result.Length);
        }
        [Fact]
        public void SerializationStringTusers()
        {
            Actions actions = new();
            var result = actions.TestSerializationString(new tusers());
            Assert.Equal(109, result.Length);
        }
        [Fact]
        public void SerializationStringList_string_()
        {
            Actions actions = new();
            var result = actions.TestSerializationString(new List<string> { "garet" });
            Assert.Equal(9, result.Length);
        }
        [Fact]
        public void SerializationStringList_tusers_group_chat_()
        {
            Actions actions = new();
            var result = actions.TestSerializationString(new List<tusers_group_chat> { });
            Assert.Equal(2, result.Length);
        }
        [Fact]
        public void SerializationStringImage()
        {
            Actions actions = new();
            var bmp = new Bitmap(256, 256);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.DarkGreen);
            }
            var paramss = (Image)bmp;
            var result = actions.TestSerializationString(paramss);
            Assert.Equal(1653, result.Length);
        }
    }
}
