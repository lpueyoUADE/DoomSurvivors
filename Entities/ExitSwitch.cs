using DoomSurvivors.Entities.Animations;
using System;

namespace DoomSurvivors.Entities
{
    public class ExitSwitch : Wall, IInteractable
    {
        public Sprite spriteOn;
        public Sprite spriteOff;
        public bool state;
        public bool isOneTimeUse;
        public bool usedAtLeastOnce;

        private Sound actionSound;
        public enum ExitSwitchType
        {
            Regular
        }
        public ExitSwitch(Transform transform, Sprite spriteON, Sprite spriteOff, bool isOneTimeUse=false, CollisionType collisionType = CollisionType.Static, bool drawShadow = true, bool drawBoundingBox = false) : base(transform, spriteOff, collisionType, drawShadow, drawBoundingBox)
        {
            this.spriteOn = spriteON;
            this.spriteOff = spriteOff;
            this.state = false;
            this.isOneTimeUse = isOneTimeUse;
            this.usedAtLeastOnce = false;
            this.actionSound = new Sound("assets/Sounds/Switch/DSSWTCHN.wav");
        }

        public void SwitchState()
        {
            usedAtLeastOnce = true;
            state = !state;                
            (this.spriteOn, this.Sprite) = (this.Sprite, this.spriteOn);
        }

        public void OnInteract()
        {
            if (!isOneTimeUse || !usedAtLeastOnce)
                this.actionSound.PlayOnce();
                SwitchState();
                SceneController.Instance.ChangeScene(2);
        }
    }
}
