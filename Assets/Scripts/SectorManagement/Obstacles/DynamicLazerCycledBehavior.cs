using System.Collections.Generic;
using UnityEngine;
using static DynamicLazerController;

public abstract class DynamicLazerCycledBehavior : DynamicLazerBehavior
{
    protected enum DynamicLazerState
    {
        Waiting,
        Caution,
        Danger,
        TurnedOff
    }

    private DynamicLazer lazer;
    private DynamicLazerState currentState;
    private float passedTimeOfCurrentState;

    protected List<DynamicLazerCycle> cycles;
    protected int currentCycleNumber;
    protected Dictionary<DynamicLazerState, float> stateDurations;

    public DynamicLazerCycledBehavior(List<DynamicLazerCycle> currentCycles, DynamicLazer currentLazer)
    {
        cycles = currentCycles;
        lazer = currentLazer;
    }

    public override void Activate()
    {
        stateDurations = new Dictionary<DynamicLazerState, float>();
        stateDurations.Add(DynamicLazerState.Waiting, 0);
        stateDurations.Add(DynamicLazerState.Caution, 0);
        stateDurations.Add(DynamicLazerState.Danger, 0);

        currentCycleNumber = -1;

        StartWaiting();
    }

    public override void Update()
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

    protected abstract void SetStateDurations();

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
