using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderLayerChangeScript : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer layer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        layer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -1.25)
        {
            layer.sortingOrder = 0;
        }
        else
        {
            layer.sortingOrder = 50;
        }
    }
}
