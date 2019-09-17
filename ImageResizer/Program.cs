using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");


            // 非同步
            imageProcess.Clean(destinationPath);

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            imageProcess.ResizeImagesAync(sourcePath, destinationPath, 2.0);
            sw1.Stop();

            Console.WriteLine($"非同步花費時間: {sw1.ElapsedMilliseconds} ms");

            double result = Convert.ToDouble((sw.ElapsedMilliseconds - sw1.ElapsedMilliseconds) * 100) / sw.ElapsedMilliseconds;
            Console.WriteLine($"效能提升百分比: {result} %");
            Console.ReadKey();
        }
    }
}
