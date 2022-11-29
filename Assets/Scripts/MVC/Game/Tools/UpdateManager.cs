using System;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager Instance { get; private set; }

    public Action OnUpdateEvent;
    public Action OnFixedUpdateEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void SunscribeToUpdate(Action action)=>
        OnUpdateEvent += action;
    public void SunscribeToFixedUpdate(Action action) =>
        OnFixedUpdateEvent += action;
    public void UnSunscribeToUpdate(Action action) =>
        OnUpdateEvent -= action;
    public void UnSunscribeToFixedUpdate(Action action) =>
        OnFixedUpdateEvent -= action;

    private void Update() { OnUpdateEvent?.Invoke(); }
    private void FixedUpdate() { OnFixedUpdateEvent?.Invoke(); }
}