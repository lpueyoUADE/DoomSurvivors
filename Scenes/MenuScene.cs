using DoomSurvivors.Entities;
using DoomSurvivors.Main;
using DoomSurvivors.Scenes.UI;
using DoomSurvivors.Utilities;
using DoomSurvivors.Viewport;
using System;

namespace DoomSurvivors.Scenes
{
    public class MenuScene : Scene, IRenderizable
    {
        private IntPtr backgroundImage;
        private Color backgroundColor;
        private Canvas canvas;
        public MenuScene(IntPtr backgroundImage, Canvas canvas, Color backgroundColor=null)
        {
            this.backgroundImage = backgroundImage;
            this.backgroundColor = backgroundColor;
            this.canvas = canvas;
        }
        public override void Render()
        {
            if(backgroundImage != IntPtr.Zero)
                Engine.Draw(this.backgroundImage, 0, 0, Engine.Transform.W, Engine.Transform.H);

            if(backgroundColor != null)
                Engine.DrawRect(0, 0, (int)Engine.Transform.W, (int)Engine.Transform.H, backgroundColor);

            canvas.Render();
            
        }
        public override void Update()
        {
            canvas.Update();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
        public override void Load()
        {
            // Camera.Instance.Active = false;

            Program.UpArrowPressedAction += UpArrowPressedActionHandler;
            Program.DownArrowPressedAction += DownArrowPressedActionHandler;
            Program.EnterPressedAction += EnterPressedActionHandler;
            Program.LeftMouseButtonReleasedAction += LeftMouseButtonReleasedActionHandler;
            Program.MouseWheelDownAction += MouseWheelDownActionHandler;
            Program.MouseWheelUpAction += MouseWheelUpActionHandler;
        }
        public override void UnLoad()
        {
            // Camera.Instance.Active = true;

            Program.UpArrowPressedAction -= UpArrowPressedActionHandler;
            Program.DownArrowPressedAction -= DownArrowPressedActionHandler;
            Program.EnterPressedAction -= EnterPressedActionHandler;
            Program.LeftMouseButtonReleasedAction -= LeftMouseButtonReleasedActionHandler;
            Program.MouseWheelDownAction -= MouseWheelDownActionHandler;
            Program.MouseWheelUpAction -= MouseWheelUpActionHandler;
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
        private void LeftMouseButtonReleasedActionHandler()
        {
            canvas.Action();
        }

        private void MouseWheelUpActionHandler() 
        {
            canvas.Previous();
        }
        private void MouseWheelDownActionHandler()
        {
            canvas.Next();
        }
    }
}
