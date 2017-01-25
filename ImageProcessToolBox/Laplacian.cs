﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessToolBox
{
    class Laplacian : IImageProcess
    {
        private Bitmap _SourceImage;
        public Laplacian(Bitmap bitmap)
        {
            _SourceImage = bitmap;
        }

        public Bitmap Process()
        {
            return laplacian(_SourceImage);
        }
        private static Bitmap laplacian(Bitmap bitmap)
        {
            int width = bitmap.Width, height = bitmap.Height;
            int w = 3, h = 3;
            Bitmap dstBitmap = new Bitmap(bitmap);

            byte[,] pix =ImageExtract.getimageArray(bitmap);
            byte[,] resPix = new byte[3, width * height];

            for (int y = 1; y < (height - 1); y++)
            {
                for (int x = 1; x < (width - 1); x++)
                {
                    //b,g,r 
                    for (int c = 0; c < 3; c++)
                    {
                        //mask
                        int current = x + y * width;
                        byte[] mask = new byte[w * h];
                        for (int my = 0; my < h; my++)
                            for (int mx = 0; mx < w; mx++)
                            {
                                int pos = current + (mx - 1) + ((my - 1) * width);
                                mask[mx + my * w] = pix[c, pos];
                            }

                        resPix[c, current] = LaplacianMask33(mask);
                    }
                }
            }
            ImageExtract.writeImageByArray(resPix, dstBitmap);
            return dstBitmap;
        }
        private static byte LaplacianMask33(byte[] gate)
        {
            int[] mask ={
                         -1,-1,-1,
                         -1,8,-1,
                         -1,-1,-1,
                    };
            double result = 0;

            for (int i = 0; i < gate.Length; i++)
                result += (double)((gate[i] * mask[i]));
            return (byte)((result > 255) ? 255 : (result < 0) ? 0 : result);
        }
    }
}
