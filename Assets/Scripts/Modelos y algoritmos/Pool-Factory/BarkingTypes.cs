using UnityEngine;

public abstract class BarkingTypes : MonoBehaviour
{
    [SerializeField] protected Factory<Barking> _factory;

    public abstract void Bark();
}
