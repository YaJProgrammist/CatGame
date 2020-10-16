using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for sector obstacles of a certain type generation.
 */
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
            return null;
        }

        int presetNum = rand.Next(obstaclePresets.Count);
        return obstaclePresets[presetNum];
    }
}
