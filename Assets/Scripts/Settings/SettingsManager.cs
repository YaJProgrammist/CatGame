using UnityEngine;

/*
 * Singleton.
 */
public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private DesignSettings designSettings;

    [SerializeField]
    private PlayerSettings playerSettings;

    [SerializeField]
    private BonusesSettings bonusesSettings;

    [SerializeField]
    private ObstaclesSettings obstaclesSettings;

    [SerializeField]
    private StoreSettings storeSettings;

    public DesignSettings GetDesignSettings()
    {
        return designSettings;
    }

    public PlayerSettings GetPlayerSettings()
    {
        return playerSettings;
    }

    public BonusesSettings GetBonusesSettings()
    {
        return bonusesSettings;
    }
    public ObstaclesSettings GetObstaclesSettings()
    {
        return obstaclesSettings;
    }

    public StoreSettings GetStoreSettings()
    {
        return storeSettings;
    }

    //Singleton logic:
    //v ****************************************** v

    private static SettingsManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static SettingsManager GetInstance()
    {
        return instance;
    }
    //^ ****************************************** ^
}
