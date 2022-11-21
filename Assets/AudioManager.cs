using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _purrSound, _sleepSound , _background;
    [SerializeField] private AudioClip _purrClip;
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

    public void PlayBackground()
    {
        _background.Play();
    }
}
