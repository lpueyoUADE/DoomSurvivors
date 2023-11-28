using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Entities.Weapons;
using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DoomSurvivors.Scenes.UI
{
    public class HUD : UIElement, IRenderizable
    {
        private Player player;
        private Sprite hudSprite;

        private StatusBar lifeBar;
        private StatusBar armorBar;
        private StatusBar xpBar;
        private StatusBar ammoBar;
        private StatusBar coolDownBar;

        private Dictionary<WeaponID, Sprite> weapons;
        private Image selectedWeaponImage;
        private WeaponID selectedWeaponID;

        private Dictionary<AmmoType, Sprite> ammoTypes;
        private Image selectedAmmoTypeImage;
        private AmmoType selectedAmmoType;

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
                new Color(0xC39B2FFF)
            );

            this.ammoBar = new StatusBar(
                new Transform(this.Transform.X + 315, this.Transform.Y + 37, 43, 21),
                1.0f,
                5,
                10,
                "",
                new Vector(0, 0),
                Color.White,
                new Color(0xAF7B1FFF)
            );

            this.weapons = new Dictionary<WeaponID, Sprite>
            {
                { WeaponID.Pistol, new Sprite("HUD", new Transform(62, 88, 29, 14)) },
                { WeaponID.Chainsaw, new Sprite("HUD", new Transform(92, 88, 62, 24)) },
                { WeaponID.Shotgun, new Sprite("HUD", new Transform(155, 88, 63, 12)) },
                { WeaponID.SuperShotgun, new Sprite("HUD", new Transform(219, 88, 54, 14)) },
                { WeaponID.Chaingun, new Sprite("HUD", new Transform(274, 88, 54, 16)) },
                { WeaponID.RocketLauncher, new Sprite("HUD", new Transform(329, 88, 62, 16)) },
                { WeaponID.PlasmaRifle, new Sprite("HUD", new Transform(392, 88, 54, 16)) },
                { WeaponID.BFG, new Sprite("HUD", new Transform(447, 88, 61, 36)) },
            };

            this.selectedWeaponID = WeaponID.Pistol;
            this.selectedWeaponImage = new Image(new Transform(this.Transform.X + 316, this.Transform.Y + 6, 74,22), weapons[selectedWeaponID]);


            this.ammoTypes = new Dictionary<AmmoType, Sprite>
            {
                { AmmoType.Bullet, new Sprite("HUD", new Transform(1, 88, 9, 11)) },
                { AmmoType.Shells, new Sprite("HUD", new Transform(12, 88, 15, 7)) },
                { AmmoType.Plasma, new Sprite("HUD", new Transform(29, 88, 17, 12)) },
                { AmmoType.Rocket, new Sprite("HUD", new Transform(48, 88, 12, 27)) },
            };

            this.selectedAmmoType = AmmoType.Bullet;
            this.selectedAmmoTypeImage = new Image(new Transform(this.Transform.X + 368, this.Transform.Y + 37, 21, 21), ammoTypes[selectedAmmoType]);
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
            ammoBar.Render();

            selectedWeaponImage.Render();
            selectedAmmoTypeImage.Render();
        }

        public override void Update()
        {
            lifeBar.Fullness = player.Life/ (float)player.MaxLife;
            lifeBar.DisplayValue = player.Life.ToString();

            armorBar.Fullness = player.Armor / (float)player.MaxArmor;
            armorBar.DisplayValue = player.Armor.ToString();

            coolDownBar.Fullness = (float)(DateTime.Now - player.CurrentWeapon.LastShotTime).TotalSeconds / player.CurrentWeapon.Cooldown;

            ammoBar.Fullness = (float)player.CurrentWeapon.Ammo / player.CurrentWeapon.MaxAmmo;
            ammoBar.DisplayValue = player.CurrentWeapon.Ammo.ToString();
        }
    }
}
