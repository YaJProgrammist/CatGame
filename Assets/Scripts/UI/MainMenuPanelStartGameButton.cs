using UnityEngine;

public class MainMenuPanelStartGameButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().StartGame();
    }
}
