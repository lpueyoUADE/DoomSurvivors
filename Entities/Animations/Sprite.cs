using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities.Animations
{
    public class Sprite
    {
        private readonly IntPtr image;
        private readonly Transform transform;

        public IntPtr Image => image;
        public Transform Transform => transform;

        public Sprite(IntPtr image, Transform transform)
        {
            this.image = image;
            this.transform = transform;
        }
    }
}
