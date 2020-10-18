using UnityEngine;
using UnityEngine.UI;

/* 
 * UI text on game over panel that displays 
 * count of coins that have been picked up during current game 
 */
[RequireComponent(typeof(Text))]
public class FinalCoinsNumberText : MonoBehaviour
{
    private Text finalCoinsNumberText;

    void Start()
    {
        finalCoinsNumberText = this.GetComponent<Text>();
        UpdateText();
        UIManager.GetInstance().OnFinalCoinsCountUpdate += UpdateText;
    }

    private void UpdateText()
    {
        finalCoinsNumberText.text = GameManager.GetInstance().PickedUpCoinsNumber.ToString();
    }
}
