using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] BarkingTypes _barkingTypes;
    Controller _controller;

    private void Awake()
    {
        _controller = new Controller(_barkingTypes);
    }
    void Update()
    {
        _controller.ArtificialUpdate();
    }
}
