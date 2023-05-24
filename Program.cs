using System;
using System.IO;

class FolderSizeCalculator
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Write("Введите путь к папке:");
            var folderPath = Console.ReadLine();
            CalculateAndPrintFolderSize(folderPath);
        }
        else
        {
            var folderPath = args[0];
            CalculateAndPrintFolderSize(folderPath);
        }

        Console.ReadLine();
    }

    static void CalculateAndPrintFolderSize(string folderPath)
    {
        var folderSize = CalculateFolderSize(folderPath);
        Console.WriteLine("Размер папки: " + folderSize + " байт");
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
            var directoryInfo = new DirectoryInfo(folderPath);

            /// Получаем все файлы в папке и суммируем их размер
            foreach (var file in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
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