using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private List<BonusPreset> bonusPresets;

    [SerializeField]
    private Text PickedUpCoinsNumberText;

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
        PickedUpCoinsNumber = 0;

        rand = new System.Random();
    }

    public void AttachBonusPresetToSector(Sector sector)
    {
        BonusPreset prefab = GetRandomBonusPreset();
        Instantiate<BonusPreset>(prefab.GetComponent<BonusPreset>(), sector.transform);
    }

    private BonusPreset GetRandomBonusPreset()
    {
        int presetNum = rand.Next(bonusPresets.Count);
        return bonusPresets[presetNum];
    }
}
