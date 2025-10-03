using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float dmg);
    void Reboud(Vector2 position);

}
