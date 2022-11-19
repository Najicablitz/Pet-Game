using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LitterArea_Script : MonoBehaviour
{
    [SerializeField] private float _fill = 0;
    public GameObject _cleanButton;
    public TextMeshProUGUI litterText;

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
        litterText.text = $"Litter: {_fill}";
    }
    private void OnMouseDown()
    {
        if (_cleanButton.gameObject.activeSelf==false)
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
