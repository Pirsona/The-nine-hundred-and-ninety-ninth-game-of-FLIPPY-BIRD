using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _cooldown;
    
    private WaitForSeconds _wait;
    private bool _isSpawn = true;
    private void Start()
    {
        _wait = new WaitForSeconds(_cooldown);
        
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isSpawn)
        {
            yield return _wait;
            Enemy spawnedEnemy = GetObject();
            spawnedEnemy.transform.position = GetRandomPosition();
            spawnedEnemy.Destroyed += ReturnEnemy;
            
        }
    }
    
    private Vector3 GetRandomPosition()
    {
        Vector3 center = transform.position;
        Vector3 extents = transform.localScale / 2f;

        float xPosition = UnityEngine.Random.Range(center.x - extents.x, center.x + extents.x);
        float yPosition = UnityEngine.Random.Range(center.y - extents.y, center.y + extents.y);
            
        Vector3 positionCube = new Vector3(xPosition, yPosition, center.z);

        return positionCube;
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemy.Destroyed -= ReturnEnemy;

        ReturnObject(enemy);
    }
    
}
