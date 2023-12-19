using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Tracer : IRenderizable
    {
        private Vector origin;
        private Vector end;
        private int lifespan;

        private Color beginColor;
        private Color endColor;

        private int cycles;
        private float alphaStep;

        public bool hasFinished
        {
            get { return cycles == lifespan; }
        }

        public Vector Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Vector End
        {
            get { return end; }
            set { end = value; }
        }
        public Tracer(int lifespan, Color beginColor, Color endColor) : this(new Vector(0,0), new Vector(0,0), lifespan, beginColor, endColor)
        {}

        public Tracer(Vector origin, Vector end, int lifespan, Color beginColor, Color endColor) {
            this.origin = origin;
            this.end = end;
            this.lifespan = lifespan;
            this.beginColor = beginColor;
            this.endColor = endColor;

            this.cycles = 0;
            this.alphaStep = 1.0f / this.lifespan;
        }

        public Tracer Clone()
        {
            return new Tracer(this.origin, this.end, this.lifespan, this.beginColor, this.endColor);
        }
        public void Update()
        {
            if (cycles == lifespan)
                return;

            cycles++;
        }

        public void Render()
        {
            Color nextBeginColor = beginColor.Clone();
            Color nextEndColor = endColor.Clone();

            nextBeginColor.A = (byte)(beginColor.A - (beginColor.A * (cycles * alphaStep)));
            nextEndColor.A = (byte)(nextEndColor.A - (nextEndColor.A * (cycles * alphaStep)));

            Engine.DrawGradientLine(
                Camera.Instance.WorldToCameraPosition(origin),
                Camera.Instance.WorldToCameraPosition(end),
                nextBeginColor,
                nextEndColor,
                15);
        }
    }
}
