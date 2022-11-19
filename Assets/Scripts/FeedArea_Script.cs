using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedArea_Script : MonoBehaviour
{
    [SerializeField] private float _feeds;
    [SerializeField] private float _water;
    public GameObject _refillButton;
    public TextMeshProUGUI feedText;

    public float GetFeeds
    {
        get { return _feeds; }
        set { _feeds = value; }
    }

    public float GetWater
    {
        get { return _water; }
        set { _water = value; }
    }
    private void Update()
    {
        feedText.text = $"Food: {GetFeeds} || Water: {GetWater}";
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
        GetWater = 100;
        GetFeeds = 100;
        _refillButton.SetActive(false);
    }
}
