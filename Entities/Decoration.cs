

using System.Windows;

namespace DoomSurvivors.Entities
{
    public class Decoration
    {
        public enum DecorationType
        {
            TestDecoration
        }
        public struct DecorationPlacer
        {
            public DecorationType decorationType;
            public Vector position;

            public DecorationPlacer(DecorationType decorationType, Vector position) : this() 
            { 
                this.decorationType = decorationType;
                this.position = position; 
            }
        }
    }
}
