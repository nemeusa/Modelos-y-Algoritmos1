using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
{
    public delegate T FactoryMethod();

    FactoryMethod _factory;
    Action<T> _TurnOff;
    Action<T> _TurnOn;
    List<T> _stockAvailables = new List<T>();

    public ObjectPool(FactoryMethod Factory, Action<T> TurnOff, Action<T> TurnOn, int initialStock = 10)
    {
        _factory = Factory;
        _TurnOff = TurnOff;
        _TurnOn = TurnOn;   

        for (int i = 0; i < initialStock; i++)
        {
            var f = _factory();
            _TurnOff(f);
            _stockAvailables.Add(f);
        }    
    }

    public T Get()
    {
        if(_stockAvailables.Count > 0)
        {
            var s = _stockAvailables[0];
            _stockAvailables.RemoveAt(0);

            _TurnOn(s);
            return s;
        }
        return _factory();
    }

    public void Release(T obj)
    {
        _TurnOff(obj);
        _stockAvailables.Add(obj);
    }
}
