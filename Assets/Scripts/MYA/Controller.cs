using UnityEngine;

public class Controller
{
    BarkingTypes _barkingTypes;
    
    public Controller(BarkingTypes barkingTypes)
    {
        _barkingTypes = barkingTypes;
    }

    public void ArtificialUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _barkingTypes.Bark();
        }
    }
}
