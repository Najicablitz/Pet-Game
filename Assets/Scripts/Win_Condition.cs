using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win_Condition : MonoBehaviour
{
    private Time_Manager tm;
    private CatParameters cat;
    public TextMeshProUGUI text;
    public int _lastDay;
    void Start()
    {
        tm = FindObjectOfType<Time_Manager>();
        cat = FindObjectOfType<CatParameters>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cat._health <= 0)
        {
            text.gameObject.SetActive(true);
            text.text = "Cat Died";
        }
        if(tm._days > _lastDay)
        {
            if(cat._health != 0)
            {
                text.gameObject.SetActive(true);
                text.text = "Congratulation";
            }
        }
    }
}
