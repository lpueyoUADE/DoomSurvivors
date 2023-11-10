using System;
using System.Collections.Generic;

namespace DoomSurvivors.Entities.Animations
{
    public class AnimationController
    {
        private State currentAnimationState;
        private List<Animation> AnimationList;
        private int maxHeight;
        public State CurrentAnimationState => currentAnimationState;
        public Animation DyingAnimation => AnimationList[(int)State.Dying];

        public Animation GibbingAnimation => AnimationList[(int)State.Gibbing];
        public Animation AttackingAnimation => AnimationList[(int)State.Attacking];

        public bool CanGib => this.AnimationList[(int)State.Gibbing] != null;

        public AnimationController(
            Animation idle, 
            Animation moving = null, 
            Animation attacking = null,
            Animation pain = null,
            Animation dying = null, 
            Animation gibbing = null, 
            Animation death = null, 
            Animation gibDeath = null,
            Animation special = null
            ) {

            this.AnimationList = new List<Animation> {
                idle,
                moving,
                attacking,
                pain,
                dying ,
                gibbing,
                death,
                gibDeath,
                special
            };

            this.currentAnimationState = State.Idle;

            this.maxHeight = 0;
            foreach (Animation animation in AnimationList)
            {
                if(!(animation is null) && animation.MaxHeight > this.maxHeight)
                    this.maxHeight = animation.MaxHeight;
            }
        }

        public Sprite CurrentAnimationSprite => this.AnimationList[(int)this.currentAnimationState].CurrentFrame;

        public int VerticalOffset => this.maxHeight - this.AnimationList[(int)this.currentAnimationState].CurrentFrame.Transform.H;

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
