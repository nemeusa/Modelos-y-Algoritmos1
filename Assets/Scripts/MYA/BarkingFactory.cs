

public class BarkingFactory : Factory<Barking>
{
    public override Barking Create()
    {
        var f = _pool.Get();
        f.Initialize(_pool);

        return f;
    }

    protected override Barking CreatePrefab()
    {
        var b = Instantiate(_prefab);
        return b;
    }

    protected override void TurnOff(Barking obj)
    {
        obj.Refresh();
        obj.gameObject.SetActive(false);
    }

    protected override void TurnOn(Barking obj)
    {
        obj.gameObject.SetActive(true);
    }
}
