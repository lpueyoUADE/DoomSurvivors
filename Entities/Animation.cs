using DoomSurvivors.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
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
        
        private List<IntPtr> keyFrames;
        private int currentFrameIndex;
        private float speed;
        private float currentAnimationTime;
        private bool isLoopEnabled;
        private bool isInterruptable;
        private bool isLooping;

        public int keyFramesCount => keyFrames.Count;
        public int CurrentFrameIndex => currentFrameIndex;
        public IntPtr CurrentFrame => keyFrames[currentFrameIndex];

        public bool IsInterruptable => isInterruptable;

        public bool IsLooping => isLooping;

        public Animation(List<IntPtr> keyFrames, float speed, bool isLoopEnabled, bool isInterruptable)
        {
            this.keyFrames = keyFrames;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
            this.isInterruptable = isInterruptable;
            this.isLooping = false;
        }

        public void reset()
        {
            this.currentAnimationTime = 0;
            this.currentFrameIndex = 0;
        }

        public void Update()
        {
            if (!isLooping && isLoopEnabled)
            {
                this.isLooping = true;
                this.currentFrameIndex = 0;
            }

            currentAnimationTime += Program.DeltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex == keyFrames.Count)
                {
                    this.isLooping = false;
                    currentFrameIndex = keyFrames.Count - 1;
                }
            }
        }

        public void Render()
        {}
    }
}

