
var path = @"D:\Projects";

DirectoryInfo directoryInfo = new DirectoryInfo(path);

var test = "test";
for(int i = 0; i< 3; i++)
{
    directoryInfo.CreateSubdirectory(test + Convert.ToString( i));
}

