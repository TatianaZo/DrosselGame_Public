using UnityEngine;
using System.Collections;
/// <summary>
/// менеджер вкл/выкл звука
/// </summary>
public class SoundSettings : MonoBehaviour 
{
    public AudioSource sound, soundMay;
    [SerializeField] AudioClip meow;

    public void SoundOn()
    {
        sound.volume = 0.01f;
        sound.Play();
    }

    public void SoundOff()
    {
        sound.Stop();
    }

    public void Meow()
    {
        if (!soundMay.isPlaying && sound.volume != 0) soundMay.PlayOneShot(meow);
    }
     
    public void SoundAddition()
    {
        sound.volume += 0.1f;
        Debug.Log(sound.volume);
    }

    public void Mute()
    {
        sound.volume = 0;
    }
}
