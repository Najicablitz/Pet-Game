using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_Manager : MonoBehaviour
{
    public const int _hoursInDay = 12, _minutesInHour = 60;

    public float _dayDuration = 5;

    public float _totalTime = 0;
    public float _currentTime = 0;
    public float _dayTime;
    public int _days;
    public TextMeshProUGUI _dayText;
    private CurrentDay currentDay;
    private void Start()
    {
        currentDay = FindObjectOfType<CurrentDay>();
    }
    // Update is called once per frame
    void Update()
    {
        if(currentDay.pause == false)
        {
            _totalTime += Time.deltaTime;
            _currentTime = _totalTime % _dayDuration;
            _dayTime = _totalTime * _hoursInDay / _dayDuration;
            Days();
        }
        
        //Debug.Log("Hour: " + Hour);
        /*Debug.Log("Hour: " + GetHour());
        Debug.Log("Minutes: " + GetMinutes());*/
    }

    public float GetHour()
    {
        return _currentTime * _hoursInDay / _dayDuration;
    }

    public float GetMinutes()
    {
        return (_currentTime * _hoursInDay * _minutesInHour / _dayDuration) % _minutesInHour;
    }

    public string Clock24Hour()
    {
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        hour += 6;
        string abbreviation = "AM";

        if(hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }

        if (hour == 0) 
        {
            hour = 12;
        }

        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
    }

    public void Days()
    {
        _days = 1 + Mathf.FloorToInt(_dayTime / _hoursInDay);
        _dayText.text = $"Day: {_days}";
    }

    public float Hour
    {
        get {return GetHour(); }
    }
}
