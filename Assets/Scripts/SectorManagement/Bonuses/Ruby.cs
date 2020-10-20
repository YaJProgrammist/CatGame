using UnityEngine;

/*
 * Bonus that gives player 5 coins when picked up.
 */
[RequireComponent(typeof(SpriteRenderer))]
public class Ruby : Bonus
{
    private int coinsBonusNumber;

    void Start()
    {
        coinsBonusNumber = SettingsManager.GetInstance().GetBonusesSettings().GetRubySettings().GetCoinsCost();
    }

    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PickedUpCoinsNumber += coinsBonusNumber;
    }
}
