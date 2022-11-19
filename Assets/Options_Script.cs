using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options_Script : MonoBehaviour
{
    [SerializeField] private GameObject _optionPanel;
    public void OpenOptions()
    {
        _optionPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        _optionPanel.SetActive(false);
    }
}
