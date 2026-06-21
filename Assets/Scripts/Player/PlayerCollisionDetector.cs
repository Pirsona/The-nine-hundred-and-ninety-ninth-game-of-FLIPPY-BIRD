using System;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    public event Action OnFatalCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet) || other.TryGetComponent(out Enemy enemy))
        {
            OnFatalCollision?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor))
        {
            OnFatalCollision?.Invoke();
        }
    }
}