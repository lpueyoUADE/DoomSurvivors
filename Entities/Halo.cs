using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Halo : IRenderizable
    {
        private Transform transform;
        private Color beginColor;
        private Color endColor;
        private int steps;

        public Transform Transform
        {
            get => transform;
            set => transform = value;
        }

        public Halo(Transform transform, Color beginColor, Color endColor, int steps) {
            this.transform = transform;
            this.beginColor = beginColor;
            this.endColor = endColor;
            this.steps = steps;
        }
        public void Render()
        {
            Vector position = Camera.Instance.WorldToCameraPosition(transform.Position);
            Engine.DrawGradientEllipse(
                (int)position.X,
                (int)position.Y,
                transform.W / 2 + 15,
                transform.H / 2 + 15,
                transform.W / 2,
                transform.H / 2,
                beginColor,
                endColor,
                steps
            );
        }

        public void Update()
        {}
    }
}
