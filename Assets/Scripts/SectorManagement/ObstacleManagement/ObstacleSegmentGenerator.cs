using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleSegmentGenerator : MonoBehaviour
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
        int presetNum = rand.Next(obstaclePresets.Count);
        return obstaclePresets[presetNum];
    }
}
