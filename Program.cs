using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace DoomSurvivors
{
    class Program
    {

        private static IntPtr image = Engine.LoadImage("assets/fondo.png");
        public static Character player;
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;
        public static List<Enemy> enemyList = new List<Enemy>();

        static void Main(string[] args)
        {
            Initialize();
            // amongus

            while (true)
            {
                GameManager.Instance.Update();

                GameManager.Instance.Render();

                Sdl.SDL_Delay(20);
            }
        }

        private static void Initialize()
        {
            Engine.Initialize();
            player = (new Character(new Vector2(0, 0), 100, "assets/player.png"));
            _startTime = DateTime.Now;
            enemyList.Add(new Enemy(400, 400, 1));
            enemyList.Add(new Enemy(600, 400, 1));
        }

        public static void Update()
        {

            player.Update();

            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
            }

        }

        public static void Render()

        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;


            Engine.Draw(image, 0, 0);


            player.Render();

            foreach (Enemy enemy in enemyList)
            {
                enemy.Render();
            }


        }

    }

}
