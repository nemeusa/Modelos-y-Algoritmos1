using UnityEngine;

public class Controller
{
    BarkingTypes _barkingTypes;
    float _timeToAttack;
    float _timeAttack;
    Animator _playerAnimator;
    PlayerSoundEffects _playerSFX;
    private float _timer = 0f;
    private float _time1;
    bool _isAttacking = false;

    public Controller(BarkingTypes barkingTypes, float timeToAttack, float timeAttack, Animator playerAnimator, PlayerSoundEffects playerSFX)
    {
        _barkingTypes = barkingTypes;
        _timeToAttack = timeToAttack;
        _timeAttack = timeAttack;
        _playerAnimator = playerAnimator;
        _playerSFX = playerSFX;
    }

    public void ArtificialUpdate()
    {
        _time1 += Time.deltaTime;

      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_time1 >= _timeAttack)
            {
                Attacking();
            }
        }

        if (_isAttacking)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToAttack)
            {
                ResetAttack();
            }
        }
    }


    private void Attacking()
    {
        _barkingTypes.Bark();
        _playerAnimator.SetBool("Attack", true);
        _playerSFX.PlayPunchSound();
        _isAttacking = true;
        _time1 = 0;
    }

    private void ResetAttack()
    {
        _timer = 0;
        _isAttacking = false;
        _playerAnimator.SetBool("Attack", false);
    }
}
