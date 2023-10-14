using DoomSurvivors.Entities;
using DoomSurvivors.Viewport;
using System;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Scenes
{
    public class Map
    {
        private string name;
        private IntPtr mapTexture;
        private Transform transform;

        public Transform Transform { get { return this.transform; } }

        public Map(string name, string mapTexture)
        {
            this.name = name;
            this.mapTexture = Engine.LoadImage(mapTexture);
            this.transform = new Transform(0, 0, 1280, 1280);
        }

        public void Update()
        {
            Vector newPosition = Camera.Instance.WorldToCameraPosition(this.transform.Position);
            Engine.Draw(mapTexture, newPosition.X, newPosition.Y);
        }
    }
}
