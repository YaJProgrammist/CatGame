using System;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLazerController : MonoBehaviour
{
    [Serializable]
    public class DynamicLazerCycle
    {
        public float WaitingTime;
        public float CautionTime;
        public float DangerTime;
    }

    [SerializeField]
    private List<DynamicLazerCycle> cycles;

    [SerializeField]
    private DynamicLazer lazer;
    
    private DynamicLazerBehavior behavior;

    void Start()
    {
        lazer.DynamicLazerControllerAffected.AddListener((action) => action(this));

        behavior = new DynamicLazerCycledBehaviorUsual(cycles, lazer);
        behavior.Activate();
    }

    void Update()
    {
        behavior.Update();
    }

    public void Weaken()
    {
        behavior = new DynamicLazerCycledBehaviorWeakened(cycles, lazer);
        behavior.Activate();
    }
}
