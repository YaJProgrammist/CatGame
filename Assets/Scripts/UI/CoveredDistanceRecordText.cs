using UnityEngine;
using UnityEngine.UI;

/* 
 * UI text on playmode panel that displays 
 * distance that has been covered during the current game
 */
[RequireComponent(typeof(Text))]
public class CoveredDistanceRecordText : MonoBehaviour
{
    private Text coveredDistanceRecordText;

    void Start()
    {
        coveredDistanceRecordText = this.GetComponent<Text>();
        UpdateText();
        UIManager.GetInstance().OnCoveredDistanceRecordUpdate += UpdateText;
    }

    private void UpdateText()
    {
        coveredDistanceRecordText.text = DataHolder.GetDistanceRecord().ToString("0.00");
    }
}
