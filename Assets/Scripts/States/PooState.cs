using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooState : BaseState
{
    CatParameters catParameter;
    LitterArea_Script litterArea;

    AnimatorScript animator;
    AudioManager audioManager;
    Direction direction;

    private float delayCtr = 3f;
    private bool pooping;
    private float disciplineCtr = 5f;
    private bool onetime;
    public override void Enter(CatStateManager cat)
    {
        Debug.Log("Poop State");
        catParameter = Object.FindObjectOfType<CatParameters>();
        litterArea = Object.FindObjectOfType<LitterArea_Script>();
        catParameter._poopButton.gameObject.SetActive(true);
        audioManager = Object.FindObjectOfType<AudioManager>();
        //catParameter._poopButton.onClick.AddListener(Pooping);

        animator = catParameter.gameObject.GetComponent<AnimatorScript>();
        direction = Object.FindObjectOfType<Direction>();
        onetime = false;
    }
    public override void Exit(CatStateManager cat)
    {
        disciplineCtr = 5f;
        catParameter._poopButton.gameObject.SetActive(false);
        //catParameter._poopButton.onClick.RemoveListener(Pooping);
        animator.StopWalkAnim(false);
        pooping = false;
    }
    public override void UpdateLogic(CatStateManager cat)
    {
        if(cat.GetLitter() == true)
        {
            if (onetime == false)
            {
                Pooping();
                audioManager.PlayPoop();
                onetime = true;
            }
        }
        disciplineCtr -= Time.deltaTime;
        /*if (litterArea.GetFill >= 100)
        {
            catParameter._poopButton.interactable = false;
        }
        else
        {
            catParameter._poopButton.interactable = true;
        }*/
        if (catParameter._poop >= 100 && catParameter._discipline < 50 && pooping == false)
        {
            GameObject instanceObj = Object.Instantiate(catParameter._poopInstance,
                                    catParameter.gameObject.transform.position, Quaternion.identity) as GameObject;
            audioManager.PlayPoop();
            catParameter._poop = 0;
            cat.ChangeState(cat.defaultState);
        }
        else if(litterArea.GetFill < 100)
        {
            if (catParameter._poop >= 100 && catParameter._discipline >= 50 || pooping == true)
            {
                if(Vector2.Distance(cat.transform.position, catParameter._litterArea.position) > 2)
                {
                    var dir = direction.GetAngle(catParameter._litterArea.transform);
                    animator.PlayWalkAnim(dir);
                    cat.transform.position = Vector2.MoveTowards(
                                             cat.transform.position, catParameter._litterArea.position, catParameter._speed * Time.deltaTime);
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
    private void Pooping()
    {
        if (litterArea.GetFill < 100)
        {
            Debug.Log("Pooping");
            pooping = true;
            litterArea.GetFill += 40;
            catParameter._poop = 0;
            catParameter._poopButton.gameObject.SetActive(false);
            if (disciplineCtr > 0)
            {
                catParameter._discipline += 5;
            }
        }
            
    }
}
