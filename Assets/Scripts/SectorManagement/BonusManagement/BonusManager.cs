using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private List<BonusPreset> bonusPresets;

    [SerializeField]
    private Text PickedUpCoinsNumberText;

    [SerializeField]
    private Text FinalCoinsNumberText;

    private int _pickedUpCoinsNumber;
    private System.Random rand;

    public int PickedUpCoinsNumber 
    {
        get { return _pickedUpCoinsNumber; } 

        set
        {
            _pickedUpCoinsNumber = value;
            PickedUpCoinsNumberText.text = value.ToString();
        }
    }

    void Start()
    {
        rand = new System.Random();

        Reset();
    }

    public void AttachBonusPresetToSector(Sector sector)
    {
        BonusPreset prefab = GetRandomBonusPreset();
        Instantiate<BonusPreset>(prefab.GetComponent<BonusPreset>(), sector.transform);
    }

    public void Reset()
    {
        PickedUpCoinsNumber = 0;
    }

    public void FinishGame()
    {
        FinalCoinsNumberText.text = PickedUpCoinsNumber.ToString();
        // TODO save earned coins
    }

    private BonusPreset GetRandomBonusPreset()
    {
        int presetNum = rand.Next(bonusPresets.Count);
        return bonusPresets[presetNum];
    }
}
