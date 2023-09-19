using System;
using Tao.Sdl;

public class Sound
{
    // Atributos
    IntPtr pointer;

    // Operaciones

    // Constructor a partir de un nombre de fichero
    public Sound(string nombreFichero)
    {
        pointer = SdlMixer.Mix_LoadMUS(nombreFichero);
    }

    // Reproducir una vez
    public void PlayOnce()
    {
        SdlMixer.Mix_PlayMusic(pointer, 1);
    }

    // Reproducir continuo (musica de fondo)
    public void Play()
    {
        SdlMixer.Mix_PlayMusic(pointer, -1);
    }

    // Interrumpir toda la reproducción de sonido
    public void Stop()
    {
        SdlMixer.Mix_HaltMusic();
    }

}
