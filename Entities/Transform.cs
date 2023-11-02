using System;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Entities
{
    public class Transform
    {
        private Vector position; 
        private Vector size;

        public int X 
        { 
            get { return (int)this.position.X; }
            set { this.position.X = value; }
        }

        public int Y
        {
            get { return (int)this.position.Y; }
            set { this.position.Y = value; }
        }

        public Vector Position 
        { 
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector PositionCenter { 
            get { return new Vector(this.position.X + this.Size.X / 2, this.position.Y + this.Size.Y / 2); } 
        }

        public int W
        {
            get { return (int)this.size.X; }
            set { this.size.X = value; }
        }

        public int H
        {
            get { return (int)this.size.Y; }
            set { this.size.Y = value; }
        }

        public Vector Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public Sdl.SDL_Rect Rect
        {
            get { return new Sdl.SDL_Rect((short)position.X, (short)position.Y, (short)size.X, (short)size.Y); }
        }
        public Transform(int x=0,int y = 0, int w = 0, int h = 0)
        {
            this.position = new Vector(x,y);
            this.size = new Vector(w,h);
        }

        public Transform(Vector position, Vector size)
        {
            this.position = position;
            this.size = size;
        }

        public bool isColliding(Transform other)
        {
            bool xAxisColliding = this.X < other.X + other.W && this.X + this.W > other.X;
            bool yAxisColliding = this.Y < other.Y + other.H && this.Y + this.H> other.Y;

            return xAxisColliding && yAxisColliding;
        }

        internal Transform Clone()
        {
            return new Transform(this.Position, this.size);
        }
    }
}
