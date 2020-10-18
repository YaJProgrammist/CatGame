using UnityEngine;

public class GameOverPanelPlayAgainButton : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance().PlayAgain();
    }
}
