using UnityEngine;

public class StoreModeFactory : MonoBehaviour
{
    [SerializeField]
    private Color backgroundColor;

    [SerializeField]
    private DesignMode correspondingDesignMode;

    public Color GetBackgroundColor()
    {
        return backgroundColor;
    }

    public DesignMode GetСorrespondingDesignMode()
    {
        return correspondingDesignMode;
    }
}
