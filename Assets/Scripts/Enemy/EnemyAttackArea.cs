using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    EnemyCat _enemyCat;

    private void Awake()
    {
        _enemyCat = GetComponentInParent<EnemyCat>();
    }

    private void OnTriggerStay2D(Collider2D Other)
    {
        var target = Other.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(_enemyCat.damage);
            Vector2 direction = (Other.transform.position - transform.position).normalized;
            target.Reboud(direction);

        }

    }
}
