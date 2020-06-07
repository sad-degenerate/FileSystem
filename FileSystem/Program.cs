using System;
using System.IO;

namespace FileSystem
{
    class Program
    {
        public static string Separator = "  ";

        static void Main(string[] args)
        {
            // Вставьте свои переменные для работы программы.

            var root = @"D:\";

            var fromDir = @"D:\testDir1";
            var toDir = @"D:\testDir2";

            var fileName = "text.txt";

            DirectoryTree(root);

            CopyFile(fromDir, toDir, fileName);
        }

        static void CopyFile(string from, string to, string fileName)
        {
            var file = from + "\\" + fileName;
            var newFile = to + "\\" + fileName;

            try
            {
                File.Copy(file, newFile);
                Console.WriteLine("Копирование произошло успешно.");
            }
            catch 
            {
                Console.WriteLine("Ошибка при копировании.");
            }
        }

        static void DirectoryTree(string root)
        {
            var dir = new DirectoryInfo(root);

            Console.WriteLine(dir.FullName);

            DirectoryInfo(dir, 1);
        }

        static void DirectoryInfo(DirectoryInfo info, int tabs)
        {
            var dirs = info.GetDirectories();

            foreach(var dir in dirs)
            {
                for (int i = 0; i < tabs; i++)
                    Console.Write(Separator);

                try
                {
                    Console.WriteLine(dir.Name);
                    DirectoryInfo(dir, tabs + 1);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Отказано в доступе к директории.");
                }
            }
        }
    }
}