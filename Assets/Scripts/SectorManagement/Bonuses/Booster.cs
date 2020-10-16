/* 
 * Bonus that pushes player to go faster and without collisions 
 * in the beginning of the game when applied. 
 * Can be picked up during the game or bought.
 */
public class Booster : Bonus
{
    //Called when item is picked up
    protected override sealed void MakeImpact()
    {
        DataHolder.PutItemIntoStorage(Item.Booster);
    }
}
