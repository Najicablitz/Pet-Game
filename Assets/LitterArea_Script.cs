using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterArea_Script : MonoBehaviour
{
    public float _fill = 100;
    public GameObject _cleanButton;
    private void OnMouseDown()
    {
        _cleanButton.SetActive(true);
    }

    public void Clean()
    {
        _fill = 0;
        _cleanButton.SetActive(false);
    }
}
