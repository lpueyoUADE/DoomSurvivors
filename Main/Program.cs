using DoomSurvivors.Entities;
using DoomSurvivors.Scenes;
using DoomSurvivors.Scenes.Maps;
using DoomSurvivors.Scenes.UI;
using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using Tao.Sdl;
using static DoomSurvivors.Scenes.UI.Font;

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

            (Pending)
            . HUD 
            . Decorations
            . Boosts
            . Lvl
            . Skill tree
            . Stats (health, xp)
            . Sounds
            
            . Death condition
            . Win condition
            . pause menu

            (Nice to Have)
            . Doors
            . Switches
            . Explosive Barrels
            . History Mode
            . Survivors Mode

            (Done)
            . Maps system (OK)
            . Particle effects (OK)
            . RayCasted Bullets (OK)
            . Factories (Monsters & Weapons) (OK)
            . Interfaces (OK)
            . Dying (OK)
            . Camera movement (OK)
        */

        public static event Action LeftMouseButtonReleasedAction;
        public static event Action RightMouseButtonReleasedAction;
        public static event Action EscapeButtonPressedAction;
        public static event Action DownArrowPressedAction;
        public static event Action UpArrowPressedAction;
        public static event Action EnterPressedAction;
        public static event Action MouseWheelDownAction;
        public static event Action MouseWheelUpAction;
        public static event Action InteractButtonPressedAction;
        public static event Action<int> NumericButtonPressedAction;
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
            MenuScene MainMenuScene = new MenuScene(
                Engine.LoadImage("assets/Icon/DoomSurvivorsLogo.png"),
                new Canvas(
                    new Transform(0, Engine.Transform.H / 2, Engine.Transform.W, Engine.Transform.H / 2),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(2), "JUEGO NUEVO"),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => Environment.Exit(0), "SALIR")
                )
            );

            // TODO: Mejorar cambio de escenas
            MenuScene LevelSelectorMenuScene = new MenuScene(
                IntPtr.Zero,
                new Canvas(
                    new Transform(0, 0, Engine.Transform.W, Engine.Transform.H),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(3), "GARAGE"),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(4), "PLANTA ATOMICA"),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(5), "ICONO DEL MAL"),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(0), "MAPA DE TESTING"),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(1), "VOLVER")
                ),
                Color.Black
            );

            MenuScene WinScene = new MenuScene(
                Engine.LoadImage("assets/Icon/winScreen.png"),
                new Canvas(
                    new Transform(0, Engine.Transform.H / 2, Engine.Transform.W, Engine.Transform.H / 2),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => SceneController.Instance.ChangeScene(1), "MENU PRINCIPAL"),
                    new Button(500, 500, 15, FontType.DoomFont, 28, Color.White, null, new Color(255, 0, 0, 255), () => Environment.Exit(0), "SALIR")
                )
            );

            PlayableScene TestMapScene = new PlayableScene(
                Map.CreateMap("TestMapScene", "assets/Maps/Test Map/Test_map_001.json", "assets/Maps/Test Map/Test_map_Floor.png"),
                DEBUG_MODE, // Show Bounding Boxes
                DEBUG_MODE   // Show vision Radius
            );

            PlayableScene E1M1Scene = new PlayableScene(
                Map.CreateMap("Garage", "assets/Maps/E1M1 Map/E1M1.json", "assets/Maps/E1M1 Map/E1M1.png"),
                DEBUG_MODE,
                DEBUG_MODE
            );

            PlayableScene E1M2Scene = new PlayableScene(
                Map.CreateMap("PlantaAtomica", "assets/Maps/E1M2 Map/E1M2.json", "assets/Maps/E1M2 Map/E1M2.png"),
                DEBUG_MODE,
                DEBUG_MODE
            );

            PlayableScene E1M3Scene = new PlayableScene(
                Map.CreateMap("IconoDelMal", "assets/Maps/E1M3 Map/E1M3.json", "assets/Maps/E1M3 Map/E1M3.png"),
                DEBUG_MODE,
                DEBUG_MODE
            );

            SceneController.Instance.setScenes(
                new List<Scene> {
                    TestMapScene,
                    MainMenuScene,
                    LevelSelectorMenuScene,
                    E1M1Scene,
                    E1M2Scene,
                    E1M3Scene,
                    WinScene
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
                SceneController.Instance.Render();

                crosshair.Update();

                DebugActions();

                fps = 1000 / (currentTicks - oldTicks);
                Engine.DrawText(fps.ToString(), 0, 0, 15, Color.White, null, DoomFont);

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
                        case Sdl.SDLK_DOWN:
                            DownArrowPressedAction?.Invoke();
                            break;

                        case Sdl.SDLK_UP:
                            UpArrowPressedAction?.Invoke();
                            break;

                        case Sdl.SDLK_RETURN:
                            EnterPressedAction?.Invoke();
                            break;

                        case Sdl.SDLK_ESCAPE:
                            EscapeButtonPressedAction?.Invoke();
                            break;

                        case Sdl.SDLK_e:
                            InteractButtonPressedAction?.Invoke();
                            break;

                        case Sdl.SDLK_1:
                            NumericButtonPressedAction?.Invoke(1);
                            break;

                        case Sdl.SDLK_2:
                            NumericButtonPressedAction?.Invoke(2);
                            break;

                        case Sdl.SDLK_3:
                            NumericButtonPressedAction?.Invoke(3);
                            break;
                        case Sdl.SDLK_4:
                            NumericButtonPressedAction?.Invoke(4);
                            break;
                        case Sdl.SDLK_5:
                            NumericButtonPressedAction?.Invoke(5);
                            break;
                        case Sdl.SDLK_6:
                            NumericButtonPressedAction?.Invoke(6);
                            break;
                        case Sdl.SDLK_7:
                            NumericButtonPressedAction?.Invoke(7);
                            break;
                        case Sdl.SDLK_8:
                            NumericButtonPressedAction?.Invoke(8);
                            break;
                        case Sdl.SDLK_9:
                            NumericButtonPressedAction?.Invoke(9);
                            break;

                    }
                    break;

                case Sdl.SDL_MOUSEBUTTONUP:
                    switch(sdl_event.button.button)
                    {
                        case Sdl.SDL_BUTTON_LEFT:
                            LeftMouseButtonReleasedAction?.Invoke();
                            break;

                        case Sdl.SDL_BUTTON_RIGHT:
                            RightMouseButtonReleasedAction?.Invoke();
                            break;
                    }

                    break;

                case Sdl.SDL_MOUSEBUTTONDOWN:
                    switch(sdl_event.button.button)
                    {
                        case Sdl.SDL_BUTTON_WHEELDOWN:
                            MouseWheelDownAction?.Invoke();
                            break;

                        case Sdl.SDL_BUTTON_WHEELUP:
                            MouseWheelUpAction?.Invoke();
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
