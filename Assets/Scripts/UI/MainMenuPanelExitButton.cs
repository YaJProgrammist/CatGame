using UnityEngine;

public class MainMenuPanelExitButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().ExitGame();
    }
}
