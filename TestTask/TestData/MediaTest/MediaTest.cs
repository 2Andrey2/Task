using Task_Data_.Media;
using Xunit;

namespace TestTask.TestData.MediaTest
{
    public class MediaTest
    {
        [Fact]
        public void CheckingUsersFolderTrue()
        {
            var result = Media.CheckingUsersFolder("99999",false);
            Assert.True(result);
        }
        [Fact]
        public void CheckingUsersFolderFalse()
        {
            var result = Media.CheckingUsersFolder("+-[][]", true);
            Assert.True(result);
        }
        [Fact]
        public void CheckingUsersAvatarTrue()
        {
            var result = Media.CheckingUsersAvatar("2");
            Assert.False(result);
        }
        [Fact]
        public void CheckingUsersAvatarFalse()
        {
            var result = Media.CheckingUsersAvatar("+-[][]");
            Assert.False(result);
        }
    }
}
