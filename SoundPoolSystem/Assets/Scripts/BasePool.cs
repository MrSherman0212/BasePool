using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

[RequireComponent(typeof(KeepBetweenScenes))]
public abstract class BasePool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField, Range(1, 10000)] private int _poolObjCount = 5, _poolObjMaxCount = 10;
    protected ObjectPool<T> _pool;
    private List<T> _tHolder;

    private void Awake()
    {
        _pool = new ObjectPool<T>(CreatePoolObj, GetPoolObj, ReleasePoolObj, DestroyPoolObj, true, _poolObjCount, _poolObjMaxCount);
        SpawnPoolObjects();
    }

    protected virtual void SpawnPoolObjects()
    {
        _tHolder = new List<T>();
        for (int i = 0; i < _poolObjCount; i++)
            _tHolder.Add(_pool.Get());
        foreach (T t in _tHolder)
            _pool.Release(t);
    }

    // --- Pool
    protected abstract T CreatePoolObj();

    protected virtual void GetPoolObj(T poolObject) => poolObject.gameObject.SetActive(true);

    protected virtual void ReleasePoolObj(T poolObject) => poolObject.gameObject.SetActive(false);

    protected virtual void DestroyPoolObj(T poolObject) => Destroy(poolObject.gameObject);
    // --- Pool
}
