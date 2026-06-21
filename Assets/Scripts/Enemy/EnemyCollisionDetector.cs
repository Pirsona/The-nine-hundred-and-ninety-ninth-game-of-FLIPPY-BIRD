using System;
using UnityEngine;

public class EnemyCollisionDetector : MonoBehaviour
{
    public event Action FatalCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            FatalCollision?.Invoke();
        }
    }
}
