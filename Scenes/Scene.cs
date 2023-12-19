using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors
{
    public abstract class Scene
    {
        public abstract void Load();
        public abstract void UnLoad();
        public abstract void Update();
        public abstract void Render();
        public abstract void Reset();
    }
}
