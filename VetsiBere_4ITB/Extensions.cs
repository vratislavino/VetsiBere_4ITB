using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere_4ITB
{
    internal static class Extensions
    {
        public static Bitmap GetPart(this Bitmap bmp, int x, int y, int width, int height)
        {
            Bitmap newBmp = new Bitmap(width, height);
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    newBmp.SetPixel(i, j, bmp.GetPixel(x + i, y + j));
                }
            }
            return newBmp;
        }
    }
}
