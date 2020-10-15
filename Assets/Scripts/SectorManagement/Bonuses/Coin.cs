using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PickedUpCoinsNumber++;
    }
}
