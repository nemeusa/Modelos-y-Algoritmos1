using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomNodes : MonoBehaviour
{
    public List<CustomNodes> neighbours = new List<CustomNodes>();
    int _x, _y;
    Grid _grid;
    public bool Block;
    public int Cost;

   // [SerializeField] TMP_Text _text;
    public void Initialize(Grid grid, int x, int y)
    {
        _grid = grid;
        _x = x;
        _y = y;
        ModifyCost(1);
    }

    private void Update()
    {
    //    _text.text = Cost.ToString();

    }

    void ModifyCost(int newCost)
    {
        Cost = Mathf.Clamp(newCost, 1, 50);

  //      _text.text = Cost.ToString();
    }

    public List<CustomNodes> Neighbours
    {
        get
        {
            if (neighbours.Count > 0)
                return neighbours;

            var right = _grid.GetNode(_x + 1, _y);
            if (right != null)
                neighbours.Add(right);


            var left = _grid.GetNode(_x - 1, _y);
            if (left != null)
                neighbours.Add(left);


            var up = _grid.GetNode(_x, 1 + _y);
            if (up != null)
                neighbours.Add(up);


            var down = _grid.GetNode(_x, _y - 1);
            if (down != null)
                neighbours.Add(down);



            return neighbours;
        }
    }
}
