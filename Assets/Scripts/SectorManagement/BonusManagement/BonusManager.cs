using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for sector bonuses generation.
 */
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
        BonusPreset bonusPreset = Instantiate(prefab.GetComponent<BonusPreset>(), sector.transform);
        ChangeComponentsSkin(bonusPreset, sector.ComponentsSkinFactory);
    }

    //Change default bonus skins to skins that match the sector's design
    private void ChangeComponentsSkin(BonusPreset bonusPreset, SectorComponentsSkinFactory factory)
    {
        ChangeCoinsSkin(bonusPreset, factory.CoinAnimatorController);
        ChangeRubysSkins(bonusPreset, factory.RubySprite);
    }

    //Change default coins skins to skins that match the sector's design
    private void ChangeCoinsSkin(BonusPreset bonusPreset, RuntimeAnimatorController coinAnimatorController)
    {
        Coin[] coinsInPreset = bonusPreset.GetComponentsInChildren<Coin>();

        foreach (Coin coin in coinsInPreset)
        {
            coin.GetComponent<Animator>().runtimeAnimatorController = coinAnimatorController;
        }
    }

    //Change default rubys skins to skins that match the sector's design
    private void ChangeRubysSkins(BonusPreset bonusPreset, Sprite rubySprite)
    {
        Ruby[] rubysInPreset = bonusPreset.GetComponentsInChildren<Ruby>();

        foreach (Ruby ruby in rubysInPreset)
        {
            ruby.GetComponent<SpriteRenderer>().sprite = rubySprite;
        }
    }

    private BonusPreset GetRandomBonusPreset()
    {
        int presetNum = rand.Next(bonusPresets.Count);
        return bonusPresets[presetNum];
    }
}
