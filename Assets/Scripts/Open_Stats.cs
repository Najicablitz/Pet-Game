using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Open_Stats : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _statsPanel;
    private AudioManager am;
    [SerializeField] private AudioSource click;
    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        _statsPanel.SetActive(true);
        am.PlaySound(click);

    }

    public void ClosePanel()
    {
        am.PlaySound(click);
        _statsPanel.SetActive(false);

    }
}
