using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors
{
    public class MenuScene : Scene
    {
        private Map background;
        
        public MenuScene(Map background)
        {
            this.background = background;
        }

        public override void Load()
        {}
        public override void Update()
        {
            if (Engine.KeyPress(Engine.KEY_ENTER))
            {
                SceneController.Instance.changeScene(1);
            }

            background.Draw();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
