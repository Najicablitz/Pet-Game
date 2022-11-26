using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeState : BaseState
{
    CatParameters catParameter;
    LitterArea_Script litterArea;

    AnimatorScript animator;
    Direction direction;

    private float delayCtr = 3f;
    private bool peeing;
    private float disciplineCtr = 5f;
    private bool onetime;

    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Pee State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        litterArea = Object.FindObjectOfType<LitterArea_Script>();
        catParameter._peeButton.gameObject.SetActive(true);
        //catParameter._peeButton.onClick.AddListener(Peeing);

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();
        onetime = false;
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._peeButton.gameObject.SetActive(false);
        //catParameter._peeButton.onClick.RemoveListener(Peeing);
        animator.StopWalkAnim(false);
        peeing = false;
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        if (cat.GetLitter() == true)
        {
            if (onetime == false)
            {
                Peeing();
                onetime = true;
            }
        }
        disciplineCtr -= Time.deltaTime;
        /*if (litterArea.GetFill >= 100)
        {
            catParameter._peeButton.interactable = false;
        }
        else
        {
            catParameter._peeButton.interactable = true;
        }*/
        if (catParameter._pee > 99 && catParameter._discipline < 50 && peeing == false)
        {
            GameObject instanceObj = Object.Instantiate(catParameter._peeInstance,
                                    catParameter.gameObject.transform.position, Quaternion.identity) as GameObject;
            catParameter._pee = 0;
            cat.ChangeState(cat.defaultState);
        }
        else if(litterArea.GetFill < 100)
        {
            if (catParameter._pee >= 100 && catParameter._discipline >= 50 || peeing == true)
            {
                if (Vector2.Distance(cat.transform.position, catParameter._litterArea.position) > 2)
                {
                    var dir = direction.GetAngle(catParameter._litterArea.transform);
                    animator.PlayWalkAnim(dir);
                    cat.transform.position = Vector2.MoveTowards(
                                             cat.transform.position, catParameter._litterArea.position, catParameter._speed / 2);
                }
                else
                {
                    animator.StopWalkAnim(false);
                }

                delayCtr -= Time.deltaTime;
                if (delayCtr <= 0)
                {                    
                    delayCtr = 3f;
                    cat.ChangeState(cat.defaultState);
                }
            }
        }
        
    }
    public override void UpdatePhysics(CatStateManager cat)
    {
        
    }
    private void Peeing()
    {
        Debug.Log("Peeing");
        peeing = true;
        litterArea.GetFill += 40;
        catParameter._pee = 0;
        catParameter._peeButton.gameObject.SetActive(false);
        if (disciplineCtr > 0)
        {
            catParameter._discipline += 5;
        }
    }
}