using System;
using System.IO;

class FolderSizeCalculator
{
    static void Main()
    {
        Console.Write("Введите путь к папке:");
        string folderPath = Console.ReadLine();

        try
        {
            long folderSize = CalculateFolderSize(folderPath);
            Console.WriteLine("Размер папки: " + folderSize + " байт");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }

    static long CalculateFolderSize(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            throw new DirectoryNotFoundException("Указанный путь не существует.");
        }

        try
        {
            long size = 0;

            /// Получаем информацию о папке
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            /// Получаем все файлы в папке и суммируем их размер
            foreach (FileInfo file in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                size += file.Length;
            }

            return size;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при подсчете размера папки: " + ex.Message);
        }
    }
}