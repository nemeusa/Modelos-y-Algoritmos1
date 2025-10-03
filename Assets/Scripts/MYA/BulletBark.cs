using UnityEngine;

public class BulletBark : Barking
{
    [SerializeField] float _duration;
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    [SerializeField] LayerMask _layerMask;

    float _counter;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _counter += Time.deltaTime;

        if (_counter >= _duration)
            _myPool.Release(this);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var target = other.GetComponent<IDamageable>();
        if (target != null && ((_layerMask.value & (1 << other.gameObject.layer)) != 0))
        {
            target.TakeDamage(_damage);
            Vector2 direction = (other.transform.position - transform.position).normalized;
            target.Reboud(direction);
            _myPool.Release(this);
        }
    }

    public override void Refresh()
    {
        _counter = 0;
    }
}

