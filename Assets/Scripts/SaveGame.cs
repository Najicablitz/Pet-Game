using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Button button;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(SaveMenu);
    }

    private void SaveMenu()
    {
        gameManager.Save();
        button.onClick.RemoveListener(SaveMenu);
        gameManager.Load_Menu();
    }
}
