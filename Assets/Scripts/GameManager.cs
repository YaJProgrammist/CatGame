using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObstaclesAffectedUnityEvent : UnityEvent<UnityAction<Obstacle>>
{
}

public class PlayerHealthAffectedUnityEvent : UnityEvent<UnityAction<HealthController>>
{
}

public class GameManager : MonoBehaviour 
{
    public ObstaclesAffectedUnityEvent ObstaclesAffected = new ObstaclesAffectedUnityEvent();
    public PlayerHealthAffectedUnityEvent PlayerHealthAffected = new PlayerHealthAffectedUnityEvent();

    [SerializeField]
    private Player player;

    [SerializeField]
    private SectorManager sectorManager;

    [SerializeField]
    private Canvas mainMenuCanvas;

    [SerializeField]
    private Canvas playmodeCanvas;

    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Store store;

    [SerializeField]
    private Text currentCoinsNumberText;

    [SerializeField]
    private Text pickedUpCoinsNumberText;

    [SerializeField]
    private Text finalCoinsNumberText;

    private int _pickedUpCoinsNumber;

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

    private void RefreshMainMenuData()
    {
        currentCoinsNumberText.text = DataHolder.GetCurrentCoinsNumber().ToString();
    }

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

    //Singleton logic
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
}
