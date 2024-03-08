using System;
using System.IO;

class Program
{
    static void Main()
    {
        var path = @"C:\Users\bayeg\Documents\passKey\";

        while (true)
        {
            String input = Console.ReadLine();

            if (input == "E")
            {
                break;
            }

            if (input == "F")
            {
                DecryptAllFiles(path);
                Console.WriteLine("OK");
            }

            if (input == "R")
            {
                string fileName = "Pass-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";
                string filePath = Path.Combine(path, fileName);

                using (StreamWriter sw = File.CreateText(filePath))
                {
                    string content = GenerateRandomContent();
                    sw.WriteLine(content);
                    sw.WriteLine("tarih: " + DateTime.Now.ToString("yyyy-MM-dd"));
                    sw.WriteLine("saat: " + DateTime.Now.ToString("HH:mm:ss"));
                    sw.WriteLine("gun: " + DateTime.Now.ToString("dddd"));
                }

                EncryptFile(fileName);

                Console.WriteLine("> " + fileName);
            }
        }
    }

    public static void EncryptFile(string filePath)
    {
        File.Encrypt(filePath);
    }

    public static void DecryptFile(string filePath)
    {
        File.Decrypt(filePath);
    }

    public static void DecryptAllFiles(string directoryPath)
    {
        DirectoryInfo directory = new DirectoryInfo(directoryPath);
        foreach (var file in directory.GetFiles())
        {
            DecryptFile(file.FullName);
        }
    }

    public static string GenerateRandomContent()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=[]{}|;:'\",.<>/?`~";
        int contentLength = random.Next(12, 20);
        char[] content = new char[contentLength];
        for (int i = 0; i < contentLength; i++)
        {
            content[i] = chars[random.Next(chars.Length)];
        }
        return new string(content);
    }
}
