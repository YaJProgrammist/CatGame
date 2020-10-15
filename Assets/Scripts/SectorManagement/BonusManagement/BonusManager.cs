using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private List<BonusPreset> bonusPresets;

    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
    }

    public void AttachBonusPresetToSector(Sector sector)
    {
        BonusPreset prefab = GetRandomBonusPreset();
        Instantiate(prefab.GetComponent<BonusPreset>(), sector.transform);
    }

    private BonusPreset GetRandomBonusPreset()
    {
        int presetNum = rand.Next(bonusPresets.Count);
        return bonusPresets[presetNum];
    }
}
