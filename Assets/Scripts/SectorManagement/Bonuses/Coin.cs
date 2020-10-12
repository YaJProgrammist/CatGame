using UnityEngine;

public class Coin : Bonus
{
    protected override sealed void MakeImpact()
    {
        // TODO
        GameObject.Find("BonusManager").GetComponent<BonusManager>().PickedUpCoinsNumber++;
        // TODO
    }
}
