﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var path = "D:";

var directoryInfo = new DirectoryInfo(path);

directoryInfo.GetDirectories();
for(int i = 0; i< 5; i++)
{
    Console.WriteLine(Guid.NewGuid());
}






