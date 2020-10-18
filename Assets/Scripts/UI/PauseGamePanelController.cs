public class PauseGamePanelController : UIPanel
{
    void Start()
    {
        UIManager uiManager = UIManager.GetInstance();
        uiManager.OnGamePaused += Show;
        uiManager.OnGameResumed += Hide;
        uiManager.OnGoToMainMenuAfterGamePaused += Hide;
    }
}
