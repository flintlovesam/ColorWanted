﻿using System;
using System.Drawing;

namespace ColorWanted
{
    class ColorUtil
    {
        public static byte GetRValue(uint color)
        {
            return (byte)color;
        }
        public static byte GetGValue(uint color)
        {
            return ((byte)(((short)(color)) >> 8));
        }
        public static byte GetBValue(uint color)
        {
            return ((byte)((color) >> 16));
        }
        public static byte GetAValue(uint color)
        {
            return ((byte)((color) >> 24));
        }


        public static bool isGray(Color color)
        {
            return bt(color.R) + bt(color.G) + bt(color.B) >= 2;
        }

        public static int bt(byte val)
        {
            return (val >= 100 && val <= 200) ? 1 : 0;
        }

        public static bool isLight(Color color)
        {
            return gt200(color.R) + gt200(color.G) + gt200(color.B) >= 2;
        }

        public static bool isDark(Color color)
        {
            return lt150(color.R) + lt150(color.G) + lt150(color.B) >= 2;
        }

        public static bool isSingle(Color color)
        {
            return lt100(color.R) + lt100(color.G) + lt100(color.B) == 2 && gt200(color.R) + gt200(color.G) + gt200(color.B) == 1;
        }
        public static int lt150(byte val)
        {
            return val <= 150 ? 1 : 0;
        }
        public static int lt100(byte val)
        {
            return val <= 100 ? 1 : 0;
        }

        public static int gt200(byte val)
        {
            return val >= 200 ? 1 : 0;
        }


        public static Color GetColor(Point screenPoint)
        {
            IntPtr displayDC = NativeMethods.CreateDC("DISPLAY", null, null, IntPtr.Zero);
            uint colorref = NativeMethods.GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            NativeMethods.DeleteDC(displayDC);
            byte Red = GetRValue(colorref);
            byte Green = GetGValue(colorref);
            byte Blue = GetBValue(colorref);
            return Color.FromArgb(Red, Green, Blue);
        }
    }
}