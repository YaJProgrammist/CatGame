using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/* 
 * Responsible for all the UI.
 * Singleton.
 */
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform mainMenuPanel;

    [SerializeField]
    private RectTransform playmodePanel;

    [SerializeField]
    private RectTransform pauseGamePanel;

    [SerializeField]
    private RectTransform gameOverPanel;

    [SerializeField]
    private RectTransform storePanel;

    //Called when picked up coins count texts has to be updated
    public UnityAction OnPickedUpCoinsCountUpdate;

    //Called when final coins count texts has to be updated (when game is over)
    public UnityAction OnFinalCoinsCountUpdate;

    //Called when final covered distance texts has to be updated (when game is over)
    public UnityAction OnFinalCoveredDistanceUpdate;

    //Called when total coins count texts has to be updated
    public UnityAction OnTotalCoinsCountUpdate;

    //Called when covered distance texts has to be updated
    public UnityAction OnCoveredDistanceUpdate;

    //Called when covered distance record texts has to be updated
    public UnityAction OnCoveredDistanceRecordUpdate;

    void Start()
    {
        GameManager.GetInstance().OnGameOver += GameOver;
        GameManager.GetInstance().OnPickedUpCoinsCountChanged += UpdatePickedUpCoinsCount;
        GameManager.GetInstance().OnCoveredDistanceChanged += UpdateDistanceChanged;

        RefreshMainMenuData();
    }

    //Play again from game over menu
    public void PlayAgain()
    {
        mainMenuPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        playmodePanel.gameObject.SetActive(true);

        GameManager.GetInstance().PlayAgain();
    }

    public void StartGame()
    {
        mainMenuPanel.gameObject.SetActive(false);
        playmodePanel.gameObject.SetActive(true);

        GameManager.GetInstance().StartGame();
    }

    private void GameOver()
    {
        OnFinalCoinsCountUpdate?.Invoke();
        OnFinalCoveredDistanceUpdate?.Invoke();

        gameOverPanel.gameObject.SetActive(true);
        playmodePanel.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        pauseGamePanel.gameObject.SetActive(true);

        GameManager.GetInstance().PauseGame();
    }

    //Continue game after pause
    public void ResumeGame()
    {
        pauseGamePanel.gameObject.SetActive(false);

        GameManager.GetInstance().ResumeGame();
    }

    //Go to main menu when game is over or is not on
    public void GoToMainMenuAfterGameOver()
    {
        mainMenuPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        playmodePanel.gameObject.SetActive(false);

        RefreshMainMenuData();

        GameManager.GetInstance().ResetGame();
    }

    //Go to main menu from game paused menu
    public void GoToMainMenuAfterPause()
    {
        pauseGamePanel.gameObject.SetActive(false);

        GameManager.GetInstance().ResumeGame();
        GameManager.GetInstance().GameOver();

        GoToMainMenuAfterGameOver();
    }

    public void OpenStore()
    {
        mainMenuPanel.gameObject.SetActive(false);
        storePanel.gameObject.SetActive(true);

        GameManager.GetInstance().OpenStore();
    }

    public void CloseStore()
    {
        mainMenuPanel.gameObject.SetActive(true);
        storePanel.gameObject.SetActive(false);

        RefreshMainMenuData();

        GameManager.GetInstance().CloseStore();
    }

    //Reset everything to initial state
    public void ResetProgress()
    {
        GameManager.GetInstance().ResetProgress();
        RefreshMainMenuData();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void UpdatePickedUpCoinsCount()
    {
        OnPickedUpCoinsCountUpdate?.Invoke();
    }

    private void UpdateDistanceChanged()
    {
        OnCoveredDistanceUpdate?.Invoke();
    }

    //Refresh data displayed in main menu
    private void RefreshMainMenuData()
    {
        OnTotalCoinsCountUpdate?.Invoke();
        OnCoveredDistanceRecordUpdate?.Invoke();
    }

    //Singleton logic:
    //v ****************************************** v

    private static UIManager instance;

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

    public static UIManager GetInstance()
    {
        return instance;
    }
    //^ ****************************************** ^
}
