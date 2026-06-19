using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private protected T _prefab;
    [SerializeField] private protected int _countPoolObject;
    [SerializeField] private protected int _maximumCountPoolObject;

    private ObjectPool<T> _pool;
    
    private void Awake()
    {
        _pool = new ObjectPool<T>(CreateObject, ActivateObject, DeactivateObject, DestroyObject, true, _countPoolObject, _maximumCountPoolObject);
    }

    private protected void ReturnObject(T obj)
    {
        _pool.Release(obj);
    }

    private T CreateObject()
    {
        T obj = Instantiate(_prefab);
        
        return obj;
    }

    private void ActivateObject(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void DeactivateObject(T obj)
    {
        
        obj.gameObject.SetActive(false);
    }

    private void DestroyObject(T obj)
    {
        Destroy(obj.gameObject);
    }

    private protected T GetObject()
    {
        T obj = _pool.Get();

        return obj;
    }
}