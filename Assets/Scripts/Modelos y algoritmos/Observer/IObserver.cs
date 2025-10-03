using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
   void UpdateLife(float actuallyLife, float maxLife);
}
