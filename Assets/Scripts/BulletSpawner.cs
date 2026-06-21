using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    public void SpawnBullet(Transform pointSpawn)
    {
        Bullet bullet =  GetObject();
        bullet.Destroyed += ReturnBulelt;
        
        bullet.transform.position = pointSpawn.position;
        bullet.transform.rotation = pointSpawn.rotation;
    }
    
    public void ReturnBulelt(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBulelt;
        
        ReturnObject(bullet);
    }
}
