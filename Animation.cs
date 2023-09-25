using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors
{
    public class Animation
    {
        private string name;
        private List<IntPtr> textures;
        private int currentFrameIndex = 0;
        private float speed = 0.5f;
        private float currentAnimationTime;
        private bool isLoopEnabled;
        public int FramesCount => textures.Count;
        public int CurrentFrameIndex => currentFrameIndex;
        public IntPtr CurrentFrame => textures[currentFrameIndex];

        public Animation(string name, List<IntPtr> frames, float speed, bool isLoopEnabled)
        {
            this.name = name;
            this.textures = frames;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
        }

        public void Update()
        {
            currentAnimationTime += Program.DeltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex >= textures.Count)
                {
                    if (isLoopEnabled)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = textures.Count - 1;
                    }
                }
            }
        }
    }
}

