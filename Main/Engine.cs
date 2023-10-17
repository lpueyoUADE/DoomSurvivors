using DoomSurvivors.Entities;
using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;
using Tao.Sdl;


class Engine
{
    static IntPtr screen;
    static private Transform transform = new Transform(0,0,0,0);

    public static Transform Transform {  
        get { return transform; }
    }
    public static void Initialize(int width=1024, int height=768)
    {
        Engine.transform.W = width;
        Engine.transform.H = height;
        int colores = 24;

        int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        screen = Sdl.SDL_SetVideoMode(
            width,
            height,
            colores,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_SetClipRect(screen, ref rect2);

        SdlTtf.TTF_Init();
    }

    public static void Initialize(int an, int al, int colores)
    {
        transform.W = an;
        transform.H = al;

        int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        screen = Sdl.SDL_SetVideoMode(
            transform.W,
            transform.H,
            colores,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_SetClipRect(screen, ref rect2);

        SdlTtf.TTF_Init();
    }

    public static void Debug(string text)
    {
        System.Console.Write(text + "\n");
    }

    public static void Clear()
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_FillRect(screen, ref origin, 0);
    }

    public static void Draw(IntPtr imagen, double x, double y)
    {
        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)transform.W, (short)transform.H);
        Sdl.SDL_BlitSurface(imagen, ref origen, screen, ref dest);
    }

    public static void Draw(string tempimage, double x, double y)
    {
        IntPtr image = LoadImage(tempimage);

        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)transform.W, (short)transform.H);
        Sdl.SDL_BlitSurface(image, ref origin, screen, ref dest);
    }

    public static void Draw(string tempimage, double x, double y, double width, double height)
    {
        IntPtr image = LoadImage(tempimage);

        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)transform.W, (short)height);
        Sdl.SDL_BlitSurface(image, ref origin, screen, ref dest);
    }

    public static void Draw(IntPtr image, double x, double y, double width, double height)
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)transform.W, (short)height);
        Sdl.SDL_BlitSurface(image, ref origin, screen, ref dest);
    }

    public static void DrawRect(int x, int y, int w, int h, int color)
    {
        Sdl.SDL_Rect rect = new Sdl.SDL_Rect((short)x, (short)y, (short)w, (short)h);
        Sdl.SDL_FillRect(screen, ref rect, color);
    }
    public static void DrawRect(Vector position, Vector size, int color)
    {
        Sdl.SDL_Rect rect = new Sdl.SDL_Rect((short)position.X, (short)position.Y, (short)size.X, (short)size.Y);
        Sdl.SDL_FillRect(screen, ref rect, color);
    }

    public static void DrawRect(Sdl.SDL_Rect rect, int color)
    {
        Sdl.SDL_FillRect(screen, ref rect, color);
    }
    public static void Show()
    {
        Sdl.SDL_Flip(screen);
    }

    public static IntPtr LoadImage(string image)
    {
        IntPtr imagen;
        imagen = SdlImage.IMG_Load(image);
        if (imagen == IntPtr.Zero)
        {
            throw new Exception($"Imagen inexistente: {image}");
        }
        return imagen;
    }

    public static void DrawText(string text,
        int x, int y, byte r, byte g, byte b, Font f)
    {
        DrawText(text, x, y, r, g, b, f.ReadPointer());
    }

    public static void DrawText(string texto,
        int x, int y, byte r, byte g, byte b, IntPtr fuente)
    {
        Sdl.SDL_Color color = new Sdl.SDL_Color(r, g, b);
        IntPtr textAsImage = SdlTtf.TTF_RenderText_Solid(
            fuente, texto, color);
        if (textAsImage == IntPtr.Zero)
            Environment.Exit(5);

        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)transform.W, (short)transform.H);

        Sdl.SDL_BlitSurface(textAsImage, ref origen,
            screen, ref dest);
        Sdl.SDL_FreeSurface(textAsImage);
    }

    public static IntPtr LoadFont(string file, int size)
    {
        IntPtr font = SdlTtf.TTF_OpenFont(file, size);
        if (font == IntPtr.Zero)
        {
            System.Console.WriteLine("Fuente inexistente: {0}", file);
            Environment.Exit(6);
        }
        return font;
    }

    public static void DrawCirle(int x, int y, int radius, Color color)
    {
        SdlGfx.aacircleRGBA(screen, (short)x, (short)y, (short)radius, color.R, color.G, color.B, color.A);
    }

    public static void DrawFilledEllipse(int x, int y, int rx, int ry, int R, int G, int B, int A)
    {
        SdlGfx.filledEllipseRGBA(screen, (short)x, (short)y, (short)rx, (short)ry, (byte)R, (byte)G, (byte)B, (byte)A);
    }

    public static void DrawLine(int x1, int y1, int x2, int y2, Color color)
    {
        SdlGfx.aalineRGBA(screen, (short)x1, (short)y1, (short)x2, (short)y2, color.R, color.G, color.B, color.A);
    }

    public static void DrawLine(Vector begin, Vector end, Color color)
    {
        SdlGfx.aalineRGBA(screen, (short)begin.X, (short)begin.Y, (short)end.X, (short)end.Y, color.R, color.G, color.B, color.A);
    }

    public static void DrawGradientLine(int x1, int y1, int x2, int y2, Color beginColor, Color endColor, int steps)
    {
        DrawGradientLine(new Vector(x1, y1), new Vector(x2, y2), beginColor, endColor, steps);
    }

    public static void DrawGradientLine(Vector begin, Vector end, Color beginColor, Color endColor, int steps)
    {
        List<Color> colorList = new List<Color>();
        float step = 1f / steps;

        for (int i= 0; i < steps; i++)
        {
            Color currentColor = new Color(Tools.Lerp((uint)beginColor, (uint)endColor, step * (i + 1)));
            colorList.Add(currentColor);
        }

        DrawMultiColorLine(begin, end, colorList);
    }

        public static void DrawMultiColorLine(int x1, int y1, int x2, int y2, List<Color> colorList)
    {
        DrawMultiColorLine(new Vector(x1, y1), new Vector(x2,y2), colorList);
    }
        public static void DrawMultiColorLine(Vector begin, Vector end, List<Color> colorList)
    {
        float step = 1f / colorList.Count;

        Vector current = begin;
        Vector next;

        for (int i = 0; i < colorList.Count ; i++)
        {
            next = Tools.Lerp(begin, end, step*(i+1));

            DrawLine(current, next, colorList[i]);

            current = next;            
        }
    }

    public static bool KeyPress(int keyCode)
    {
        return Sdl.SDL_GetKeyState(out _)[keyCode] == 1;
    }

    public static bool MousePress(int mouseButton)
    {
        return (Sdl.SDL_GetMouseState(out _,out _) & mouseButton) > 0;
    }
    public static void ErrorFatal(string texto)
    {
        System.Console.WriteLine(texto);
        Environment.Exit(1);
    }

    // Definiciones de teclas
    public static int KEY_ESC = Sdl.SDLK_ESCAPE;
    public static int KEY_ESP = Sdl.SDLK_SPACE;
    public static int KEY_ENTER = Sdl.SDLK_RETURN; 
    public static int KEY_A = Sdl.SDLK_a;
    public static int KEY_B = Sdl.SDLK_b;
    public static int KEY_C = Sdl.SDLK_c;
    public static int KEY_D = Sdl.SDLK_d;
    public static int KEY_E = Sdl.SDLK_e;
    public static int KEY_F = Sdl.SDLK_f;
    public static int KEY_G = Sdl.SDLK_g;
    public static int KEY_H = Sdl.SDLK_h;
    public static int KEY_I = Sdl.SDLK_i;
    public static int KEY_J = Sdl.SDLK_j;
    public static int KEY_K = Sdl.SDLK_k;
    public static int KEY_L = Sdl.SDLK_l;
    public static int KEY_M = Sdl.SDLK_m;
    public static int KEY_N = Sdl.SDLK_n;
    public static int KEY_O = Sdl.SDLK_o;
    public static int KEY_P = Sdl.SDLK_p;
    public static int KEY_Q = Sdl.SDLK_q;
    public static int KEY_R = Sdl.SDLK_r;
    public static int KEY_S = Sdl.SDLK_s;
    public static int KEY_T = Sdl.SDLK_t;
    public static int KEY_U = Sdl.SDLK_u;
    public static int KEY_V = Sdl.SDLK_v;
    public static int KEY_W = Sdl.SDLK_w;
    public static int KEY_X = Sdl.SDLK_x;
    public static int KEY_Y = Sdl.SDLK_y;
    public static int KEY_Z = Sdl.SDLK_z;
    public static int KEY_1 = Sdl.SDLK_1;
    public static int KEY_2 = Sdl.SDLK_2;
    public static int KEY_3 = Sdl.SDLK_3;
    public static int KEY_4 = Sdl.SDLK_4;
    public static int KEY_5 = Sdl.SDLK_5;
    public static int KEY_6 = Sdl.SDLK_6;
    public static int KEY_7 = Sdl.SDLK_7;
    public static int KEY_8 = Sdl.SDLK_8;
    public static int KEY_9 = Sdl.SDLK_9;
    public static int KEY_0 = Sdl.SDLK_0;
    public static int KEY_UP = Sdl.SDLK_UP;
    public static int KEY_DOWN = Sdl.SDLK_DOWN;
    public static int KEY_RIGHT = Sdl.SDLK_RIGHT;
    public static int KEY_LEFT = Sdl.SDLK_LEFT;
    public static int MOUSEBUTTON_LEFT = Sdl.SDL_BUTTON_LMASK;
    public static int MOUSEBUTTON_RIGHT = Sdl.SDL_BUTTON_RMASK;
}
