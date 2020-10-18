/*
 * Panel that is shown during the game.
 */
public class PlaymodePanelController : UIPanel
{
    void Start()
    {
        UIManager uiManager = UIManager.GetInstance();
        uiManager.OnPlayAgain += Show;
        uiManager.OnGameStarted += Show;
        uiManager.OnGameOver += Hide;
        uiManager.OnGoToMainMenuAfterGameOver += Hide;
    }
}
