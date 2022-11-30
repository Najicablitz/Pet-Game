using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatParameters : MonoBehaviour
{
    [Header("Action Bool")]
    public bool feed;
    public bool thirst;
    public bool bathe;
    public bool play;
    public bool pee;
    public bool poop;
    public bool playState;

    [Header("Parameters")]
    public float _hunger = 50;
    public float _thirst = 50;
    public float _pee = 10;
    public float _poop = 10;
    public float _dirt = 5;
    public float _happiness = 0;
    public float _discipline = 0;
    public float _health;
    public bool isPlaying;
    public bool isSick;

    [Header("Counters")]
    public float _hungerCtr = 0;
    public float _thirstCtr = 0;
    public float _peeCtr = 0;
    public float _poopCtr = 0;
    public float _cleanCtr = 0;
    public float _playCtr = 0;
    public float _playDisableCtr = 10f;
    public float _disciplineCtr = 0;
    public float _sickCtr = 100;

    [Header("Frequency of Parameters")]
    public float _hungerF;
    public float _thirstF;
    public float _peeF;
    public float _poopF;
    public float _cleanF;
    public float _playF;
    public float _playDisableF;

    [Header("Interactions")]
    public Image _feedAction;
    public Image _drinkAction;
    public Button _batheButton;
    public GameObject _playAction;
    public Button _playButton;
    public Image _peeButton;
    public Image _poopButton;
    public Button _cureButton;

    [Header("Parameter Texts")]
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
    public Transform _centerArea;
    public float _speed;
    public TMP_Text _stateText;
    public GameObject _poopInstance;
    public GameObject _peeInstance;
    public Time_Manager tm;
    private CatStateManager catState;
    [SerializeField] private Slider _healthSlider;
    public Slider _playSlider;
    private CurrentDay currentDay;

    void Start()
    {
        catState = FindObjectOfType<CatStateManager>();
        currentDay = FindObjectOfType<CurrentDay>();
    }

    void Update()
    {
        if(currentDay.pause == false)
        {
            Hunger();
            Thirst();
            Pee();
            Poop();
            Play();
            Cleanliness();
            Damage();
            

            _healthSlider.value = _health;
        }   
    }

    private void Awake()
    {
        _batheButton.onClick.AddListener(Bathing);
        //_playAction.onClick.AddListener(Playing);
        _cureButton.onClick.AddListener(Cure);
    }

    /*private void ParameterText()
    {
        hungerText.text = $"Hunger: {_hunger}";
        thirstText.text = $"Thirst: {_thirst}";
        peeText.text = $"Pee: {_pee}";
        poopText.text = $"Poop: {_poop}";
        dirtText.text = $"Dirt: {_dirt}";
        happinessText.text = $"Happiness: {_happiness}";
        disciplineText.text = $"Discipline: {_discipline}";
    }*/

    #region Parameters
    public void Hunger()
    {
        _hungerCtr += Time.deltaTime;
        //Debug.Log($"HungerCtr: {_hungerCtr}");
        if (_hungerCtr > _hungerF)
        {
            _hunger--;
            _hungerCtr = 0;
        }
        if (_hunger < 0)
        {
            _hunger = 0;
        }
        if (_hunger > 100)
        {
            _hunger = 100;
        }
    }

    public void Thirst()
    {
        _thirstCtr += Time.deltaTime;
        //Debug.Log($"ThirstCtr: {_thirstCtr}");
        if (_thirstCtr > _thirstF)
        {
            _thirst--;
            _thirstCtr = 0;
        }
        if (_thirst < 0)
        {
            _thirst = 0;
        }
        if (_thirst > 100)
        {
            _thirst = 100;
        }
    }

    public void Play()
    {
        if(catState.currentState == catState.defaultState && playState == false)
        {
            if (isPlaying == false)
            {
                _playCtr -= Time.deltaTime;
                _playDisableCtr = _playDisableF;
            }
            if (_playCtr <= 0)
            {
                isPlaying = true;
                _playCtr = _playF;
            }
            if (isPlaying == true)
            {
                _playCtr = _playF;
                _playDisableCtr -= Time.deltaTime;
            }
            if (_playDisableCtr <= 0)
            {
                isPlaying = false;
                _happiness -= 5;
                _playDisableCtr = _playDisableF;
            }
            if (_happiness < 0)
            {
                _happiness = 0;
            }
            if (_happiness > 100)
            {
                _happiness = 100;
            }
        }
        
    }

    public void Pee()
    {
        _peeCtr += Time.deltaTime;
        //Debug.Log($"PeeCtr: {_peeCtr}");
        if (_peeCtr > _peeF)
        {
            _pee++;
            _peeCtr = 0;
        }
        

        if (_pee < 0)
        {
            _pee = 0;
        }
        if (_pee > 100)
        {
            _pee = 100;
        }
    }

    public void Poop()
    {
        _poopCtr += Time.deltaTime;
        //Debug.Log($"PoopCtr: {_poopCtr}");
        if (_poopCtr > _poopF)
        {
            _poop++;
            _poopCtr = 0;
        }
        if (_poop >= 100 && _discipline < 50)
        {
            Instantiate(_poopInstance, this.transform.position, Quaternion.identity);
            _poop = 0;
        }
        if (_poop < 0)
        {
            _poop = 0;
        }
        if (_poop > 100)
        {
            _poop = 100;
        }
    }

    public void Cleanliness()
    {
        _cleanCtr += Time.deltaTime;
        //Debug.Log($"CleanCtr: {_cleanCtr}");
        if (_cleanCtr > _cleanF)
        {
            _dirt++;
            _cleanCtr = 0;
        }
        if (_dirt < 0)
        {
            _dirt = 0;
        }
        if (_dirt > 100)
        {
            _dirt = 100;
        }
        if(_dirt >= 100 || _happiness < 20)
        {           
            _sickCtr -= Time.deltaTime;
        }
        else
        {
            _sickCtr = 100;
        }
        if(_sickCtr <= 0)
        {
            isSick = true;
        }
    }

    private void Damage()
    {
        if (_hunger <= 0 || _thirst <= 0 || isSick == true)
        {
            _health -= Time.deltaTime;
        }
        else
        {
            if (_health < 100)
            {
                _health += Time.deltaTime;
            }
        }
        if (_health < 0)
        {
            _health = 0;
        }
        if (_health > 100)
        {
            _health = 100;
        }
    }
    #endregion

    private void Bathing()
    {
        _dirt = 0;
        _batheButton.gameObject.SetActive(false);
    }
    public void PlayState()
    {
        _playButton.gameObject.SetActive(false);
        _playAction.gameObject.SetActive(true);
        _playSlider.gameObject.SetActive(true);
        playState = true;
    }
    public void Playing()
    {
        _happiness += 5;
        isPlaying = false;
        playState = false;
        _playAction.gameObject.SetActive(false);
        _playSlider.gameObject.SetActive(false);
    }

    private void Cure()
    {
        _cureButton.gameObject.SetActive(false);
        isSick = false;
    }
}
