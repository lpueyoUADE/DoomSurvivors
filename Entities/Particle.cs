using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Viewport;
using System;
using System.Windows;

namespace DoomSurvivors.Entities
{
    public enum ParticleType
    {
        Blood,
        WallHit,
        RocketLauncherHit, 
        PlasmaHit,
        BFGHit,
        ImpFireBallHit,
        HellKnightFireBallHit,
        BaronFireBallHit,
        CacoDemonFireBallHit,
        ReventantRocketLauncherHit,
        ArachnotronPlasmaRifleHit,
        MancubusFireBallHit
    }
    public class Particle : IRenderizable
    {
        private Vector origin;
        private Animation animation;
        
        public bool HasEnded
        {
            get => animation.HasEnded;
        }
        
        public Particle(Vector origin, Animation animation) { 
            this.origin = origin;
            this.animation = animation;
        }
        
        public void Render()
        {
            Vector position = new Vector(this.origin.X - animation.CurrentFrame.Transform.W / 2, this.origin.Y - animation.CurrentFrame.Transform.H / 2);
            position = Camera.Instance.WorldToCameraPosition(position);
            Engine.Draw(animation.CurrentFrame, position.X, position.Y, animation.CurrentFrame.Transform.W, animation.CurrentFrame.Transform.H);
        }

        public void Update()
        {
            this.animation.Update();
        }
    }
}
