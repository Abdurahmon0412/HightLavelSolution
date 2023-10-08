// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");
//EmailTemplateApp - faylni ochadi unga template yozadi va 10 sekund kutib turadi
//EmailMessageApp - faylni ochadi templateni o'qib oladi va template o'rniga message ni yozib qo'yadi

var filePath = @"D:\Projects\Files\Salom.txt";
var mutex = new Mutex(false, "OpenFileMutex");
await Task.Run(() =>
{
    mutex.WaitOne();
    var guid = Guid.NewGuid();
    var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
    Console.WriteLine($"App {guid} opened the file");
    var buffer = new byte[fileStream.Length];
    fileStream.Read(buffer, 0, buffer.Length);
    

    var emailTemplate = Encoding.UTF8.GetString(buffer).Replace("{{UserName}}", "Firdavs");
    fileStream.Write(Encoding.UTF8.GetBytes(emailTemplate));
    Thread.Sleep(9000);
    fileStream.Close();
    Console.WriteLine($"App{guid} closed the file");
    mutex.ReleaseMutex();

});