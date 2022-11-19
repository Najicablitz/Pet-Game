using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : BaseState
{
    CatParameters catParameter;
    private float ctr;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Sleep State");
        catParameter = GameObject.FindObjectOfType<CatParameters>();
        ctr = Random.Range(10f, 20f);
    }
    public override void Exit(CatStateManager cat)
    {
        
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        ctr -= Time.deltaTime;
        if (ctr <= 0)
        {
            cat.ChangeState(cat.defaultState);
        }
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        
    }
}
