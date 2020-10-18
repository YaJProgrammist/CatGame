public class GameOverPanelController : UIPanel
{
    void Start()
    {
        UIManager uiManager = UIManager.GetInstance();
        uiManager.OnPlayAgain += Hide;
        uiManager.OnGameOver += Show;
        uiManager.OnGoToMainMenuAfterGameOver += Hide;
    }
}
