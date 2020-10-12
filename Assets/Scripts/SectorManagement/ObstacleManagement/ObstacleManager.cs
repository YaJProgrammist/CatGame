using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private List<ObstacleSegmentGenerator> obstacleSegmentGenerators;
    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
    }

    private ObstacleSegmentGenerator GetRandomObstacleSegmentGenerator()
    {
        int generatorNum = rand.Next(obstacleSegmentGenerators.Count);
        return obstacleSegmentGenerators[generatorNum];
    }

    public void AttachObstaclePresetToSector(Sector sector)
    {
        ObstacleSegmentGenerator generator = GetRandomObstacleSegmentGenerator();
        Instantiate(generator.GetRandomObstaclePreset(), sector.transform);
    }
}