﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
{
    public class AnimationController
    {
        private State currentAnimationState;
        private List<Animation> AnimationList;

        public State CurrentAnimationState => currentAnimationState;
        public Animation DyingAnimation => AnimationList[(int)State.Dying];
        public Animation AttackingAnimation => AnimationList[(int)State.Attacking];
        public AnimationController(
            Animation idle, 
            Animation moving = null, 
            Animation attacking = null,
            Animation pain = null,
            Animation dying = null, 
            Animation gibbing = null, 
            Animation death = null, 
            Animation gibDeath = null
            ) {

            this.AnimationList = new List<Animation> {
                idle,
                moving,
                attacking,
                pain,
                dying ,
                gibbing,
                death,
                gibDeath
            };

            this.currentAnimationState = State.Idle;
        }

        public IntPtr getCurrentAnimationFrame()
        {
            return this.AnimationList[(int)this.currentAnimationState].CurrentFrame;
        }
        public void SetCurrentAnimationState(State animationState)
        {
            bool isInterruptable = this.AnimationList[(int)this.currentAnimationState].IsInterruptable;
            bool isNotLooping = !this.AnimationList[(int)this.currentAnimationState].IsLooping;
            bool isDyingOrGibbing = animationState == State.Dying || animationState == State.Gibbing;
            if (isInterruptable || isNotLooping || isDyingOrGibbing)
            {
                if (this.currentAnimationState != animationState)
                {
                    if (this.AnimationList[(int)animationState] is null)
                    {
                        this.currentAnimationState = State.Idle;
                    }
                    else
                    {
                        this.currentAnimationState = animationState;
                    }

                    this.AnimationList[(int)this.currentAnimationState].reset();
                }
            }
        }

        public void Update(State state)
        {
            SetCurrentAnimationState(state);
            this.AnimationList[(int)currentAnimationState].Update();
        }
    }
}
