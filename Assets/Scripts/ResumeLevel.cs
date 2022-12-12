using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeLevel : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Button button;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(Resume);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Resume()
    {
        gameManager.Load();
    }
}
