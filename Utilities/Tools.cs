using System.Windows;

namespace DoomSurvivors.Utilities
{
    public static class Tools
    {
        public static uint Lerp(uint begin, uint end, float by)
        {
            // Integer Lerp
            return (uint)Lerp((double)begin, (double)end, by);
        }
        public static double Lerp(double begin, double end, float by)
        {
            // Integer Lerp
            return begin * (1 - by) + end * by;
        }

        public static Vector Lerp(Vector begin, Vector end, float by)
        {
            double retX = Lerp((double)begin.X, (double)end.X, by);
            double retY = Lerp((double)begin.Y, (double)end.Y, by);
            return new Vector(retX, retY);
        }
    }
}
