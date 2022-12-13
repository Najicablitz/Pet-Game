using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LitterArea_Script : MonoBehaviour
{
    [SerializeField] private float _fill = 0;
    public GameObject _cleanButton;
    public Slider amount;
    private CurrentDay currentDay;
    [SerializeField] private GameObject feedMiniGame;
    [SerializeField] private GameObject litterMiniGame;
    private void Start()
    {
        currentDay = FindObjectOfType<CurrentDay>();
    }
    private void OnMouseOver()
    {
        if(currentDay.pause == false && feedMiniGame.activeSelf == false && litterMiniGame.activeSelf == false)
        {
            amount.gameObject.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        amount.gameObject.SetActive(false);
    }
    public float GetFill
    {
        get { return _fill; }
        set { _fill = value; }
    }
    private void Update()
    {
        if(GetFill > 100)
        {
            GetFill = 100;
        }
        amount.value = _fill;
    }
    private void OnMouseDown()
    {
        if (_cleanButton.gameObject.activeSelf==false && currentDay.pause == false && feedMiniGame.activeSelf == false && litterMiniGame.activeSelf == false)
        {
            _cleanButton.SetActive(true);
        }
        else
        {
            _cleanButton.SetActive(false);
        }
    }

    public void Clean()
    {
        _fill = 0;
        _cleanButton.SetActive(false);
    }
}
