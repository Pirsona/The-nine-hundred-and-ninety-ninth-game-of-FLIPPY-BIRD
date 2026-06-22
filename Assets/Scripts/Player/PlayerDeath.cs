using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public event Action Died;
    
    [SerializeField] private PlayerCollisionDetector  _detector;
    
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
}