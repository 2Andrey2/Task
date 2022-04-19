using System.IO;

namespace Task.Media
{
    public static class Media
    {
        public static string PathFolderUser = "users";
        public static string NameAvatar = "avatar.png";

        public static bool CheckingUsersFolder (string id)
        {
            try
            {
                if (!Directory.Exists(PathFolderUser + "/" + id))
                {
                    Directory.CreateDirectory(PathFolderUser + "/" + id);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckingUsersAvatar(string id)
        {
            if (!File.Exists(PathFolderUser + "/" + id + "/" + NameAvatar))
            {
                return false;
            }
            return true;
        }
    }
}
