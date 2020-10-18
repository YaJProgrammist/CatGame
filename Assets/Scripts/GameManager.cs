using UnityEngine;
using UnityEngine.Events;

/* 
 * Main manager.
 * Singleton.
 */
public class GameManager : MonoBehaviour 
{
    //Called when obstacles behavior has to be affected
    public OnObstaclesAffectedUnityEvent OnObstaclesAffected = new OnObstaclesAffectedUnityEvent();

    //Called when player health has to be affected
    public UnityAction<UnityAction<HealthController>> OnPlayerHealthAffected;

    //Called when game has to be started
    public UnityAction OnGameStarted;

    //Called when game has to be paused
    public UnityAction OnGamePaused;

    //Called when game has to be resumed
    public UnityAction OnGameResumed;

    //Called when game has to be reset
    public UnityAction OnGameReset;

    //Called when game has to be over
    public UnityAction OnGameOver;

    //Called when store has to be opened
    public UnityAction OnStoreOpened;

    //Called when store has to be closed
    public UnityAction OnStoreClosed;

    //Called when progress has to be reset
    public UnityAction OnResetProgress;

    //Called when picked up coins count was changed
    public UnityAction OnPickedUpCoinsCountChanged;

    //Called when covered distance was changed
    public UnityAction OnCoveredDistanceChanged;

    private int _pickedUpCoinsNumber;
    private float _coveredDistance;

    //Count of coins that have been picked up during current game
    public int PickedUpCoinsNumber
    {
        get { return _pickedUpCoinsNumber; }

        set
        {
            _pickedUpCoinsNumber = value;
            OnPickedUpCoinsCountChanged?.Invoke();
        }
    }

    public float CoveredDistance
    {
        get { return _coveredDistance; }

        set
        {
            _coveredDistance = value;
            OnCoveredDistanceChanged?.Invoke();
        }
    }

    void Start()
    {
        PickedUpCoinsNumber = 0;
        CoveredDistance = 0;
    }

    //Play again from game over menu
    public void PlayAgain()
    {
        ResetGame();
        StartGame();
    }

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        DataHolder.SaveEarnedCoins(PickedUpCoinsNumber);
        DataHolder.SaveDistanceRecord(CoveredDistance);

        OnGameOver?.Invoke();
    }

    public void PauseGame()
    {
        OnGamePaused?.Invoke();
        Time.timeScale = 0;
    }

    //Continue game after pause
    public void ResumeGame()
    {
        OnGameResumed?.Invoke();
        Time.timeScale = 1;
    }

    public void OpenStore()
    {
        OnStoreOpened?.Invoke();
    }

    public void CloseStore()
    {
        OnStoreClosed?.Invoke();
    }

    //Reset everything to initial state
    public void ResetProgress()
    {
        DataHolder.SetInitialSettings();
        OnResetProgress?.Invoke();
    }

    //Reset properties to state of game start (called after end of game)
    public void ResetGame()
    {
        PickedUpCoinsNumber = 0;
        CoveredDistance = 0;

        OnGameReset?.Invoke();
    }

    //Singleton logic:
    //v ****************************************** v

    private static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
    //^ ****************************************** ^
}
