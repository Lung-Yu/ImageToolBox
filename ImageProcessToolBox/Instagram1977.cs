﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessToolBox
{

    //https://www.kancloud.cn/trent/hotoimagefilter/102805
    class Instagram1977 : IImageProcess
    {
        private static int[] processAB = new int[256] { 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 64, 65, 66, 68, 69, 70, 71, 72, 73, 75, 76, 77, 78, 79, 80, 82, 83, 84, 85, 86, 87, 89, 90, 91, 92, 93, 95, 96, 97, 98, 99, 100, 102, 103, 104, 105, 106, 107, 109, 110, 111, 112, 113, 115, 116, 117, 118, 119, 120, 122, 123, 124, 125, 126, 127, 129, 130, 131, 132, 133, 134, 136, 137, 138, 139, 139, 140, 142, 143, 144, 145, 146, 147, 149, 150, 151, 152, 153, 154, 156, 157, 158, 159, 160, 161, 163, 164, 165, 166, 167, 169, 170, 171, 172, 173, 174, 176, 177, 178, 179, 180, 181, 183, 184, 185, 186, 187, 189, 190, 191, 192, 193, 194, 196, 197, 198, 199, 200, 201, 203, 204, 205, 206, 207, 208, 210, 211, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212, 212 };//
        private static int[] processAG = new int[256] { 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 73, 73, 74, 75, 76, 77, 78, 79, 80, 81, 83, 84, 85, 85, 86, 87, 88, 89, 90, 91, 93, 94, 95, 96, 96, 97, 98, 99, 100, 102, 103, 104, 105, 106, 107, 108, 108, 109, 110, 112, 113, 114, 115, 116, 117, 118, 119, 120, 120, 122, 123, 124, 125, 126, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 142, 143, 143, 144, 145, 146, 147, 148, 149, 150, 152, 153, 154, 155, 155, 156, 157, 158, 159, 160, 162, 163, 164, 165, 166, 167, 167, 168, 169, 170, 172, 173, 174, 175, 176, 177, 178, 179, 179, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 202, 202, 203, 204, 205, 206, 207, 208, 209, 210, 212, 213, 214, 214, 215, 216, 217, 218, 219, 221, 222, 223, 224, 225, 226, 226, 227, 228, 229, 231, 232, 233, 234, 235, 236, 237, 237, 238, 239, 241, 242, 243, 244, 245, 246, 247, 248, 249, 249, 251, 252, 253, 254 };//
        private static int[] processAR = new int[256] { 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81, 82, 84, 84, 85, 86, 88, 88, 89, 91, 92, 93, 93, 95, 96, 97, 98, 99, 100, 101, 103, 103, 104, 106, 107, 107, 108, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 121, 121, 122, 123, 125, 126, 126, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 140, 140, 141, 143, 144, 145, 145, 147, 148, 149, 150, 151, 152, 154, 154, 155, 156, 158, 159, 159, 161, 162, 163, 164, 164, 165, 166, 167, 168, 169, 170, 171, 173, 173, 174, 176, 177, 178, 178, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 191, 192, 192, 193, 195, 196, 196, 198, 199, 200, 201, 202, 203, 204, 206, 206, 207, 208, 210, 210, 211, 213, 214, 215, 215, 217, 218, 219, 220, 221, 222, 223, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225, 225 };//
        private Bitmap _SourceImage;
        public Instagram1977()
        {
           
        }

        public Instagram1977(Bitmap bitmap)
        {
            _SourceImage = bitmap;
        }

        public Bitmap Process()
        {
            return FilterProcess(_SourceImage);
        }

        private Bitmap FilterProcess(Bitmap a)
        {
            Bitmap srcBitmap = new Bitmap(a);
            int w = srcBitmap.Width;
            int h = srcBitmap.Height;

            BitmapData srcData = srcBitmap.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* pSrc = (byte*)srcData.Scan0;
                int offset = srcData.Stride - w * 4;
                for (int j = 0; j < h; j++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        pSrc[0] = (byte)processAB[pSrc[0]];
                        pSrc[1] = (byte)processAG[pSrc[1]];
                        pSrc[2] = (byte)processAR[pSrc[2]];
                        pSrc += 4;
                    }
                    pSrc += offset;
                }
            }
            srcBitmap.UnlockBits(srcData);
            return srcBitmap;
        }


        public void setResouceImage(Bitmap bitmap)
        {
            _SourceImage = bitmap;
        }
    }
}