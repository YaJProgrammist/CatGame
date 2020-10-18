using UnityEngine;
using UnityEngine.UI;

/* 
 * UI text on playmode panel that displays 
 * count of coins that have been picked up during current game 
 */
[RequireComponent(typeof(Text))]
public class PickedUpCoinsNumberText : MonoBehaviour
{
    private Text pickedUpCoinsNumberText;

    void Start()
    {
        pickedUpCoinsNumberText = this.GetComponent<Text>();
        UpdateText();
        UIManager.GetInstance().OnPickedUpCoinsCountUpdate += UpdateText;
    }

    private void UpdateText()
    {
        pickedUpCoinsNumberText.text = GameManager.GetInstance().PickedUpCoinsNumber.ToString();
    }
}
