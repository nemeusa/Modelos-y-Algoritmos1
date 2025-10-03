using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface States
{
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();
}
