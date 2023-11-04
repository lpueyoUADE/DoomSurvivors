using DoomSurvivors.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DoomSurvivors.Entities.Animation;

namespace DoomSurvivors.Entities
{
    public class Animation2 : IRenderizable
    {

        IntPtr spriteSheet;
        List<IntPtr> frames;

        private int currentFrameIndex;
        private float speed;
        private float currentAnimationTime;
        private bool isLoopEnabled;
        private bool isInterruptable;
        private bool isLooping;

        public int framesCount => frames.Count;
        public int CurrentFrameIndex => currentFrameIndex;
        public IntPtr CurrentFrame => frames[currentFrameIndex];
        public bool IsInterruptable => isInterruptable;
        public bool IsLooping => isLooping;

        public Animation2(IntPtr spriteSheet, List<Transform> frames) { 
            //this.spriteSheet = spriteSheet;

            //foreach (Transform t in frames)
            //{
            //    this.frames = Engine.LoadImage();                   
            //}

            //this.speed = speed;
            //this.frames = frames;
            //this.isLoopEnabled = isLoopEnabled;
            //this.isInterruptable = isInterruptable;
            //this.isLooping = false;
        }

        public void Render()
        {}

        public void Update()
        {
            //if (!isLooping && isLoopEnabled)
            //{
            //    this.isLooping = true;
            //    this.currentFrameIndex = 0;
            //}

            //currentAnimationTime += Program.DeltaTime;

            //if (currentAnimationTime >= speed)
            //{
            //    currentFrameIndex++;
            //    currentAnimationTime = 0;

            //    if (currentFrameIndex == keyFrames.Count)
            //    {
            //        this.isLooping = false;
            //        currentFrameIndex = keyFrames.Count - 1;
            //    }
            //}
        }
    }
}
