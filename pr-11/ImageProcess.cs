using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_11
{
    public static class ImageProcess
    {
        public static byte[] BmpToArray(Bitmap source)
        {
            var result = new byte[source.Width * source.Height * 3];
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color pixel = source.GetPixel(i, j);
                    result[3 * (j * source.Width + i) + 0] = pixel.R;
                    result[3 * (j * source.Width + i) + 1] = pixel.G;
                    result[3 * (j * source.Width + i) + 2] = pixel.B;
                }
            }
            return result;
        }

        public static Bitmap ArrayToBmp(byte[] source, int width, int height)
        {
            var result = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int position = 3 * (j * width + i);
                    result.SetPixel(i, j, Color.FromArgb(source[position + 0],
                    source[position + 1],
                   source[position + 2]));
                }
            }
            return result;
        }
        public static int RgbRange(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            else
            {
                if (value > 255)
                {
                    value = 255;
                }
            }
            return value;
        }

        public static Bitmap FilterImage(Bitmap source)
        {
            byte[] src = BmpToArray(source);
            byte[] res = new byte[src.Length];
            int[,] matrix = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    var r = 0;
                    var g = 0;
                    var b = 0;
                    for (int n = 0; n < 3; n++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            if (((j - 1 + m) < 0) || ((j - 1 + m) == source.Height)
                            || ((i - 1 + n) < 0) || ((i - 1 + n) == source.Width))
                            {
                                continue;
                            }
                            int position = 3 * (source.Width * (j - 1 + m) + (i - 1 +
                           n));
                            int matrixValue = matrix[n, m];
                            r += src[position + 0] * matrixValue;
                            g += src[position + 1] * matrixValue;
                            b += src[position + 2] * matrixValue;
                        }
                    }
                    r = RgbRange(r);
                    g = RgbRange(g);
                    b = RgbRange(b);
                    int pixelPosition = 3 * (source.Width * j + i);
                    res[pixelPosition + 0] = (byte)r;
                    res[pixelPosition + 1] = (byte)g;
                    res[pixelPosition + 2] = (byte)b;
                }
            }
            return ArrayToBmp(res, source.Width, source.Height);
        }

        public static Bitmap BlurImage(Bitmap source)
        {
            int[,] matrix = new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            return ApplyFilter(source, matrix, 16); // 16 — сумма коэффициентов для нормировки
        }

        public static Bitmap SharpenEdges(Bitmap source)
        {
            int[,] matrix = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            return ApplyFilter(source, matrix, 1);
        }

        private static Bitmap ApplyFilter(Bitmap source, int[,] matrix, int divisor)
        {
            byte[] src = BmpToArray(source);
            byte[] res = new byte[src.Length];
            int width = source.Width;
            int height = source.Height;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    for (int n = 0; n < 3; n++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            int ni = i + n - 1;
                            int mj = j + m - 1;
                            if (ni >= 0 && ni < width && mj >= 0 && mj < height)
                            {
                                int pos = 3 * (mj * width + ni);
                                int val = matrix[n, m];
                                r += src[pos + 0] * val;
                                g += src[pos + 1] * val;
                                b += src[pos + 2] * val;
                            }
                        }
                    }
                    int pixelPos = 3 * (j * width + i);
                    res[pixelPos + 0] = (byte)RgbRange(r / divisor);
                    res[pixelPos + 1] = (byte)RgbRange(g / divisor);
                    res[pixelPos + 2] = (byte)RgbRange(b / divisor);
                }
            }
            return ArrayToBmp(res, width, height);
        }
    }
}
