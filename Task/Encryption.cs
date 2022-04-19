using System.Linq;

namespace Task_Data_
{
    static public class Encryption
    {
        const ushort key = 0x1288;
        public static string[] EncodeDecryptMass(string[] str)
        {
            string[] rez = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i].ToArray(); //преобразуем строку в символы
                string newStr = "";      //переменная которая будет содержать зашифрованную строку
                foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                    newStr += TopSecret(c);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
                rez[i] = newStr;
            }
            return rez;
        }

        public static string EncodeDecryptString(string str)
        {
            string rez;
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            rez = newStr;
            return rez;
        }

        public static char TopSecret(char character)
        {
            character = (char)(character ^ key); //Производим XOR операцию
            return character;
        }
    }
}
