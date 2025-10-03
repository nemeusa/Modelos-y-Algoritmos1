using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] LayerMask _layerMask;

    private void OnTriggerStay2D (Collider2D other)
    {
        var target = other.GetComponent<IDamageable>();
        var house = other.GetComponent<MiaiusHouse>();

        if (target != null && ((_layerMask.value & (1 << other.gameObject.layer)) != 0))
        {
            Debug.Log("Colisiona");
            target.TakeDamage(_damage);
            Vector2 direction = (other.transform.position - transform.position).normalized;
            target.Reboud(direction);
        }

        if (((_layerMask.value & (1 << other.gameObject.layer)) != 0) && house != null) house.Die();
    }
}
