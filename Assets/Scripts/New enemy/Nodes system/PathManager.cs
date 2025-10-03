using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager instance;

    public Pathfinding pathfinding;
    public CustomNodes start, end;
    public PlayerMovement player;
    public LayerMask layerMask;


    public List<EnemyCat> allEnemies;
    private void Awake()
    {
        allEnemies = new List<EnemyCat>(FindObjectsOfType<EnemyCat>());
        instance = this;
    }

    public void SetStartNode(CustomNodes node)
    {
        if (start != null)
            start.GetComponent<MeshRenderer>().material.color = Color.white;

        start = node;
        start.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void SetGoalNode(CustomNodes node)
    {
        if (end != null)
            end.GetComponent<MeshRenderer>().material.color = Color.white;


        end = node;
        start.GetComponent<MeshRenderer>().material.color = Color.green;
    }


    public bool InLineOfSight(Vector3 start, Vector3 end)
    {
        var dir = end - start;
        return !Physics.Raycast(start, dir, dir.magnitude, layerMask);
    }

    public void AlertNearbyEnemies(CustomNodes lastKnownNode)
    {
        foreach (var enemy in allEnemies)
        {
            if (enemy.fsm.CurrentStateKey != TypeFSM.Pursuit)
            {
                enemy.lastKnownNode = lastKnownNode;
               // enemy._fsm.ChangeState(TypeFSM.Searching);
            }
        }
    }
}
