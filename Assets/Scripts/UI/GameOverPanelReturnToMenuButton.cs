using UnityEngine;

public class GameOverPanelReturnToMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().GoToMainMenuAfterGameOver();
    }
}
