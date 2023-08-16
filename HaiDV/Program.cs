// See https://aka.ms/new-console-template for more information
using SkiaSharp;
using System.Threading.Tasks.Dataflow;
using static SkiaSharp.SKBitmapResizeMethod;

Console.WriteLine("Hello, World!");
var byteImg = ImageToByteArray("C:\\Users\\Dao Van Hai\\Desktop\\HAIDV\\HaiDV\\HaiDV\\pexels-irina-iriser-1379640.jpg");
var dataSave = ResizeImg(byteImg);
SaveFile(dataSave);
Console.WriteLine("OKE OKE");

SKData ResizeImg(byte[] byteImg)
{
    var original = SKBitmap.Decode(byteImg).Resize(new SKImageInfo(200, 300), Lanczos3);

    var image = SKImage.FromBitmap(original).Encode(SKEncodedImageFormat.Png, 90);
    return image;
}


byte[] ImageToByteArray(string filePath)
{
    byte[] fileByteArray = File.ReadAllBytes(filePath);
    return fileByteArray;
}

void SaveFile(SKData input)
{
    string pathSave = "D:\\Work\\ConsoleTeleBot" + Guid.NewGuid() + ".png";
    File.WriteAllBytes(pathSave, input.ToArray());
}