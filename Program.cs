using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace DoomSurvivors
{
    class Program
    {
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;

        static void Main(string[] args)
        {
            Engine.Initialize();
            Program.Initialize();

            Entity player = new Entity( // Player
                new Sdl.SDL_Rect(100, 100, 57, 59),
                12.0f,
                new AnimationController(
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_2.png"),
                        },
                        Animation.Speed.regular,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_3.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_moving_4.png"),
                        },
                        Animation.Speed.fastest,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_attacking_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_attacking_1.png"),
                        },
                        Animation.Speed.fast,
                        true
                    )
                )
            );

            List<Entity> enemyList = new List<Entity> { // Enemy List
                new Entity(
                    new Sdl.SDL_Rect(500, 500, 37, 55),
                    5.0f,
                    new AnimationController(
                        new Animation(
                            new List<IntPtr>{
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_1.png"),
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_2.png"),
                            },
                            Animation.Speed.slow,
                            true
                        ),
                        new Animation(
                            new List<IntPtr>{
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_moving_1.png"),
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_moving_2.png"),
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_moving_3.png"),
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_moving_4.png"),
                            },
                            Animation.Speed.fast,
                            true
                        )
                    ),
                    player, // Chasing Target,
                    250.0f  // Vision radius
                ),
            };
            // TODO Crear Factories de Entities y Scenes
            PlayableScene E1 = new PlayableScene(
                enemyList,
                player,
                new Map("E1", Engine.LoadImage("assets/Maps/e1_test.png")),
                false, // Show Bounding Boxes
                true   // Show vision Radius
            );

            E1.Load();

            while (true)
            {
                Program.UpdateTime();
                
                PollEvents();

                Engine.Clear();
                
                E1.Update();

                Engine.Show();

                Sdl.SDL_Delay(16); // aprox 60 FPS
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

            // player.Update();

            /*foreach (Enemy enemy in enemyList)
            {
                enemy.Update();
            }
            */

        }

        public static void UpdateTime() {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;
        }
        public static void Render()

        {
            /*
            
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;


            Engine.Draw(image, 0, 0);


            player.Render();

            foreach (Enemy enemy in enemyList)
            {
                enemy.Render();
            }

            */
        }

    }

}
