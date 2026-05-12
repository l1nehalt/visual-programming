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
                    int position = 3 * (j * source.Width + i);
                    result[position + 0] = pixel.R;
                    result[position + 1] = pixel.G;
                    result[position + 2] = pixel.B;
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
                    result.SetPixel(i, j, Color.FromArgb(
                        source[position + 0],
                        source[position + 1],
                        source[position + 2]));
                }
            }
            return result;
        }

        public static int RgbRange(int value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return value;
        }

        public static Bitmap ApplyFilter(Bitmap source, int[,] matrix, int divisor = 1)
        {
            byte[] src = BmpToArray(source);
            byte[] res = new byte[src.Length];
            int width = source.Width;
            int height = source.Height;

            int matrixSize = matrix.GetLength(0);

            int offset = matrixSize / 2;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int r = 0, g = 0, b = 0;

                    for (int n = 0; n < matrixSize; n++)
                    {
                        for (int m = 0; m < matrixSize; m++)
                        {
                            int ni = i + n - offset;
                            int mj = j + m - offset;

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
                    res[pixelPos + 2] = (byte)b / divisor > 255 ? (byte)255 : (byte)RgbRange(b / divisor);
                }
            }
            return ArrayToBmp(res, width, height);
        }

        public static Bitmap BlurImage(Bitmap source)
        {
            int[,] matrix = new int[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
            return ApplyFilter(source, matrix, 16);
        }

        public static Bitmap SharpenEdges(Bitmap source)
        {
            int[,] matrix = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            return ApplyFilter(source, matrix);
        }

        public static Bitmap SharpenImage(Bitmap source)
        {
            int[,] matrix = new int[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            return ApplyFilter(source, matrix);
        }
    }
}