using System;
using Tao.Sdl;

public class Sound
{
    // Atributos
    IntPtr pointer;
    int volume;

    public int Volume
    {
        get => volume; 
        set => volume = value;
    }
    // Operaciones

    // Constructor a partir de un nombre de fichero
    public Sound(string nombreFichero, int volume=SdlMixer.MIX_MAX_VOLUME/2)
    {
        pointer = SdlMixer.Mix_LoadWAV(nombreFichero);
        this.volume = volume;
        SdlMixer.Mix_VolumeChunk(pointer, volume);
    }

    // Reproducir una vez
    public void PlayOnce()
    {
        SdlMixer.Mix_PlayChannel(-1, pointer, 0);
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
