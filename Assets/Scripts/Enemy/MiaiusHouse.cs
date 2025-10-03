using UnityEngine;

public class MiaiusHouse : MonoBehaviour
{
    [SerializeField] int _points;

    public void Die()
    {
        PointsCounter.Instance.AddPoints(_points);
        Destroy(gameObject);
    }
}
