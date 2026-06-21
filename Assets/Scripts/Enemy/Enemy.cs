using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float LifeTime = 10;
    private const float StandardTime = 1;
    
    [SerializeField] private EnemyCollisionDetector  _collisionDetector;
    [SerializeField] private Attack _attack;
    [SerializeField] private int _scoreValue;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    
    public event Action<Enemy, int> Destroyed;
    
    private void Awake()
    {
        _wait = new WaitForSeconds(StandardTime);
    }

    private void OnEnable()
    {
        _collisionDetector.FatalCollision += Death;
        
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine =  StartCoroutine(LifeProcess());
    }

    private void OnDisable()
    {
        _collisionDetector.FatalCollision -= Death;
    }

    private IEnumerator LifeProcess()
    {
        float currentTime = LifeTime;

        yield return _wait;
        
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            
            _attack.Shoot();
            
            yield return null;
        }
        
        Destroyed?.Invoke(this, 0);
    }

    private void Death()
    {
        StopCoroutine(_coroutine);
        Destroyed?.Invoke(this, _scoreValue);
    }
}