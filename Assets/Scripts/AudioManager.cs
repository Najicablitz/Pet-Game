using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _btnSound, _purrSound, _sleepSound, _washSound, _background;
    public AudioSource  SFX, BG;
    [SerializeField] private AudioClip _purrClip, _eatClip, _drinkClip, _poopClip, _peeClip, _refillClip, _cleanClip;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEat()
    {
        SFX.PlayOneShot(_eatClip);
    }
    public void PlayDrink()
    {
        SFX.PlayOneShot(_drinkClip);
    }
    public void PlayPoop()
    {
        SFX.PlayOneShot(_poopClip);
    }
    public void PlayPee()
    {
        SFX.PlayOneShot(_peeClip);
    }
    public void PlayRefill()
    {
        SFX.PlayOneShot(_refillClip);
    }
    public void PlayClean()
    {
        SFX.PlayOneShot(_cleanClip);
    }
    public void PlayPurr()
    {
        _purrSound.PlayOneShot(_purrClip);
    }

    public void PlaySleep()
    {
        if(_sleepSound.isPlaying == false)
        {
            _sleepSound.Play();
        }        
    }

    public void StopSleep()
    {
        _sleepSound.Stop();
    }
    public void PlayWash()
    {
        _washSound.Play();
    }

    public void PlayBackground()
    {
        _background.Play();
    }
    public void PlayBackground(AudioSource bg)
    {
        bg.Play();
    }
    public void PlayClip(AudioClip clip, AudioSource source)
    {
        source.PlayOneShot(clip);
    }
    public void PlaySound(AudioSource source)
    {
        source.Play();
    }
    public void StopSound(AudioSource source)
    {
        source.Stop();
    }
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
