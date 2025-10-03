using UnityEngine;

public class DobleSnout : BarkingTypes
{
    [SerializeField] Transform[] _firePoints;

    public override void Bark()
    {
        foreach (var point in _firePoints)
        {
            var b = _factory.Create();
            b.transform.position = point.position;
            b.transform.rotation = point.rotation;
        }
    }
}