using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency_Script : MonoBehaviour
{
    [SerializeField] private int _currency;
    private float ctr;
    private Time_Manager tm;
    [SerializeField] private float _currentday;

    public int GetCurrency
    {
        get { return _currency; }
        set { _currency = value; }
    }

    void Start()
    {
        tm = FindObjectOfType<Time_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentday < tm._days)
        {
            Debug.Log("Increase Money");
            _currency += 100;
            _currentday = tm._days;
        }
    }

    
}
