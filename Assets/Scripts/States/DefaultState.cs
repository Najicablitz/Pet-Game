using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : BaseState
{
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Default State");
    }
    public override void Exit(CatStateManager cat)
    {
        throw new System.NotImplementedException();
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        throw new System.NotImplementedException();
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        throw new System.NotImplementedException();
    }
}
