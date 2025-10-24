using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoState : MonoBehaviour
{
    List<ParamsMemento> _data = new List<ParamsMemento>();

    public void Rec(params object[] p)
    {
        if (_data.Count > 10000)
            _data.RemoveAt(30);

        _data.Add(new ParamsMemento(p));
    }

    public bool IsRemember()
    {
        return _data.Count > 0;
    }

    public ParamsMemento Remember()
    {
        var x = _data[_data.Count - 1];
        _data.Remove(x);

        return x;
    }
}
