using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamageable, IObservable
{
    [Header("Life")]
    [SerializeField] private float _maxLife;
    [SerializeField] private float _life;


    [Header("Hit")]
    private float _lastDamage;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _dontControlTime, _controlTimeInvincible;
    PlayerMovement _player;
    [SerializeField] Vector2 _reboundSpeed;

    List<IObserver> _observers = new List<IObserver>();

    private void Awake()
    {
        _player = GetComponent<PlayerMovement>();
        _life = _maxLife;
    }

    public void TakeDamage(float damage)
    {
        if (!_animator.GetBool("Hit"))
        {
            _life -= damage;
            Debug.Log("you are " + _life + " from life");
            Debug.Log("you get " + damage + " from damage");
            foreach (var ob in _observers)
                ob.UpdateLife(_life, _maxLife);


            if (_life <= 0)
            {
                Debug.Log("Moriste :(");
                Destroy(this.gameObject);
                GameManager.instance.DefeatedMenu();
            }
        }
    }

    public void Reboud(Vector2 HitPoint)
    {
        if (_life > 0)
        {
            _player.rb.velocity = new Vector2(_reboundSpeed.x * HitPoint.x, _reboundSpeed.y);
            StartCoroutine(ControlLose());
            StartCoroutine(Invincible());
        }
    }

    private IEnumerator Invincible()
    {
        _animator.SetBool("Hit", true);
        yield return new WaitForSeconds(_controlTimeInvincible);
        _animator.SetBool("Hit", false);
    }
    private IEnumerator ControlLose()
    {
        _player.dontMove = true;
        yield return new WaitForSeconds(_dontControlTime);
        _player.dontMove = false;
    }

    public void Subscribe(IObserver obs)
    {
        if (!_observers.Contains(obs))
            _observers.Add(obs); 
    } 
    public void Unsubscribe(IObserver obs)
    {
        if (_observers.Contains(obs))
            _observers.Remove(obs);
    }
}
