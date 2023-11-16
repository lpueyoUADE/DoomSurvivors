using DoomSurvivors.Entities.Animations;
using System;

namespace DoomSurvivors.Entities
{
    public class ExitSwitch : Wall
    {
        public Sprite spriteOn;

        public enum ExitSwitchType
        {
            Regular
        }
        public ExitSwitch(Transform transform, Sprite spriteON, Sprite spriteOff, CollisionType collisionType = CollisionType.Static, bool drawShadow = true, bool drawBoundingBox = false) : base(transform, spriteOff, collisionType, drawShadow, drawBoundingBox)
        {
            this.spriteOn = spriteON;
        }
    }
}
