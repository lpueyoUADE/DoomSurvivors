using DoomSurvivors.Entities;
using DoomSurvivors.Viewport;
using System;


namespace DoomSurvivors.Scenes
{
    public class MenuScene : Scene, IRenderizable
    {
        private IntPtr backgroundImage;
        private int width;
        private int height;
        public MenuScene(IntPtr backgroundImage, int width, int height)
        {
            this.backgroundImage = backgroundImage;
            this.width = width;
            this.height = height;
        }

        public override void Load()
        {
            Camera.Instance.Active = false;
        }

        public void Render()
        {
            Engine.Draw(this.backgroundImage, 0, 0, width, height);
        }
        public override void Update()
        {
            if (Engine.KeyPress(Engine.KEY_ENTER))
            {
                SceneController.Instance.ChangeScene(1);
            }

            this.Render();
            // background.Update();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void UnLoad()
        {
            Camera.Instance.Active = false;
        }
    }
}
