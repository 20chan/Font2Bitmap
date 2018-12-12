using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FontToBitmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var chars = "abcdefghijklmnopqrstuvwyz";
            var result = new List<string[]>();
            foreach (var c in chars)
            {
                var font = new Font("MS Gothic", 9);
                var size = TextRenderer.MeasureText(c.ToString(), font);
                var img = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
                var g = Graphics.FromImage(img);
                g.Clear(Color.White);
                g.DrawString(c.ToString(), font, Brushes.Black, new Point(0, 0));

                var builder = new StringBuilder();
                for (int y = 2; y <= 2 + 8; y++)
                {
                    for (int x = 0; x <= 0 + 8; x++)
                    {
                        var color = img.GetPixel(x, y);
                        int mean = (color.R + color.G + color.B) / 3;
                        builder.Append(mean > 150 ? "□" : "■");
                    }
                    builder.AppendLine();
                }

                result.Add(builder.ToString().Split());
                Console.WriteLine(builder.ToString());
            }
            Console.Read();
        }
    }
}
