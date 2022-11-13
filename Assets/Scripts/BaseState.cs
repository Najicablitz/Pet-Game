using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void Enter(CatStateManager cat);
    public abstract void UpdateLogic(CatStateManager cat);
    public abstract void UpdatePhysics(CatStateManager cat); 
    public abstract void Exit(CatStateManager cat); 
}
