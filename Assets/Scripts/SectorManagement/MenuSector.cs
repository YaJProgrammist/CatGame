/*
 * Sector that is shown in main menu and where game starts.
 */
public class MenuSector : Sector
{
    //Show current sector
    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public override sealed void Remove()
    {
        this.gameObject.SetActive(false);
    }
}
