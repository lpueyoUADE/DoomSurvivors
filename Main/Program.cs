using DoomSurvivors.Entities;
using DoomSurvivors.Scenes;
using DoomSurvivors.Viewport;
using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using Tao.Sdl;
using System.Windows;
using DoomSurvivors.Entities.Factories;

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
            . Camera movement (OK)
            . Weapon system
            . Collisions (Walls and enemies)
            . Maps system
            . MenuScenes (menu items)

            . Dying
            . Stats (health, xp)
            . Items
            . Boosts
            
            . Factories (Monsters & Weapons)
            . Interfaces
            . Sounds
        */

        public static event Action LeftMouseButtonReleasedAction;
        public static event Action RightMouseButtonReleasedAction;

        static void Main(string[] args)
        {
            Engine.Initialize();
            Program.Initialize();

            Player player = PlayerFactory.Player(0, 0);
            Monster testEnemy = MonsterFactory.ZombieMan(200, 200, player);
            Monster testEnemy2 = MonsterFactory.ZombieMan(400, 300, player);

            // TODO Crear Factories de Entities y Scenes
            MenuScene MainMenuScene = new MenuScene(new Map("E1", "assets/Maps/main_menu.png"));
            MenuScene WinScene = new MenuScene(new Map("E1","assets/Maps/win.png"));
            MenuScene LoseScene = new MenuScene(new Map("E1", "assets/Maps/lose.png"));
            PlayableScene E1Scene = new PlayableScene(
                new Map("E1","assets/Maps/e1_test.png"),
                DEBUG_MODE, // Show Bounding Boxes
                DEBUG_MODE,   // Show vision Radius
                player,
                testEnemy,
                testEnemy2
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

            SceneController.Instance.ChangeScene(0);

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

                case Sdl.SDL_MOUSEBUTTONUP:
                    switch(sdl_event.button.button)
                    {
                        case Sdl.SDL_BUTTON_LEFT:
                            // Console.WriteLine("LEFT CLICK RELEASED");
                            LeftMouseButtonReleasedAction?.Invoke();
                            break;

                        case Sdl.SDL_BUTTON_RIGHT:
                            // Console.WriteLine("LEFT Right RELEASED");
                            RightMouseButtonReleasedAction?.Invoke();
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
