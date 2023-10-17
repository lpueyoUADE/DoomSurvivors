using DoomSurvivors.Entities;
using DoomSurvivors.Utilities;
using System;
using System.Windows;
using Tao.Sdl;

namespace DoomSurvivors.Viewport
{
    public class Camera
    {
        private static Camera instance;

        private Entity target;
        private Transform transform;

        private float panSpeed;

        private bool active;

        public Entity Target {
            get{ return this.target; }
            set { this.target = value; }
        }
        
        public bool Active { 
            get {  return this.active; }
            set { this.active = value; }
        }
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Camera();
                }

                return instance;
            }
        }

        public void setCamera(Entity target, Transform transform)
        {
            if (instance == null)
            {
                instance = new Camera();
            }

            this.target = target;
            this.transform = transform;
        }

        private Camera()
        {
            this.target = null;
            this.transform = null;
            this.panSpeed = 0.5f;
        }
        private void PanToTarget()
        {
            this.transform.Position = Tools.Lerp(this.transform.Position, target.Transform.PositionCenter, panSpeed);
        }

        public Vector WorldToCameraPosition(Vector other)
        {
            return active ? other - (this.transform.Position - Engine.Transform.PositionCenter) : new Vector(0,0);
        }

        public Vector CameraToWorldPosition(Vector other)
        {
            return active ? other + this.transform.Position - Engine.Transform.PositionCenter : new Vector(0, 0);
        }

        public void Update()
        {
            PanToTarget();
        }
    }
}
