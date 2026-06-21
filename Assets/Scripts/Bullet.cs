using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private const float LifeTime = 3;
    
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private BulletCollision _bulletCollision;
    
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
        _bulletCollision.CollisionWithObject += Die;
        
        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
        }
        
        _rigidbody.velocity = transform.forward * _bulletSpeed;
        _lifeCoroutine  = StartCoroutine(LifeProcess());
    }

    private void OnDisable()
    {
        _bulletCollision.CollisionWithObject -= Die;
    }
    
    private IEnumerator LifeProcess()
    {
        yield return _wait;
        Die();
    }

    private void Die()
    {
        Destroyed?.Invoke(this);
    }
}