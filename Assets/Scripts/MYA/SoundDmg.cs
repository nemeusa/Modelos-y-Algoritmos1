using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDmg : MonoBehaviour, IObserver
{
    PlayerSoundEffects playerSFX;

    void Awake()
    {
        playerSFX = GetComponentInParent<PlayerSoundEffects>();

        IObservable obs = GetComponentInParent<IObservable>();

        if (obs == null)
        {
            gameObject.SetActive(false);
            return;
        }

        obs.Subscribe(this);
    }

    public void UpdateLife(float life, float maxLife)
    {
        playerSFX.PlayDamageSound();
    }
}
