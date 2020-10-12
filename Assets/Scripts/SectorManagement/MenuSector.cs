using UnityEngine;

public class MenuSector : Sector
{
    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public override sealed void Remove()
    {
        this.gameObject.SetActive(false);
    }
}
