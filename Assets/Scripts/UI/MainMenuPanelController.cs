public class MainMenuPanelController : UIPanel
{
    void Start()
    {
        UIManager uiManager = UIManager.GetInstance();
        uiManager.OnPlayAgain += Hide;
        uiManager.OnGameStarted += Hide;
        uiManager.OnGoToMainMenuAfterGameOver += Show;
        uiManager.OnStoreOpened += Hide;
        uiManager.OnStoreClosed += Show;
    }
}
