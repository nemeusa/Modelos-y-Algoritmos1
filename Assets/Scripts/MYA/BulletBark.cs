using UnityEngine;

public class BulletBark : Barking
{
    [SerializeField] float _duration;
    [SerializeField] float _speed;
    [SerializeField] Transform _firePoint;

    Rigidbody2D _rb;

    float _counter;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _counter += Time.deltaTime;

        if (_counter >= _duration)
            _myPool.Release(this);
    }

    public override void Refresh()
    {
        _counter = 0;
    }
}

