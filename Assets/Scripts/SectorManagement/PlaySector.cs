/*
 * Sector that is used during the game and can contain bonuses and obstacles.
 */
public class PlaySector : Sector
{
    public override sealed void Remove()
    {
        Destroy(this.gameObject);
    }
}
