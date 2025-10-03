using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour, IObserver
{
    private Slider slider;
    [SerializeField] PlayerLife _player;
    IObservable _obs;

    void Awake()
    {
        slider = GetComponent<Slider>();

        _obs = _player.GetComponent<IObservable>();

        if (_obs == null)
        {
            gameObject.SetActive(false);
            return;
        }

        _obs.Subscribe(this);
    }

    public void UpdateLife(float life, float maxLife)
    {
        slider.maxValue = maxLife;
        slider.value = life;
    }

    private void OnDestroy()
    {
        if (_obs != null)
            _obs.Unsubscribe(this);
    }
}
