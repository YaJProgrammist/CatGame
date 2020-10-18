using UnityEngine;
using UnityEngine.UI;

/* 
 * UI text on main menu panel that displays 
 * total count of coins 
 */
[RequireComponent(typeof(Text))]
public class CurrentCoinsNumberText : MonoBehaviour
{
    private Text currentCoinsNumberText;

    void Start()
    {
        currentCoinsNumberText = this.GetComponent<Text>();
        UpdateText();
        UIManager.GetInstance().OnTotalCoinsCountUpdate += UpdateText;
    }

    private void UpdateText()
    {
        currentCoinsNumberText.text = DataHolder.GetCurrentCoinsNumber().ToString();
    }
}
