﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessToolBox
{
    class MorphologyClosing : IImageProcess
    {
        private Bitmap _SourceImage;
        public MorphologyClosing(Bitmap bitmap)
        {
            _SourceImage = bitmap;
        }

        public Bitmap Process()
        {
            Bitmap erosionBitmap = new MorphologyErosion(_SourceImage).Process();
            Bitmap dilatBitmap = new MorphologyDilation(erosionBitmap).Process();
            erosionBitmap.Dispose();
            return dilatBitmap;
        }
    }
}