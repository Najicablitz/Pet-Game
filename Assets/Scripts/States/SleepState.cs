using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : BaseState
{
    CatParameters catParameter;
    private float ctr;

    AnimatorScript animator;
    Direction direction;
    AudioManager audioManager;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Sleep State");
        catParameter = GameObject.FindObjectOfType<CatParameters>();
        ctr = Random.Range(10f, 20f);

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();
        audioManager = Object.FindObjectOfType<AudioManager>();
    }
    public override void Exit(CatStateManager cat)
    {
        animator.amt.SetBool("sleep", false);
        audioManager.StopSleep();
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        ctr -= Time.deltaTime;

        var sleepAreaPos = catParameter._sleepArea.transform.position;
        if (cat.transform.position != sleepAreaPos)
        {
            animator.PlayWalkAnim(direction.GetAngle(catParameter._sleepArea.transform));
        }
        else
        {
            audioManager.PlaySleep();
            animator.StopWalkAnim(false);
            animator.amt.SetBool("sleep", true);            
        }
        cat.transform.position = Vector2.MoveTowards(cat.transform.position, sleepAreaPos, catParameter._speed / 2);

        if (ctr <= 0)
        {
            cat.ChangeState(cat.defaultState);
        }
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        
    }
}
