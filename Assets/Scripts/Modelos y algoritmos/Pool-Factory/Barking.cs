using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Barking : MonoBehaviour
{
    protected ObjectPool<Barking> _myPool;

    public void Initialize(ObjectPool<Barking> pool)
    {
        _myPool = pool;
    }

    public virtual void Refresh() { }
}
