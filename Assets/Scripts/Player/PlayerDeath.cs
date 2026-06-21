using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private PlayerCollisionDetector  _detector;
    
    public event Action Died;
    
    public bool IsDead {get; private set;}
    
    private void OnEnable()
    {
        _detector.FatalCollision += Death;
    }

    private void OnDisable()
    {
        _detector.FatalCollision -= Death;
    }

    private void Awake()
    {
        IsDead = false;
    }
    
    private void Death()
    {
        IsDead = true;
        Died?.Invoke();
    }
    
    public void Revive()
    {
        IsDead = false;
    }
}