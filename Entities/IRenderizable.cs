using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
{
    public interface IRenderizable
    {
        void Render();
        void Update();
    }
}
