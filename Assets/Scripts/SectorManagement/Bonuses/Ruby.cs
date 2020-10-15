public class Ruby : Bonus
{
    protected override sealed void MakeImpact()
    {
        GameManager gameManager = GameManager.GetInstance();
        gameManager.PickedUpCoinsNumber += 5;
    }
}
