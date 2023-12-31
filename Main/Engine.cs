﻿using DoomSurvivors.Entities;
using DoomSurvivors.Entities.Animations;
using DoomSurvivors.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using Tao.Sdl;
using static System.Net.Mime.MediaTypeNames;
using static Tao.Sdl.Sdl;


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
        int colores = 32;

        int flags = Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT;
        Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
        screen = Sdl.SDL_SetVideoMode(
            width,
            height,
            colores,
            flags);

        Sdl.SDL_Rect rect2 =
            new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_SetClipRect(screen, ref rect2);

        Sdl.SDL_WM_SetCaption("DooM Survivors", "assets/Icon/logo.ico");

        SdlTtf.TTF_Init();
        SdlMixer.Mix_OpenAudio(44100, (short)SdlMixer.MIX_DEFAULT_FORMAT, 2, 2048);
        SdlMixer.Mix_Volume(-1, 32);
    }

    public static void Clear()
    {
        Sdl.SDL_Rect origin = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_FillRect(screen, ref origin, 0);
    }

    public static void Draw(IntPtr imagen, double x, double y, int width, int height)
    {
        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)width, (short)height);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)width, (short)height);
        Sdl.SDL_BlitSurface(imagen, ref origen, screen, ref dest);
    }

    public static void Draw(Sprite sprite, double x, double y, int width, int height)
    {
        IntPtr reference = Sprite.References[sprite.ImageName].Surface;
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)x, (short)y, (short)width, (short)height);
        Sdl.SDL_BlitSurface(reference, ref sprite.rect, screen, ref dest);
    }

    public static void DrawRect(int x, int y, int w, int h, int color)
    {
        Sdl.SDL_Rect rect = new Sdl.SDL_Rect((short)x, (short)y, (short)w, (short)h);
        Sdl.SDL_FillRect(screen, ref rect, color);
    }

    public static void DrawRect(int x, int y, int w, int h, Color color)
    {
        SdlGfx.boxRGBA(screen, (short)x, (short)y, (short)(x + w - 1), (short)(y + h - 1), color.R, color.G, color.B, color.A);
    }

    public static void DrawRect(Vector position, Vector size, int color)
    {
        Sdl.SDL_Rect rect = new Sdl.SDL_Rect((short)position.X, (short)position.Y, (short)size.X, (short)size.Y);
        Sdl.SDL_FillRect(screen, ref rect, color);
    }

    public static void DrawRect(Transform transform, Color color)
    {
        DrawRect(transform.Position, transform.Size, (int)color);
    }

    public static void DrawRect(Sdl.SDL_Rect rect, int color)
    {
        Sdl.SDL_FillRect(screen, ref rect, color);
    }

    public static void DrawFilledRect(Transform transform, Color color, int steps)
    {
        if (transform.W <= 0)
            return;

        float alfaStep = 255 / steps;
        for (int i = 0; i < steps; i++)
        {
            int deltaSize = i == 0 ? 0 : -(i * 4);
            DrawRect(transform.X + i * 2, transform.Y + i * 2, transform.W + deltaSize, transform.H + deltaSize, new Color(color.R, color.G, color.B, (byte)(alfaStep * (i + 1))));
        }
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

    public static void DrawText(string texto, int x, int y, int padding, Color color, Color backgroundColor, IntPtr fuente)
    {
        Sdl.SDL_Color sdlColor = new Sdl.SDL_Color(color.R, color.G, color.B);
        IntPtr textAsImage = SdlTtf.TTF_RenderUTF8_Solid(fuente, texto, sdlColor);

        SdlTtf.TTF_SizeUNICODE(fuente, texto , out int w, out int h);

        if (backgroundColor != null)
            Engine.DrawRect(x, y, w + padding*2, h + padding*2, (int)backgroundColor);

        Sdl.SDL_Rect origen = new Sdl.SDL_Rect(0, 0, (short)transform.W, (short)transform.H);
        Sdl.SDL_Rect dest = new Sdl.SDL_Rect((short)(x+padding), (short)(y+padding), (short)transform.W, (short)transform.H);

        Sdl.SDL_BlitSurface(textAsImage, ref origen, screen, ref dest);
        Sdl.SDL_FreeSurface(textAsImage);
    }

    public static IntPtr LoadFont(string file, int size)
    {
        IntPtr font = SdlTtf.TTF_OpenFont(file, size);
        if (font == IntPtr.Zero)
            System.Console.WriteLine("Fuente inexistente: {0}", file);

        return font;
    }

    public static void DrawCirle(int x, int y, int radius, Color color)
    {
        SdlGfx.aacircleRGBA(screen, (short)x, (short)y, (short)radius, color.R, color.G, color.B, color.A);
    }

    public static void DrawFilledEllipse(int x, int y, int rx, int ry, Color color)
    {
        SdlGfx.filledEllipseRGBA(screen, (short)x, (short)y, (short)rx, (short)ry, color.R, color.G, color.R, color.A);
    }

    public static void DrawGradientEllipse(int x, int y, int beginRx, int beginRy, int endRx, int endRy, Color beginColor, Color endColor, int steps)
    {
        float step = 1f / steps;
        int rx, ry;
        Color color;
        for (int i = 0; i <= steps; i++)
        {
            rx = (int)Tools.Lerp(beginRx, endRx, step * i);
            ry = (int)Tools.Lerp(beginRy, endRy, step * i);
            color = new Color(Tools.Lerp((uint)beginColor, (uint)endColor, step * i));
            SdlGfx.filledEllipseRGBA(screen, (short)x, (short)y, (short)rx, (short)ry, color.R, color.G, color.B, color.A);
        }
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

        for (int i= 0; i <= steps; i++)
        {
            Color currentColor = new Color(Tools.Lerp((uint)beginColor, (uint)endColor, step * i));
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
