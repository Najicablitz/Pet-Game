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
        button.onClick.AddListener(Load_MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Load_MainMenu()
    {
        gameManager.Save();
        gameManager.Load_Menu();
    }
}
