using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Open_Stats : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _statsPanel;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        _statsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        _statsPanel.SetActive(false);
    }
}
