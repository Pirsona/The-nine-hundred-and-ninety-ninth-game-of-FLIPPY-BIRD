using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerCollisionDetector  _detector;
    
    public event Action Daying;
    
    public bool IsDead {get; private set;}
    
    private void OnEnable()
    {
        _detector.OnFatalCollision += Death;
    }

    private void OnDisable()
    {
        _detector.OnFatalCollision -= Death;
    }

    private void Awake()
    {
        IsDead = false;
    }
    
    private void Death()
    {
        IsDead = true;
        Daying?.Invoke();
    }
    
    public void Revive()
    {
        IsDead = false;
    }
}
