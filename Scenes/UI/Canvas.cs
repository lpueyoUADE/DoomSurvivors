using DoomSurvivors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Scenes.UI
{
    public class Canvas: IRenderizable
    {
        private Transform transform;
        private List<Button> UIButtons;
        private int selectedItemIndex;

        public Canvas(Transform transform, params Button[] UIButtons)
        {
            this.transform = transform;
            this.UIButtons = UIButtons.ToList();
            this.selectedItemIndex = 0;

            PlaceButtonsEvenly();

            UIButtons[selectedItemIndex].Select();
        }

        private void PlaceButtonsEvenly()
        {
            int totalHeight = UIButtons.Aggregate(0, (acc, x) => acc + x.Transform.H);
            int gap = (this.transform.H - totalHeight) / (UIButtons.Count + 1);

            for (int i = 0; i < UIButtons.Count; i++)
            {
                UIButtons[i].Transform.X = this.transform.X + ((this.transform.W - UIButtons[i].Transform.W) / 2);
                UIButtons[i].Transform.Y = this.transform.Y + gap * (i+1);
            }
        }

        public void Next()
        {
            UIButtons[selectedItemIndex].DeSelect();
            this.selectedItemIndex = (this.selectedItemIndex + 1) % UIButtons.Count;
            UIButtons[selectedItemIndex].Select();
        }

        public void Previous()
        {
            UIButtons[selectedItemIndex].DeSelect();
            this.selectedItemIndex = (this.selectedItemIndex + UIButtons.Count - 1) % UIButtons.Count;
            UIButtons[selectedItemIndex].Select();
        }

        public void Action()
        {
            UIButtons[selectedItemIndex].Action();
        }

        public void Render()
        {
            foreach (var UIButton in UIButtons)
            {
                UIButton.Render();
            }
        }

        public void Update()
        { }
    }
}
