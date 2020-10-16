using UnityEngine;

/*
 * Bonus that gives player 5 coins when picked up.
 */
[RequireComponent(typeof(SpriteRenderer))]
public class Ruby : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PickedUpCoinsNumber += 5;
    }
}
