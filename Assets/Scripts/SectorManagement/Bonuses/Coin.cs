using UnityEngine;

/*
 * Bonus that gives player a coin when picked up.
 */
[RequireComponent(typeof(Animator))]
public class Coin : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PickedUpCoinsNumber++;
    }
}
