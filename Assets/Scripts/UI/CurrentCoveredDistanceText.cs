﻿using UnityEngine;
using UnityEngine.UI;

/* 
 * UI text on playmode panel that displays 
 * distance that has been covered during the current game
 */
[RequireComponent(typeof(Text))]
public class CurrentCoveredDistanceText : MonoBehaviour
{
    private Text coveredDistanceText;

    void Start()
    {
        coveredDistanceText = this.GetComponent<Text>();
        UpdateText();
        UIManager.GetInstance().OnCoveredDistanceUpdate += UpdateText;
    }

    private void UpdateText()
    {
        coveredDistanceText.text = GameManager.GetInstance().CoveredDistance.ToString("0.00");
    }
}
