using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Open_Stats : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _statsPanel;
    private AudioManager audio;
    [SerializeField] private AudioSource click;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        _statsPanel.SetActive(true);
        audio.PlaySound(click);

    }

    public void ClosePanel()
    {
        audio.PlaySound(click);
        _statsPanel.SetActive(false);

    }
}
