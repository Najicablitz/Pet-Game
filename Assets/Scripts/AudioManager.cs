using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _purrSound, _sleepSound, _washSound, _background;
    public AudioSource _sound;
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
        _sound.PlayOneShot(_eatClip);
    }
    public void PlayDrink()
    {
        _sound.PlayOneShot(_drinkClip);
    }
    public void PlayPoop()
    {
        _sound.PlayOneShot(_poopClip);
    }
    public void PlayPee()
    {
        _sound.PlayOneShot(_peeClip);
    }
    public void PlayRefill()
    {
        _sound.PlayOneShot(_refillClip);
    }
    public void PlayClean()
    {
        _sound.PlayOneShot(_cleanClip);
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
