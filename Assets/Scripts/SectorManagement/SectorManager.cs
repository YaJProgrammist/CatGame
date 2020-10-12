using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour // TODO class menu sector + class game sector + different Anactivate()
{
    [SerializeField]
    private List<SectorComponentsSkinFactory> sectorComponentsSkinFactories;

    [SerializeField]
    private Sector menuSector;

    [SerializeField]
    private BonusManager bonusManager;

    [SerializeField]
    private ObstacleManager obstacleManager;

    private Queue<Sector> sectorQueue;
    private Vector3 nextSectorPosition;
    private System.Random rand;

    void Start()
    {
        // TODO check allowed factories

        sectorQueue = new Queue<Sector>();

        nextSectorPosition = new Vector3
        (
            menuSector.transform.position.x + menuSector.transform.localScale.x / 2,
            1.26f,
            -8
        );

        rand = new System.Random();
    }

    public void MoveOn()
    {
        SectorComponentsSkinFactory factory = GetRandomSectorComponentsSkinFactory();
        Sector newSector = factory.GetNewSector();
        nextSectorPosition.x += newSector.transform.localScale.x / 2;
        newSector.transform.position = nextSectorPosition;
        newSector.EndTriggered.AddListener(MoveOn);

        bonusManager.AttachBonusPresetToSector(newSector);
        obstacleManager.AttachObstaclePresetToSector(newSector);        

        sectorQueue.Enqueue(newSector);

        if (sectorQueue.Count > 2)
        {
            Destroy(sectorQueue.Dequeue().gameObject);
        }

        nextSectorPosition.x += newSector.transform.localScale.x / 2;
    }

    private SectorComponentsSkinFactory GetRandomSectorComponentsSkinFactory()
    {
        int factoryNum = rand.Next(sectorComponentsSkinFactories.Count);
        return sectorComponentsSkinFactories[factoryNum];
    }
}
