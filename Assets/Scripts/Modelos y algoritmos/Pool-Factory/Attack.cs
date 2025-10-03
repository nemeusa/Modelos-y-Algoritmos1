using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] BarkingTypes[] _barkingTypes;
    Controller _controller;

    [SerializeField] private float _timeToAttack;
    [SerializeField] private float _timeAttack;
    [SerializeField] Animator _playerAnimator;

    PlayerSoundEffects playerSFX;

    private void Awake()
    {
        if (playerSFX == null) playerSFX = GetComponent<PlayerSoundEffects>();
        _controller = new Controller(_barkingTypes[0], _timeToAttack, _timeAttack, _playerAnimator, playerSFX);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _controller = new Controller(_barkingTypes[0], _timeToAttack, _timeAttack, _playerAnimator, playerSFX);

        else if (Input.GetKeyDown(KeyCode.E))
            _controller = new Controller(_barkingTypes[1], _timeToAttack, _timeAttack, _playerAnimator, playerSFX);


        _controller.ArtificialUpdate();
    }
}
