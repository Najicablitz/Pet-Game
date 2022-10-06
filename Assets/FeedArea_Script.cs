using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedArea_Script : MonoBehaviour
{
    public float _feeds;
    public float _water;
    public GameObject _refillButton;
    public TextMeshProUGUI feedText;
    private void Update()
    {
        feedText.text = $"Food: {_feeds} || Water: {_water}";
    }
    private void OnMouseDown()
    {
        if(_refillButton.gameObject.activeSelf == false)
        {
            _refillButton.SetActive(true);
        }
        else
        {
            _refillButton.SetActive(false);
        }
    }

    public void Refill()
    {
        _water = 100;
        _feeds = 100;
        _refillButton.SetActive(false);
    }
}
