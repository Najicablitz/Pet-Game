using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_Game : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Button button;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(Exit);
    }

    public void Exit()
    {
        button.onClick.RemoveListener(Exit);
        gameManager.Exit();
    }
}
