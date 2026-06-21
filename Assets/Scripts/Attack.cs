using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float cooldown;
    
    private bool _isReady = true;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _isReady = true;
    }

    public void Shoot()
    {
        if (!_isReady) return;
        
        _isReady = false;
        _bulletSpawner.SpawnBullet(_shootPoint);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        StartCoroutine(CoolDown());
    }
    
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        _isReady = true;
    }
}