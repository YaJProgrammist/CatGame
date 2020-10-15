using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleSegmentGenerator : MonoBehaviour
{
    [SerializeField]
    private List<ObstaclePreset> obstaclePresets;

    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
    }

    public ObstaclePreset GetRandomObstaclePreset()
    {
        if (obstaclePresets.Count == 0)
        {
            return null; // TODO error
        }

        int presetNum = rand.Next(obstaclePresets.Count);
        return obstaclePresets[presetNum];
    }
}
