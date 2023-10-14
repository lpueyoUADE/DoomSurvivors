using DoomSurvivors.Entities;
using DoomSurvivors.Scenes;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;

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

        private void checkCollisions()
        {
            foreach (Monster enemy in enemyList)
            {
                if(player.IsColliding(enemy))
                {
                    Console.WriteLine("Colliding!");
                    SceneController.Instance.changeScene(3);
                    break;
                }
            }
        }

        public override void Load()
        {
            Camera.Instance.Active = true;
            foreach (Monster enemy in enemyList)
            {
                enemy.ShowBoundingBox = showBoundingBox;
                enemy.ShowVisionRadius = showVisionRadius;
            }

            player.ShowBoundingBox = showBoundingBox;
        }

        public override void Update()
        {
            Camera.Instance.Update();
            map.Update();

            // check-then-update approach
            checkCollisions();

            foreach (Entity enemy in enemyList)
            {
                enemy.Update();
            }

            player.Update();

        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
