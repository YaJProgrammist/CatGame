public class PlaySector : Sector
{
    public override sealed void Remove()
    {
        Destroy(this.gameObject);
    }
}
