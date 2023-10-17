﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Utilities
{
    public class Color
    {
        private byte r;
        private byte g;
        private byte b;
        private byte a;

        public byte R
        {
            get { return r; }
            set { r = value; }
        }

        public byte G
        {
            get { return g; }
            set { g = value; }
        }

        public byte B
        {
            get { return b; }
            set { b = value; }
        }

        public byte A
        {
            get { return a; }
            set { a = value; }
        }

        public static explicit operator uint(Color color)
        {
            return (uint)((color.r << 24) + (color.g << 16) + (color.b << 8) + color.a);
        }
        public Color(byte r, byte g, byte b, byte a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(uint rgbaColor)
        {
            this.r = (byte)((rgbaColor & 0xFF000000) >> 24);
            this.g = (byte)((rgbaColor & 0x00FF0000) >> 16);
            this.b = (byte)((rgbaColor & 0x0000FF00) >> 8);
            this.a = (byte)((rgbaColor & 0x000000FF) >> 0);
        }

        public Color Clone()
        {
            return new Color(this.r, this.g, this.b, this.a);
        }
    }
}
