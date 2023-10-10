using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoomSurvivors
{
    internal class PlayableScene : Scene
    {
        private List<Monster> enemyList;
        private Player player;
        private Map map;
        private bool showBoundingBox;
        private bool showVisionRadius;

        public bool ShowBoundingBox {
            get { return this.showBoundingBox; }
            set { this.showBoundingBox = value; }
        }
        public bool ShowVisionRadius
        {
            get { return this.showVisionRadius; }
            set { this.showVisionRadius = value; }
        }


        public PlayableScene(List<Monster> enemyList, Player player, Map map, bool showBoundingBox=false, bool showVisionRadius=false)
        {
            this.enemyList = enemyList;
            this.player = player;
            this.map = map;
            this.showBoundingBox = showBoundingBox;
            this.showVisionRadius = showVisionRadius;
        }

        private bool IsColliding(Entity a, Entity b) {
            bool xAxisColliding = a.Rect.x < b.Rect.x + b.Rect.w && a.Rect.x + a.Rect.w > b.Rect.x;
            bool yAxisColliding = a.Rect.y < b.Rect.y + b.Rect.h && a.Rect.y + a.Rect.h > b.Rect.y;

            return xAxisColliding && yAxisColliding;
        }
        private void checkCollisions()
        {
            foreach (Monster enemy in enemyList)
            {
                if(IsColliding(enemy, player))
                {
                    Console.WriteLine("Colliding!");
                    SceneController.Instance.changeScene(3);
                    break;
                }
            }
        }

        public override void Load()
        {
            foreach (Monster enemy in enemyList)
            {
                enemy.ShowBoundingBox = showBoundingBox;
                enemy.ShowVisionRadius = showVisionRadius;
            }

            player.ShowBoundingBox = showBoundingBox;
        }

        public override void Update()
        {
            map.Draw();

            // check-then-update approach
            checkCollisions();

            foreach (Entity enemy in enemyList)
            {
                enemy.Update();
            }

            player.Update();
        }
    }
}
