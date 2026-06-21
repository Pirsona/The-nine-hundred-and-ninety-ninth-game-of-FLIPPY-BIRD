using System;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public event Action CollisionWithObject;
    
    private void OnTriggerEnter(Collider other)
    {
        CollisionWithObject?.Invoke();  
    }
}