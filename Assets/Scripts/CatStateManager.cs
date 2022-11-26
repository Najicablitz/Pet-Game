using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatStateManager : MonoBehaviour
{
    public BaseState currentState;
    public DefaultState defaultState = new DefaultState();
    public HungerState hungerState = new HungerState();
    public ThirstState thirstState = new ThirstState();
    public PeeState peeState = new PeeState();
    public PooState pooState = new PooState();
    public SleepState sleepState = new SleepState();
    public PlayState playState = new PlayState();
    public SickState sickState = new SickState();

    CatParameters catParameters;
    AnimatorScript animator;
    public bool dragging;
    private bool feeds;
    private bool litter;

    public bool GetFeeds()
    {
        return feeds;
    }
    public bool GetLitter()
    {
        return litter;
    }
        
    void Start()
    {
        catParameters = FindObjectOfType<CatParameters>();
        animator = FindObjectOfType<AnimatorScript>();
        currentState = defaultState;
        currentState.Enter(this);        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current State: " + currentState);
        currentState.UpdateLogic(this);
        if (dragging == true)
        {
            Debug.Log("Dragging");
            var pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
    }

    public void ChangeState(BaseState state)
    {
        currentState.Exit(this);
        currentState = state;
        state.Enter(this);
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Feeds")
        {
            Debug.Log("Hit Feeds");
            ChangeState(defaultState);
        }
        if (collision.tag == "Litter")
        {
            Debug.Log("Hit Litter");
            ChangeState(defaultState);
        }
    }*/

    private void OnMouseDown()
    {
        dragging = true;
        animator.amt.SetBool("grab", true);
    }

    private void OnMouseUp()
    {
        dragging = false;
        animator.amt.SetBool("grab", false);
        if (Vector2.Distance(transform.position, catParameters._foodArea.transform.position) < 3)
        {
            feeds = true;
            Invoke("EndAction", 3f);
        }
        if (Vector2.Distance(transform.position, catParameters._litterArea.transform.position) < 3)
        {
            litter = true;
            Invoke("EndAction", 3f);
        }
    }

    void EndAction()
    {
        feeds = false;
        litter = false;
        ChangeState(defaultState);
    }

}
