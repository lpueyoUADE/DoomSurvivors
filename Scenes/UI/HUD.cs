using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using System.Windows;

namespace DoomSurvivors.Scenes.UI
{
    public class HUD : UIElement, IRenderizable
    {
        private Player player;
        private Sprite hudSprite;

        StatusBar lifeBar;
        StatusBar armorBar;
        StatusBar xpBar;
        StatusBar coolDownBar;

        public Player Player { 
            get { return player; } 
            set { player = value; }
        }
        public HUD(int padding, Player player) : base(0, 0, padding, null)
        {
            this.player = player;
            this.hudSprite = new Sprite("HUD", new Transform(1, 1, 394, 84));

            this.Transform = new Transform(
                (int)Engine.Transform.PositionCenter.X - this.hudSprite.Transform.W / 2,
                (int)Engine.Transform.H - this.hudSprite.Transform.H - 10,
                this.hudSprite.Transform.W,
                this.hudSprite.Transform.H
            );

            this.lifeBar = new StatusBar(
                new Transform(this.Transform.X + 5, this.Transform.Y + 5, 249, 22),
                1.0f,
                5,
                10,
                "",
                new Vector(0, 0),
                Color.White,
                Color.Red
            );

            this.armorBar = new StatusBar(
                new Transform(this.Transform.X + 5, this.Transform.Y + 37, 249, 21),
                1.0f,
                5,
                10,
                "100",
                new Vector(0, 0),
                Color.White,
                new Color(0x53AF47FF)
            );

            this.xpBar = new StatusBar(
                new Transform(this.Transform.X + 5, this.Transform.Y + 68, 249, 11),
                1.0f,
                1,
                7,
                "100/100",
                new Vector(5,0),
                Color.White,
                new Color(0x5353FFFF)
            );

            this.coolDownBar = new StatusBar(
                new Transform(this.Transform.X + 315, this.Transform.Y + 68, 74, 11),
                1.0f,
                1,
                7,
                "",
                new Vector(5, 0),
                Color.White,
                new Color(0x8888FFFF)
            );

        }

        public override void Render()
        {
            Engine.Draw(
                this.hudSprite,
                this.Transform.X,
                this.Transform.Y,
                this.Transform.W,
                this.Transform.H
            );

            lifeBar.Render();
            armorBar.Render();
            xpBar.Render();
            coolDownBar.Render();
        }

        public override void Update()
        {
            lifeBar.Fullness = player.Life/ (float)player.MaxLife;
            lifeBar.DisplayValue = player.Life.ToString();
        }
    }
}
