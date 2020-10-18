using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/* 
 * Responsible for all the UI.
 * Singleton.
 */
public class UIManager : MonoBehaviour
{
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

    //Called when game has to be started after it was over
    public UnityAction OnPlayAgain;
    
    //Called when game has to be started
    public UnityAction OnGameStarted;

    //Called when game has to be paused
    public UnityAction OnGamePaused;

    //Called when game has to be resumed
    public UnityAction OnGameResumed;

    //Called when main menu has to be showed after game over
    public UnityAction OnGoToMainMenuAfterGameOver;

    //Called when main menu has to be showed after game paused
    public UnityAction OnGoToMainMenuAfterGamePaused;

    //Called when game has to be over
    public UnityAction OnGameOver;

    //Called when store has to be opened
    public UnityAction OnStoreOpened;

    //Called when store has to be closed
    public UnityAction OnStoreClosed;

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
        OnPlayAgain?.Invoke();
        GameManager.GetInstance().PlayAgain();
    }

    public void StartGame()
    {
        OnGameStarted?.Invoke();
        GameManager.GetInstance().StartGame();
    }

    private void GameOver()
    {
        OnFinalCoinsCountUpdate?.Invoke();
        OnFinalCoveredDistanceUpdate?.Invoke();
        OnGameOver?.Invoke();
    }

    public void PauseGame()
    {
        OnGamePaused?.Invoke();
        GameManager.GetInstance().PauseGame();
    }

    //Continue game after pause
    public void ResumeGame()
    {
        OnGameResumed?.Invoke();
        GameManager.GetInstance().ResumeGame();
    }

    //Go to main menu when game is over or is not on
    public void GoToMainMenuAfterGameOver()
    {
        OnGoToMainMenuAfterGameOver?.Invoke();
        RefreshMainMenuData();

        GameManager.GetInstance().ResetGame();
    }

    //Go to main menu from game paused menu
    public void GoToMainMenuAfterPause()
    {
        OnGoToMainMenuAfterGamePaused?.Invoke();

        GameManager.GetInstance().ResumeGame();
        GameManager.GetInstance().GameOver();

        RefreshMainMenuData();

        GameManager.GetInstance().ResetGame();
    }

    public void OpenStore()
    {
        OnStoreOpened?.Invoke();
        GameManager.GetInstance().OpenStore();
    }

    public void CloseStore()
    {
        OnStoreClosed?.Invoke();
        RefreshMainMenuData();

        GameManager.GetInstance().CloseStore();
    }
    
    //Reset everything to initial state
    public void ResetProgress()
    {
        GameManager.GetInstance().ResetProgress();
        RefreshMainMenuData();
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
