using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for sectors generation and removal.
 */
public class SectorManager : MonoBehaviour 
{
    [SerializeField]
    private List<SectorComponentsSkinFactory> sectorComponentsSkinFactories;

    [SerializeField]
    private MenuSector menuSector; //sector that is displayed in main menu

    [SerializeField]
    private BonusManager bonusManager;

    [SerializeField]
    private ObstacleManager obstacleManager;

    //sectorComponentsSkinFactories that were marked as applied in Storage
    private List<SectorComponentsSkinFactory> appliedSectorComponentsSkinFactories;

    private Queue<Sector> sectorQueue; //queue of sectors that are present in game
    private Vector3 startSectorPosition; //position of left wall of the first sector after menu sector
    private Vector3 nextSectorPosition; //position of left wall of next sector
    private System.Random rand;

    void Start()
    {
        sectorQueue = new Queue<Sector>();
        sectorQueue.Enqueue(menuSector);

        startSectorPosition = new Vector3
        (
            menuSector.transform.position.x + menuSector.transform.localScale.x,
            menuSector.transform.position.y,
            menuSector.transform.position.z
        );

        nextSectorPosition = startSectorPosition;

        rand = new System.Random();

        appliedSectorComponentsSkinFactories = new List<SectorComponentsSkinFactory>();

        RefreshAllowedFactories();
    }

    //Generate next piece of game space
    public void MoveOn()
    {
        SectorComponentsSkinFactory factory = GetRandomSectorComponentsSkinFactory();
        Sector newSector = factory.InstantiateNewSector();

        newSector.transform.position = nextSectorPosition;

        //Listen if trigger of sector pre-end is triggered - then generate next piece of game space
        newSector.EndTriggered.AddListener(MoveOn);

        bonusManager.AttachBonusPresetToSector(newSector);
        obstacleManager.AttachRandomObstaclePresetsToSector(newSector);        

        sectorQueue.Enqueue(newSector);

        if (sectorQueue.Count > 2)
        {
            sectorQueue.Dequeue().Remove();
        }

        nextSectorPosition.x += newSector.transform.localScale.x;
    }

    //Return to state of main menu open
    public void Reset()
    {
        ClearAll();
        ActivateMenuSector();
    }

    //Refresh generation data (factories that are allowed to use to generate sectors)
    public void Refresh()
    {
        RefreshAllowedFactories();
    }

    //Get height of all sectors
    public float GetPlaySpaceHeight()
    {
        return menuSector.transform.localScale.y;
    }

    //Remove all sectors that are still present
    private void ClearAll()
    {
        foreach (Sector sector in sectorQueue)
        {
            sector.Remove();
        }

        sectorQueue.Clear();

        nextSectorPosition = startSectorPosition;
    }

    //Refresh info about which factories are allowed to use in sectors generation
    private void RefreshAllowedFactories()
    {
        foreach (SectorComponentsSkinFactory factory in sectorComponentsSkinFactories)
        {
            if (DataHolder.GetIfItemIsApplied(factory.GetSectorType()))
            {
                appliedSectorComponentsSkinFactories.Add(factory);
            }
        }
    }

    private SectorComponentsSkinFactory GetRandomSectorComponentsSkinFactory()
    {
        int factoryNum = rand.Next(appliedSectorComponentsSkinFactories.Count);
        return appliedSectorComponentsSkinFactories[factoryNum];
    }

    //Show sector that is displayed in main menu
    private void ActivateMenuSector()
    {
        menuSector.Activate();
        sectorQueue.Enqueue(menuSector);
    }
}
