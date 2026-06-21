using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    public void SpawnBullet(Transform pointSpawn)
    {
        Bullet bullet =  GetObject();
        bullet.Destroyed += ReturnBullet;
        
        bullet.transform.position = pointSpawn.position;
        bullet.transform.rotation = pointSpawn.rotation;
    }
    
    public void ReturnBullet(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBullet;
        
        ReturnObject(bullet);
    }
}