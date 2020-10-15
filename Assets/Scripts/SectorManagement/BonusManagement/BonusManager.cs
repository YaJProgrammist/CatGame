using System.Collections.Generic;
using UnityEditor.Animations;
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
        BonusPreset bonusPreset = Instantiate(prefab.GetComponent<BonusPreset>(), sector.transform);
        ChangeComponentsSkin(bonusPreset, sector.ComponentsSkinFactory);
    }

    private void ChangeComponentsSkin(BonusPreset bonusPreset, SectorComponentsSkinFactory factory)
    {
        ChangeCoinsSkin(bonusPreset, factory.CoinAnimatorController);
        ChangeRubysSkins(bonusPreset, factory.RubySprite);
    }

    private void ChangeCoinsSkin(BonusPreset bonusPreset, AnimatorController coinAnimatorController)
    {
        Coin[] coinsInPreset = bonusPreset.GetComponentsInChildren<Coin>();

        foreach (Coin coin in coinsInPreset)
        {
            coin.GetComponent<Animator>().runtimeAnimatorController = coinAnimatorController;
        }
    }

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
