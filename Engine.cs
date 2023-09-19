using System;
using System.Threading;
using System.Drawing;
using Tao.Sdl;
using static System.Net.Mime.MediaTypeNames;

class Engine
{
    static IntPtr screen;
    static int ancho, alto;

    public static void Initialize()
    {
        ancho = 1024;
        alto = 768;
        int colores = 24;

        int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        screen = Sdl.SDL_SetVideoMode(
            ancho,
            alto,
            colores,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_SetClipRect(screen, ref rect2);

        SdlTtf.TTF_Init();
    }

    public static void Initialize(int an, int al, int colores)
    {
        ancho = an;
        alto = al;

        int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        screen = Sdl.SDL_SetVideoMode(
            ancho,
            alto,
            colores,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_SetClipRect(screen, ref rect2);

        SdlTtf.TTF_Init();
    }

    public static void Debug(string text)
    {
        System.Console.Write(text + "\n");
    }

    public static void Clear()
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_FillRect(screen, ref origin, 0);
    }

    public static void Draw(IntPtr imagen, float x, float y)
    {
        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)ancho, (short)alto);
        Sdl.SDL_BlitSurface(imagen, ref origen, screen, ref dest);
    }

    public static void Draw(string tempimage, float x, float y)
    {
        IntPtr image = LoadImage(tempimage);

        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)ancho, (short)alto);
        Sdl.SDL_BlitSurface(image, ref origin, screen, ref dest);
    }

    public static void Draw(string tempimage, float x, float y, float width, float height)
    {
        IntPtr image = LoadImage(tempimage);

        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)width, (short)height);
        Sdl.SDL_BlitSurface(image, ref origin, screen, ref dest);
    }

    public static void Draw(IntPtr image, float x, float y, float width, float height)
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)width, (short)height);
        Sdl.SDL_BlitSurface(image, ref origin, screen, ref dest);
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
            System.Console.WriteLine("Imagen inexistente: {0}", image);
            Environment.Exit(4);
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

        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)ancho, (short)alto);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)ancho, (short)alto);

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

    public static bool KeyPress(int c)
    {
        bool press = false;
        Sdl.SDL_PumpEvents();
        Sdl.SDL_Event pressed;
        Sdl.SDL_PollEvent(out pressed);
        int numkeys;
        byte[] keys = Tao.Sdl.Sdl.SDL_GetKeyState(out numkeys);
        if (keys[c] == 1)
            press = true;
        return press;
    }



    public static void ErrorFatal(string texto)
    {
        System.Console.WriteLine(texto);
        Environment.Exit(1);
    }


    // Definiciones de teclas
    public static int KEY_ESC = Sdl.SDLK_ESCAPE;
    public static int KEY_ESP = Sdl.SDLK_SPACE;
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
}
