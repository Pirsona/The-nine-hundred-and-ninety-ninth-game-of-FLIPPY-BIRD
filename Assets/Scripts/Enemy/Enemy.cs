using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float LifeTime = 10;
    private const float StandartWaitTime = 1;
    
    [SerializeField] private Attack _attack;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    
    public event Action<Enemy> Destroyed;

    private void Awake()
    {
        _wait = new WaitForSeconds(StandartWaitTime);
    }

    private void OnEnable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine =  StartCoroutine(LifeProcess());
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
        
        Destroyed?.Invoke(this);
    }
}