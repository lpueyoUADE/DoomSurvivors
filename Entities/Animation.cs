using DoomSurvivors.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
{
    public class Animation
    {
        
        public static class Speed
        {
            public const float slow = 0.5f;
            public const float regular = 0.35f;
            public const float fast = 0.3f;
            public const float fastest = 0.1f;
        }
        
        private List<IntPtr> keyFrames;
        private int currentFrameIndex;
        private float speed;
        private float currentAnimationTime;
        private bool isLoopEnabled;
        public int keyFramesCount => keyFrames.Count;
        public int CurrentFrameIndex => currentFrameIndex;
        public IntPtr CurrentFrame => keyFrames[currentFrameIndex];

        public Animation(List<IntPtr> keyFrames, float speed, bool isLoopEnabled)
        {
            this.keyFrames = keyFrames;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
        }

        public void reset()
        {
            this.currentFrameIndex = 0;
        }

        public void Update()
        {
            currentAnimationTime += Program.DeltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex >= keyFrames.Count)
                {
                    if (isLoopEnabled)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = keyFrames.Count - 1;
                    }
                }
            }
        }
    }
}

