public class Booster : Bonus
{
    protected override sealed void MakeImpact()
    {
        DataHolder.SaveItemAsBought(Item.Booster);
    }
}
