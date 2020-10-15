using System;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLazerController : MonoBehaviour
{
    [Serializable]
    class DynamicLazerCycle
    {
        public float WaitingTime;
        public float CautionTime;
        public float DangerTime;
    }

    enum DynamicLazerState
    {
        Waiting,
        Caution,
        Danger,
        TurnedOff
    }

    [SerializeField]
    private List<DynamicLazerCycle> cycles;

    [SerializeField]
    private DynamicLazer lazer;

    private DynamicLazerState currentState;
    private int currentCycleNumber;
    private float passedTimeOfCurrentState;
    private Dictionary<DynamicLazerState, float> stateDurations;

    void Start()
    {
        stateDurations = new Dictionary<DynamicLazerState, float>();
        stateDurations.Add(DynamicLazerState.Waiting, 0);
        stateDurations.Add(DynamicLazerState.Caution, 0);
        stateDurations.Add(DynamicLazerState.Danger, 0);

        currentCycleNumber = -1;

        StartWaiting();
    }

    void Update()
    {
        if (currentState == DynamicLazerState.TurnedOff)
        {
            return;
        }

        passedTimeOfCurrentState += Time.deltaTime;

        if (passedTimeOfCurrentState >= stateDurations[currentState])
        {
            ChangeState();
        }
    }

    private void ChangeState()
    {
        passedTimeOfCurrentState = 0;

        if (currentState == DynamicLazerState.Waiting)
        {
            StartCaution();
            return;
        }

        if (currentState == DynamicLazerState.Caution)
        {
            StartDanger();
            return;
        }

        if (currentState == DynamicLazerState.Danger)
        {
            StartWaiting();
            return;
        }
    }

    private void SetNextCycle()
    {
        currentCycleNumber++;

        if (currentCycleNumber >= cycles.Count)
        {
            Stop();
            return;
        }

        SetStateDurations();
    }

    private void SetStateDurations()
    {
        DynamicLazerCycle currentCycle = cycles[currentCycleNumber];

        stateDurations[DynamicLazerState.Waiting] = currentCycle.WaitingTime;
        stateDurations[DynamicLazerState.Caution] = currentCycle.CautionTime;
        stateDurations[DynamicLazerState.Danger] = currentCycle.DangerTime;
    }

    private void StartWaiting()
    {
        currentState = DynamicLazerState.Waiting;
        lazer.gameObject.SetActive(false);

        SetNextCycle();
    }

    private void StartCaution()
    {
        currentState = DynamicLazerState.Caution;
        lazer.gameObject.SetActive(true);
        lazer.SetCautionMode();
        
    }

    private void StartDanger()
    {
        currentState = DynamicLazerState.Danger;
        lazer.gameObject.SetActive(true);
        lazer.SetDangerMode();
    }

    private void Stop()
    {
        currentState = DynamicLazerState.TurnedOff;
        lazer.gameObject.SetActive(false);
    }
}
