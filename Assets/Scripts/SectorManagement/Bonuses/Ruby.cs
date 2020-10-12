using UnityEngine;

public class Ruby : Bonus
{
    protected override sealed void MakeImpact()
    {
        // TODO
        GameObject.Find("BonusManager").GetComponent<BonusManager>().PickedUpCoinsNumber += 5;
        // TODO
    }
}
