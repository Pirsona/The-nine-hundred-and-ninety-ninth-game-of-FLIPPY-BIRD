using System;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    public event Action FatalCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet) || other.TryGetComponent(out Enemy enemy))
        {
            FatalCollision?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor))
        {
            FatalCollision?.Invoke();
        }
    }
}