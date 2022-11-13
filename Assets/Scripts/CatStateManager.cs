using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateManager : MonoBehaviour
{
    BaseState currentState;
    DefaultState defaultState = new DefaultState();
    HungerState hungerState = new HungerState();
    ThirstState thirstState = new ThirstState();
    PeeState peeState = new PeeState();
    PooState pooState = new PooState();
    SleepState sleepState = new SleepState();
    PlayState playState = new PlayState();
    SickState sickState = new SickState();

    [Header("Action Bool")]
    public bool feed;
    public bool thirst;
    public bool bathe;
    public bool play;
    public bool pee;
    public bool poop;

    [Header("Parameters")]
    public float _hunger = 50;
    public float _thirst = 50;
    public float _pee = 10;
    public float _poop = 10;
    public float _dirt = 5;
    public float _happiness = 0;
    public float _discipline = 0;
    public float _health;

    [Header("Counters")]
    public float _hungerCtr = 0;
    public float _thirstCtr = 0;
    public float _peeCtr = 0;
    public float _poopCtr = 0;
    public float _cleanCtr = 0;
    public float _playCtr = 0;
    public float _playDisableCtr = 10f;
    public float _disciplineCtr = 0;

    [Header("Frequency of Parameters")]
    public float _hungerF;
    public float _thirstF;
    public float _peeF;
    public float _poopF;
    public float _cleanF;
    public float _playF;
    public float _playDisableF;

    [Header("Buttons")]
    public Button _feedButton;
    public Button _drinkButton;
    public Button _batheButton;
    public Button _playButton;
    public Button _peeButton;
    public Button _poopButton;

    [Header("Parameter Texts")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;
    public TextMeshProUGUI peeText;
    public TextMeshProUGUI poopText;
    public TextMeshProUGUI dirtText;
    public TextMeshProUGUI happinessText;
    public TextMeshProUGUI disciplineText;

    [Header("Misc")]
    public Transform _foodArea;
    public Transform _litterArea;
    public Transform _sleepArea;
    public float _speed;
    public TMP_Text _stateText;
    public GameObject _poopInstance;
    public GameObject _peeInstance;
    public FeedArea_Script _feedArea;
    public Time_Manager tm;
    [SerializeField] private List<GameObject> _actionButtons = new List<GameObject>();
    void Start()
    {
        currentState = defaultState;
        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateLogic(this);
    }
}
