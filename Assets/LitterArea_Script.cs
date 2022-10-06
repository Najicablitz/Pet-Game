using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LitterArea_Script : MonoBehaviour
{
    public float _fill = 100;
    public GameObject _cleanButton;
    public TextMeshProUGUI litterText;
    private void Update()
    {
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
