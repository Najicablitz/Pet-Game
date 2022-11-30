using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedArea_Script : MonoBehaviour
{
    [SerializeField] private float _feeds;
    [SerializeField] private float _water;
    public GameObject _refillButton;
    public Slider feedsAmount;
    public Slider waterAmount;
    private void OnMouseOver()
    {
        feedsAmount.gameObject.SetActive(true);
        waterAmount.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        feedsAmount.gameObject.SetActive(false);
        waterAmount.gameObject.SetActive(false);
    }
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
        if(_feeds > 100)
        {
            _feeds = 100;
        }
        if (_water > 100)
        {
            _water = 100;
        }
        feedsAmount.value = _feeds;
        waterAmount.value = _water;
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
