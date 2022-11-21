using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    CatParameters catParameter;
    public float dir;
    void Start()
    {
        catParameter = Object.FindObjectOfType<CatParameters>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAngle(catParameter._foodArea.transform);
    }

    public float GetAngle(Transform target)
    {
        var direction = target.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        return angle;        
    }
}
