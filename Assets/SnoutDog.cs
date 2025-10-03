using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnoutDog : BarkingTypes
{
    public override void Bark()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, GameManager.instance.player.facingRight ? 0 : 180);
        var b = _factory.Create();
        b.transform.position = transform.position;
        b.transform.rotation = transform.rotation;
    }
}
