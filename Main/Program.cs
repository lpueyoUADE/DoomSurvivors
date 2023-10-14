using DoomSurvivors.Entities;
using DoomSurvivors.Scenes;
using DoomSurvivors.Viewport;
using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace DoomSurvivors.Main
{
    class Program
    {
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;

        public static Crosshair crosshair;

        public static bool DEBUG_MODE = false;
        // TODOS
        /*
            . HUD 
            . Camera movement
            . Weapon system
            . Collisions (Walls and enemies)
            . Maps system
            . MenuScenes (menu items)

            . Dying
            . Stats (health, xp)
            . Items
            . Boosts
            
            . Factories (Monsters & Weapons)
            . Sounds
        */



        static void Main(string[] args)
        {
            Engine.Initialize();
            Program.Initialize();

            Player player = new Player( // Player
                new Transform(0, 0, 57, 59),
                8.0f,
                new AnimationController(
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_1.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/DoomGuy_idle_2.png"),
                        },
                        Animation.Speed.regular,
                        true,
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
                        true,
                        true
                    ),
                    new Animation(
                        new List<IntPtr>{
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_attacking_2.png"),
                            Engine.LoadImage($"assets/Sprites/DoomGuy/Doomguy_attacking_1.png"),
                        },
                        Animation.Speed.fastest,
                        true,
                        false
                    )
                ),
                new WeaponController(
                    new List<Weapon> {
                        new Weapon(WeaponID.Pistol,Mechanism.SemiAutomatic, 10, 0.1f)
                    }
                )
            );
            List<Monster> enemyList = new List<Monster> { // Enemy List
                new Monster(
                    new Transform(200, 200, 37, 55),
                    5.0f,
                    new AnimationController(
                        new Animation(
                            new List<IntPtr>{
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_1.png"),
                                Engine.LoadImage($"assets/Sprites/Zombie/Zombie_idle_2.png"),
                            },
                            Animation.Speed.slow,
                            true,
                            true
                        ),
                        new Animation(
                            new List<IntPtr>{
                                Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_1.png"),
                                Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_2.png"),
                                Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_3.png"),
                                Engine.LoadImage("assets/Sprites/Zombie/Zombie_moving_4.png"),
                            },
                            Animation.Speed.faster,
                            true,
                            true
                        )
                    ),
                    new WeaponController(
                        new List<Weapon> {
                            new Weapon(WeaponID.Pistol,Mechanism.SemiAutomatic, 10, 0.5f)
                        }
                    ),
                    player, // Chasing Target,
                    250.0f  // Vision radius
                )
            };
            // TODO Crear Factories de Entities y Scenes
            MenuScene MainMenuScene = new MenuScene(new Map("E1", "assets/Maps/main_menu.png"));
            MenuScene WinScene = new MenuScene(new Map("E1","assets/Maps/win.png"));
            MenuScene LoseScene = new MenuScene(new Map("E1", "assets/Maps/lose.png"));
            PlayableScene E1Scene = new PlayableScene(
                enemyList,
                player,
                new Map("E1","assets/Maps/e1_test.png"),
                DEBUG_MODE, // Show Bounding Boxes
                DEBUG_MODE   // Show vision Radius
            );

            // E1Scene.Load();

            SceneController.Instance.setScenes(
                new List<Scene> {
                    MainMenuScene,
                    E1Scene,
                    WinScene,
                    LoseScene
                }
            );

            SceneController.Instance.changeScene(0);

            // Crosshair
            crosshair = new Crosshair(true);

            // Camera
            Camera.Instance.setCamera(player, new Transform(0, 0));

            while (true) // Main loop
            {
                Program.UpdateTime();

                SceneController.Instance.Load();

                PollEvents();

                Engine.Clear();

                SceneController.Instance.Update();

                crosshair.Update();

                if (DEBUG_MODE)
                {
                    Engine.DrawRect(Engine.Transform.W / 2, 0, 1, Engine.Transform.H, 0xfff);
                    Engine.DrawRect(0, Engine.Transform.H / 2, Engine.Transform.W, 1, 0xfff);
                }


                Engine.Show();  // Show current frame

                Sdl.SDL_Delay(16); // aprox 60 FPS
            }
        }

        private static void PollEvents()
        {
            Sdl.SDL_PumpEvents();
            Sdl.SDL_Event sdl_event;
            Sdl.SDL_PollEvent(out sdl_event);

            switch (sdl_event.type)
            {
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
            _startTime = DateTime.Now;
        }

        public static void UpdateTime()
        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;
        }
    }
}
