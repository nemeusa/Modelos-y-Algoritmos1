using System.Collections;
using UnityEngine;

public class EnemyLife : MonoBehaviour, IDamageable
{
    [Header("Life")]
    [SerializeField] private float _life;
    [SerializeField] private LayerMask _wall;
    EnemyCat _enemy;

    [Header("Hit")]
    [SerializeField] private int _points = 20;
    [SerializeField] Vector2 ReboundSpeed;
    [SerializeField] private float _dontControlTime, _controlTimeInvincible;
    bool _hit;
    SpriteRenderer _spriteRenderer;
    Color _ogColor;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _enemy = FindObjectOfType<EnemyCat>();
        _ogColor = _spriteRenderer.color;
    }
    public void TakeDamage(float damage)
    {
        if (!_hit)
        {
            Debug.Log("enemigo golpeado");
            _life -= damage;

            if (_life <= 0)
            {
                Debug.Log("Enemigo Eliminado");
                PointsCounter.Instance.AddPoints(_points);
                Debug.Log("ganaste " + _points + " puntos");
                Destroy(this.gameObject);
            }
        }
    }

    public void Reboud(Vector2 HitPoint)
    {
        if (_life > 0)
        {
            if (_enemy.rb != null) _enemy.rb.velocity = new Vector2(ReboundSpeed.x * HitPoint.x, ReboundSpeed.y);
            StartCoroutine(ControlLose());
            StartCoroutine(Invincible());
        }
    }

    private IEnumerator Invincible()
    {
        _hit = true;
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(_controlTimeInvincible);
        _spriteRenderer.color = _ogColor;
        _hit = false;
    }
    private IEnumerator ControlLose()
    {
        _enemy.dontMove = true;
        yield return new WaitForSeconds(_dontControlTime);
        _enemy.dontMove = false;
    }
}
