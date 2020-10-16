using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for sector obstacles generation.
 */
public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private List<ObstacleSegmentGenerator> obstacleSegmentGenerators;

    [SerializeField]
    private int obstacleSegmentsPerSectorNumber;

    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
    }

    private void AttachObstaclePresetToSector(Sector sector, ObstacleSegmentGenerator obstacleGenerator)
    {
        ObstaclePreset presetPrefab = obstacleGenerator.GetRandomObstaclePreset();

        if (presetPrefab == null)
        {
            return;
        }

        Instantiate(presetPrefab, sector.transform);
    }

    private List<ObstacleSegmentGenerator> GetListOfRandomObstacleGenerators(int obstacleGeneratorsCount)
    {
        List<ObstacleSegmentGenerator> generators = new List<ObstacleSegmentGenerator>();

        if (obstacleGeneratorsCount > obstacleSegmentGenerators.Count)
        {
            obstacleGeneratorsCount = obstacleSegmentGenerators.Count;
        }

        int currentLastInd = -1;
        for (int i = 0; i < obstacleGeneratorsCount; i++)
        {
            currentLastInd = rand.Next(currentLastInd + 1, obstacleSegmentGenerators.Count - (obstacleGeneratorsCount - i - 1));
            generators.Add(obstacleSegmentGenerators[currentLastInd]);
        }

        return generators;
    }

    public void AttachRandomObstaclePresetsToSector(Sector sector)
    {
        List<ObstacleSegmentGenerator> generators = GetListOfRandomObstacleGenerators(obstacleSegmentsPerSectorNumber);

        foreach (ObstacleSegmentGenerator generator in generators)
        {
            AttachObstaclePresetToSector(sector, generator);
        }
    }
}