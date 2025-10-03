using System;
using UnityEngine;
using System.Collections.Generic;

public class CharacterModel : Model
{
    float _maxLife;
    float _life;

    public event Action DmgEvent;

    public CharacterModel()
    {
        _maxLife = 100;
        _life = _maxLife;
    }

    public override Model SetMaxLife(float maxLife)
    {
        _maxLife = maxLife;
        _life = _maxLife; 
        return this;
    }


    public override void TakeDamage(float dmg, List<IObserver> obs)
    {
        _life -= dmg;
        DmgEvent?.Invoke();

        foreach (var ob in obs)
            ob.UpdateLife(_life, _maxLife);

        Debug.Log("you are " + _life + " from life");
        Debug.Log("you get " + dmg + " from damage");

        if (_life <= 0 )
        {
            Debug.Log("Moriste :(");
            GameManager.instance.DefeatedMenu();
        }
    }
}
