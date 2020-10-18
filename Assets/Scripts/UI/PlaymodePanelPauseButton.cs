using UnityEngine;

public class PlaymodePanelPauseButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().PauseGame();
    }
}
