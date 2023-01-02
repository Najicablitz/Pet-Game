using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Button button;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(MainMenu);
    }

    private void MainMenu()
    {
        button.onClick.RemoveListener(MainMenu);
        gameManager.Load_Menu();
    }
}
