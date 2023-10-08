using System.Text;

var filePath = @"D:\Projects\Files\Salom.txt";
var mutex = new Mutex(false, "OpenFileMutex");

await Task.Run(() =>
{
    mutex.WaitOne();
    var guid = Guid.NewGuid();

    var fileStream = File.Open(filePath, FileMode.Open, FileAccess.Write);

    Console.WriteLine($"App {guid} opened the file");
    var emailTemplate = "Hello {{UserName}}. Welcome to our platforms";
    
    fileStream.Write(Encoding.UTF8.GetBytes(emailTemplate));
    Thread.Sleep(9000);
    fileStream.Close();
    Console.WriteLine($"App{guid} closed the file");
    mutex.ReleaseMutex();

});