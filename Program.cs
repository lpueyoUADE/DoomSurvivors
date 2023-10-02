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

        public static Entity player1 = new Entity(new Sdl.SDL_Rect(100, 100, 50, 50), 12.0);
        public static Entity enemy1 = new Entity(new Sdl.SDL_Rect(200, 200, 50, 50), 12.0);
        static void Main(string[] args)
        {
            Engine.Initialize();
            Program.Initialize();

            player1.ShowBoundingBox = true;
            enemy1.ShowBoundingBox = true;
            player1.PlayerControlled = true;
            enemy1.PlayerControlled = false;

            while (true)
            {
                PollEvents();

                Engine.Clear();
                Engine.Draw(image, 0, 0);
                // GameManager.Instance.Update
                // GameManager.Instance.Render();

                Program.UpdateTime();

                player1.Update();
                enemy1.Update();
                Engine.Show();

                Sdl.SDL_Delay(16);
            }
        }

        private static void PollEvents()
        {
            Sdl.SDL_PumpEvents();
            Sdl.SDL_Event sdl_event;
            Sdl.SDL_PollEvent(out sdl_event);

            switch (sdl_event.type) {
                case Sdl.SDL_QUIT:
                    Environment.Exit(0);
                    break;

                case Sdl.SDL_KEYDOWN: // Single stroke keys
                    switch (sdl_event.key.keysym.sym)
                    {
                        case Sdl.SDLK_ESCAPE:
                            break;
                    }
                    break;
            }
        }

        private static void Initialize()
        {
            // Engine.Initialize();
            // player = (new Character(new Vector2(0, 0), 100, "assets/player.png"));
            _startTime = DateTime.Now;
            // enemyList.Add(new Enemy(400, 400, 1));
            // enemyList.Add(new Enemy(600, 400, 1));
        }

        public static void Update()
        {

            player.Update();

            foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
            }

        }

        public static void UpdateTime() {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;
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
