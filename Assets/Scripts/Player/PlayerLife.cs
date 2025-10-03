using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamageable
{
    [Header("Life")]
    [SerializeField] private float _maxLife;
    [SerializeField] private float _life;
    [SerializeField] LifeBar barLife;
    PlayerSoundEffects playerSFX;

    [Header("Hit")]
    private float _lastDamage;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _dontControlTime, _controlTimeInvincible;
    PlayerMovement _player;
    [SerializeField] Vector2 _reboundSpeed;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
        playerSFX = GetComponent<PlayerSoundEffects>();
        _life = _maxLife;
        barLife._BarLife(_life);
    }

    public void TakeDamage(float damage)
    {
        if (!_animator.GetBool("Hit"))
        {
            _life -= damage;
            barLife.actuallyLife(_life);
            Debug.Log("you are " + _life + " from life");
            Debug.Log("you get " + damage + " from damage");
            playerSFX.PlayDamageSound();



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

}
