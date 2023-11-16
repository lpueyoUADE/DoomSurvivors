using DoomSurvivors.Entities;
using DoomSurvivors.Main;
using DoomSurvivors.Scenes.UI;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;
using static DoomSurvivors.Scenes.UI.Font;
using Text = DoomSurvivors.Scenes.UI.Text;

namespace DoomSurvivors.Scenes
{
    public class MenuScene : Scene, IRenderizable
    {
        private IntPtr backgroundImage;
        private Canvas canvas;
        public MenuScene(IntPtr backgroundImage)
        {
            this.backgroundImage = backgroundImage;
            this.canvas = new Canvas
            (
                new Transform(0, Engine.Transform.H / 2, Engine.Transform.W, Engine.Transform.H / 2),
                new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(1), "JUEGO NUEVO"),
                new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => Environment.Exit(0), "SALIR")
            );
        }

        public void Render()
        {
            Engine.Draw(this.backgroundImage, 0, 0, Engine.Transform.W, Engine.Transform.H);
            canvas.Render();
            
        }
        public override void Update()
        {
            /*if (Engine.KeyPress(Engine.KEY_ENTER))
            {
                SceneController.Instance.ChangeScene(1);
            }
            */
            /*
            Text text = new Text(200,200, 5, FontType.DoomFont, 14, Color.White, "PRUEBA NOMAS", new Color(255, 0, 255, 255));

            Text text2 = new Text(400, 200, 15, FontType.DoomFont, 28, Color.White, "PRUEBA NOMAS", new Color(255,0,0,255));

            Button button1 = new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255,0,0,255), () => SceneController.Instance.ChangeScene(1), "JUEGO NUEVO");

            text.Render();
            text2.Render();

            button1.Select();
            button1.DeSelect();
            button1.Render();
            */


            canvas.Update();
            // background.Update();
            this.Render();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
        public override void Load()
        {
            Camera.Instance.Active = false;

            Program.UpArrowPressedAction += UpArrowPressedActionHandler;
            Program.DownArrowPressedAction += DownArrowPressedActionHandler;
            Program.EnterPressedAction += EnterPressedActionHandler;
        }


        private void UpArrowPressedActionHandler()
        {
            canvas.Previous();
        }
        private void DownArrowPressedActionHandler()
        {
            canvas.Next();
        }
        private void EnterPressedActionHandler()
        {
            canvas.Action();
        }


        public override void UnLoad()
        {
            Camera.Instance.Active = false;

            Program.UpArrowPressedAction -= UpArrowPressedActionHandler;
            Program.DownArrowPressedAction -= DownArrowPressedActionHandler;
            Program.EnterPressedAction -= EnterPressedActionHandler;
        }
    }
}
