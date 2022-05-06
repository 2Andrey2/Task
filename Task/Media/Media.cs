using System.IO;

namespace Task_Data_.Media
{
    public static class Media
    {
        public static string PathFolderUser = "users";
        public static string NameAvatar = "avatar.png";

        public static bool CheckingUsersFolder (string id, bool create = true)
        {
            try
            {
                if (!Directory.Exists(PathFolderUser + "/" + id))
                {
                    if (create)
                    {
                        Directory.CreateDirectory(PathFolderUser + "/" + id);
                    }
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
