using DoomSurvivors.Entities;
using DoomSurvivors.Scenes;
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
        public static Action DebugActions;
        // TODOS
        /*
            (In proress)
            . Weapon system (
                Falta cambiar de armas
                implementar armas faltantes

                Melee
             )
            . MenuScenes (menu items)
            . Collisions (Walls and enemies) (OK - Falta corregir Bug con Walls)
            . Items (OK - Falta agregar efectos)
            . Maps system (OK - Falta cargar Decors - Exit Point)

            (Pending)
            . HUD 
            . Decorations
            . Boosts
            . Lvl
            . Skill tree
            . Stats (health, xp)
            . Sounds

            (Nice to Have)
            . Doors
            . Switches
            . Explosive Barrels

            (Done)
            . Particle effects (OK)
            . RayCasted Bullets (OK)
            . Factories (Monsters & Weapons) (OK)
            . Interfaces (OK)
            . Dying (OK)
            . Camera movement (OK)
        */

        public static event Action LeftMouseButtonReleasedAction;
        public static event Action RightMouseButtonReleasedAction;

        public static void DebugModeActions()
        {
            Engine.DrawRect(Engine.Transform.W / 2, 0, 1, Engine.Transform.H, 0xfff);
            Engine.DrawRect(0, Engine.Transform.H / 2, Engine.Transform.W, 1, 0xfff);
        }
        static void Main(string[] args)
        {
            Engine.Initialize();
            Program.Initialize();

            // TODO Crear Factories de Scenes
            MenuScene MainMenuScene = new MenuScene(Engine.LoadImage("assets/Maps/main_menu.png"), 640, 640);
            MenuScene WinScene = new MenuScene(Engine.LoadImage("assets/Maps/win.png"), 640, 640);
            MenuScene LoseScene = new MenuScene(Engine.LoadImage("assets/Maps/lose.png"), 640, 640);
            PlayableScene E1Scene = new PlayableScene(
                Map.CreateMap("E1_Test"),
                DEBUG_MODE, // Show Bounding Boxes
                DEBUG_MODE   // Show vision Radius
            );

            SceneController.Instance.setScenes(
                new List<Scene> {
                    MainMenuScene,
                    E1Scene,
                    WinScene,
                    LoseScene
                }
            );

            SceneController.Instance.ChangeScene(1);

            // Crosshair
            crosshair = new Crosshair(true);

            // Set Debug Actions
            if (DEBUG_MODE)
                DebugActions = DebugModeActions;
            else
                DebugActions = () => { };

            int currentTicks = 0;
            int oldTicks;
            float fps;

            IntPtr DoomFont = Engine.LoadFont("assets/Fonts/DooM.ttf", 14);

            while (true) // Main loop
            {
                Program.UpdateTime();

                oldTicks = currentTicks;
                currentTicks = Sdl.SDL_GetTicks();

                SceneController.Instance.Load();

                PollEvents();

                Engine.Clear();

                SceneController.Instance.Update();

                crosshair.Update();

                DebugActions();

                fps = 1000 / (currentTicks - oldTicks);
                Engine.DrawText(fps.ToString(), 0, 0, 255, 255, 255, DoomFont);

                Engine.Show();  // Show current frame
                Sdl.SDL_Delay(2);
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
