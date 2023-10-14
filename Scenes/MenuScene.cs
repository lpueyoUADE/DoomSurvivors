using DoomSurvivors.Viewport;
using System;


namespace DoomSurvivors.Scenes
{
    public class MenuScene : Scene
    {
        private Map background;
        
        public MenuScene(Map background)
        {
            this.background = background;
        }

        public override void Load()
        {
            Camera.Instance.Active = false;
        }
        public override void Update()
        {
            if (Engine.KeyPress(Engine.KEY_ENTER))
            {
                SceneController.Instance.changeScene(1);
            }

            background.Update();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
