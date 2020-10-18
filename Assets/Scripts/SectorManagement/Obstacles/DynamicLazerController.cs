using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for dynamic lazer states.
 */
public class DynamicLazerController : MonoBehaviour
{
    //Cycle of dynamic lazer changing states
    [Serializable]
    public class DynamicLazerCycle
    {
        public float WaitingTime; //time during which lazer is unactive
        public float CautionTime; //time during which lazer is in caution mode
        public float DangerTime; //time during which lazer is in danger mode
    }

    [SerializeField]
    private List<DynamicLazerCycle> cycles;

    [SerializeField]
    private DynamicLazer lazer;
    
    private DynamicLazerBehavior behavior;

    void Start()
    {
        lazer.OnDynamicLazerControllerAffected += (action) => action(this);

        behavior = new DynamicLazerCycledBehaviorUsual(cycles, lazer);
        behavior.Activate();
    }

    void Update()
    {
        behavior.Update();
    }

    //Slows lazer down
    public void Weaken()
    {
        behavior = new DynamicLazerCycledBehaviorWeakened(cycles, lazer);
        behavior.Activate();
    }
}
