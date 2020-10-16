using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour 
{
    [SerializeField]
    private List<SectorComponentsSkinFactory> sectorComponentsSkinFactories;

    [SerializeField]
    private MenuSector menuSector;

    [SerializeField]
    private BonusManager bonusManager;

    [SerializeField]
    private ObstacleManager obstacleManager;

    private List<SectorComponentsSkinFactory> appliedSectorComponentsSkinFactories;
    private Queue<Sector> sectorQueue;
    private Vector3 startSectorPosition;
    private Vector3 nextSectorPosition;
    private System.Random rand;

    void Start()
    {
        sectorQueue = new Queue<Sector>();
        sectorQueue.Enqueue(menuSector);

        startSectorPosition = new Vector3
        (
            menuSector.transform.position.x + menuSector.transform.localScale.x / 2,
            1.26f,
            -8
        );

        nextSectorPosition = startSectorPosition;

        rand = new System.Random();

        appliedSectorComponentsSkinFactories = new List<SectorComponentsSkinFactory>();

        RefreshAllowedFactories();
    }

    public void MoveOn()
    {
        SectorComponentsSkinFactory factory = GetRandomSectorComponentsSkinFactory();
        Sector newSector = factory.GetNewSector();
        nextSectorPosition.x += newSector.transform.localScale.x / 2;
        newSector.transform.position = nextSectorPosition;
        newSector.EndTriggered.AddListener(MoveOn);

        bonusManager.AttachBonusPresetToSector(newSector);
        obstacleManager.AttachObstaclePresetsToSector(newSector);        

        sectorQueue.Enqueue(newSector);

        if (sectorQueue.Count > 2)
        {
            sectorQueue.Dequeue().Remove();
        }

        nextSectorPosition.x += newSector.transform.localScale.x / 2;
    }

    public void Reset()
    {
        ClearAll();
        ActivateMenuSector();
    }

    public void Refresh()
    {
        RefreshAllowedFactories();
    }

    public float GetSectorHeight()
    {
        return menuSector.transform.localScale.y;
    }

    private void ClearAll()
    {
        foreach (Sector sector in sectorQueue)
        {
            sector.Remove();
        }

        sectorQueue.Clear();

        nextSectorPosition = startSectorPosition;
    }

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

    private void ActivateMenuSector()
    {
        menuSector.Activate();
        sectorQueue.Enqueue(menuSector);
    }
}
