using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model
{
    public abstract Model SetMaxLife(float maxLife);
    public abstract void TakeDamage(float dmg, List<IObserver> obs);
}
