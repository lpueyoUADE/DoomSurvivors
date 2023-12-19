using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Animations;

namespace DoomSurvivors.Scenes.UI
{
    public class Image : IRenderizable
    {
        private Transform transform;
        private Sprite sprite;

        public Sprite Sprite
        { 
            get => sprite;
            set => sprite = value;
        }

        public Image(Transform transform, Sprite sprite)
        {
            this.transform = transform;
            this.sprite = sprite;
        }

        public void Render()
        {
           Engine.Draw(
                sprite, 
                this.transform.X + transform.W / 2 - sprite.Transform.W / 2,
                this.transform.Y + transform.H / 2 - sprite.Transform.H / 2,
                sprite.Transform.W,
                sprite.Transform.H
            );
        }

        public void Update()
        {}
    }
}
