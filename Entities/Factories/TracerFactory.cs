using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities.Factories
{
    public static class TracerFactory
    {
        public static Tracer RedTracer() {
            return new Tracer(
                20,
                new Color(0xff000000),
                new Color(0xff0000ff)
            );
        }

        public static Tracer YellowTracer()
        {
            return new Tracer(
                20,
                new Color(0xff000080),
                new Color(0xffff00ff)
            );
        }
    }
}
