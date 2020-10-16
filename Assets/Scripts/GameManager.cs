using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Called when obstacles behavior has to be affected (takes action to perform on obstacles)
public class ObstaclesAffectedUnityEvent : UnityEvent<UnityAction<Obstacle>>
{
}

//Called when player health has to be affected (takes action to perform on health controller)
public class PlayerHealthAffectedUnityEvent : UnityEvent<UnityAction<HealthController>>
{
}

/* 
 * Main manager.
 * Singleton.
 */
public class GameManager : MonoBehaviour 
{
    //Called when obstacles behavior has to be affected
    public ObstaclesAffectedUnityEvent ObstaclesAffected = new ObstaclesAffectedUnityEvent();

    //Called when player health has to be affected
    public PlayerHealthAffectedUnityEvent PlayerHealthAffected = new PlayerHealthAffectedUnityEvent();

    [SerializeField]
    private Player player;

    [SerializeField]
    private SectorManager sectorManager;

    [SerializeField]
    private Canvas mainMenuCanvas;

    [SerializeField]
    private Canvas playmodeCanvas; //canvas that is shown during the game

    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Canvas pauseGameCanvas;

    [SerializeField]
    private Store store;

    /* UI text on main menu canvas that displays 
     total count of coins */
    [SerializeField]
    private Text currentCoinsNumberText;

    /* UI text nn playmode canvas that displays 
     count of coins that have been picked up during current game */
    [SerializeField]
    private Text pickedUpCoinsNumberText;

    /* UI text nn game over canvas that displays 
     count of coins that have been picked up during current game */
    [SerializeField]
    private Text finalCoinsNumberText; 

    private int _pickedUpCoinsNumber;

    //Count of coins that have been picked up during current game
    public int PickedUpCoinsNumber
    {
        get { return _pickedUpCoinsNumber; }

        set
        {
            _pickedUpCoinsNumber = value;
            pickedUpCoinsNumberText.text = value.ToString();
        }
    }

    void Start()
    {
        HealthController playerHealthController = player.GetComponent<HealthController>();
        playerHealthController.NoLivesLeft.AddListener(GameOver);
        RefreshMainMenuData();

        PickedUpCoinsNumber = 0;
    }

    //Play again from game over menu
    public void PlayAgain()
    {
        gameOverCanvas.gameObject.SetActive(false);
        ResetGame();
        StartGame();
    }

    public void StartGame()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        playmodeCanvas.gameObject.SetActive(true);
        sectorManager.MoveOn();
        player.StartMoving();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseGameCanvas.gameObject.SetActive(true);
    }

    //Continue game after pause
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseGameCanvas.gameObject.SetActive(false);
    }

    //Go to main menu from game paused menu
    public void GoToMainMenuAfterPause()
    {
        ResumeGame();
        GameOver();
        GoToMainMenu();
    }

    //Go to main menu when game is over or is not on
    public void GoToMainMenu()
    {
        playmodeCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);

        RefreshMainMenuData();
        ResetGame();
    }

    public void OpenStore()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        store.Open();
    }

    public void CloseStore()
    {
        player.Refresh();
        sectorManager.Refresh();
        RefreshMainMenuData();
        store.Close();
        mainMenuCanvas.gameObject.SetActive(true);
    }

    //Reset everything to initial state
    public void ResetProgress()
    {
        DataHolder.SetInitialSettings();
        RefreshMainMenuData();
        player.Refresh();
    }

    //Get height of sectors
    public float GetPlaySpaceHeight()
    {
        return sectorManager.GetPlaySpaceHeight();
    }

    //Refresh data displayed in main menu
    private void RefreshMainMenuData()
    {
        currentCoinsNumberText.text = DataHolder.GetCurrentCoinsNumber().ToString();
    }

    //Reset properties to state of game start (called after end of game)
    private void ResetGame()
    {
        PickedUpCoinsNumber = 0;
        player.Reset();
        sectorManager.Reset();
    }

    private void GameOver()
    {
        finalCoinsNumberText.text = PickedUpCoinsNumber.ToString();
        DataHolder.SaveEarnedCoins(PickedUpCoinsNumber);

        player.StopMoving();
        playmodeCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
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
