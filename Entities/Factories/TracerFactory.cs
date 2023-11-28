using DoomSurvivors.Utilities;

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
                new Color(0xff0000aa),
                new Color(0xffff00ff)
            );
        }
    }
}
