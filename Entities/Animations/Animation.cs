using DoomSurvivors.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities.Animations
{
    public class Animation : IRenderizable
    {
        
        public static class Speed
        {
            public const float slow = 0.5f;
            public const float regular = 0.35f;
            public const float fast = 0.3f;
            public const float faster = 0.2f;
            public const float fastest = 0.1f;
        }
        
        private List<Sprite> keyFrames;
        private int currentSpriteIndex;
        private float speed;
        private float currentAnimationTime;
        private bool isLoopEnabled;
        private bool isInterruptable;
        private bool isLooping;
        private bool hasBeenReseted;
        private bool hasEnded;

        private int maxHeight;

        public int keyFramesCount => keyFrames.Count;
        public int CurrentSpriteIndex => currentSpriteIndex;
        public Sprite CurrentFrame => keyFrames[currentSpriteIndex];

        public bool IsInterruptable => isInterruptable;

        public bool IsLooping => isLooping;
        public bool HasBeenReseted => hasBeenReseted;
        public bool HasEnded => hasEnded;

        public int MaxHeight => maxHeight;

        public Animation(List<Sprite> keyFrames, float speed, bool isLoopEnabled, bool isInterruptable)
        {
            this.keyFrames = keyFrames;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
            this.isInterruptable = isInterruptable;
            this.isLooping = false;
            this.hasBeenReseted = false;
            this.hasEnded = false;

            this.maxHeight = this.keyFrames.Max(frame => frame.Transform.H);
        }

        public void reset()
        {
            this.currentAnimationTime = 0;
            this.currentSpriteIndex = 0;
            this.hasBeenReseted = true;
            this.hasEnded = false;
        }

        public void Update()
        {
            if (hasBeenReseted || !isLooping && isLoopEnabled)
            {
                this.isLooping = true;
                this.hasBeenReseted = false;
                this.hasEnded = false;
                this.currentSpriteIndex = 0;
            }

            currentAnimationTime += Program.DeltaTime;

            if (currentAnimationTime >= speed)
            {
                currentSpriteIndex++;
                currentAnimationTime = 0;

                if (currentSpriteIndex == keyFrames.Count)
                {
                    this.isLooping = false;
                    this.hasEnded = true;
                    currentSpriteIndex = keyFrames.Count - 1;
                }
            }
        }

        public void Render()
        {}
    }
}

