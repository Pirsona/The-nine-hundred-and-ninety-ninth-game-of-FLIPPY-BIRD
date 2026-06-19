using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private const float LifeTime = 3;
    
    [SerializeField] private float _bulletSpeed = 5f;
    
    private float _speed;
    private Coroutine  _lifeCoroutine;
    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    public event Action<Bullet> Destroyed;

    private void Awake()
    {
        _wait = new WaitForSeconds(LifeTime);
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
        }
        
        _rigidbody.velocity = transform.forward * _bulletSpeed;
        _lifeCoroutine  = StartCoroutine(LifeProcees());
    }


    private IEnumerator LifeProcees()
    {
        yield return _wait;
        Destroyed?.Invoke(this);
    }
}