using UnityEngine;

public class PauseGamePanelReturnToMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().GoToMainMenuAfterPause();
    }
}
