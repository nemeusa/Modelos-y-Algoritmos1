using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCat : MonoBehaviour
{
    public FSM<TypeFSM> fsm;

    [Header("Move")]
    public float speed = 3f;
    public List<CustomNodes> patrolPoints;
    public bool dontMove;
    public float _waitToNextPoint;
    bool _IsFacingRight = true;

    [Header("References")]
    public PathManager gameManager;
    public FOV fov;
    public Transform characterTarget;


    [Header("Attack")]
    public float minFollowDistancePlayer;
    public float attackTime;
    public float damage = 5;
    public float minAttackDistancePlayer;
    public GameObject attackArea;
    public Animator attackAni;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public int patrolIndex = 0;
    [HideInInspector] public Coroutine pathRoutine;
    [HideInInspector] public Vector3 lastKnownPosition;
    [HideInInspector] public CustomNodes lastKnownNode;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fsm = new FSM<TypeFSM>();
        fsm.AddState(TypeFSM.Walk, new WalkState(fsm, this));
        fsm.AddState(TypeFSM.Pursuit, new PursuitState(fsm, this));
        fsm.AddState(TypeFSM.Attack, new AttackState(fsm, this));
        fsm.AddState(TypeFSM.Death, new DeathState(fsm, this));
        fsm.AddState(TypeFSM.Returning, new ReturnWalkState(fsm, this));

        fsm.ChangeState(TypeFSM.Walk);
    }

    void Update()
    {
        if (characterTarget == null) return;
        fsm.Execute();
    }

    public void FollowTarget(Transform target)
    {
        if (dontMove) return;
        Vector2 dir = target.transform.position - transform.position;

        dir.Normalize();

        Vector3 movement = new Vector3(dir.x, dir.y, 0f) * speed * Time.deltaTime;
        transform.position += movement;

        Flip(target);
    }

    public void Flip(Transform target)
    {
        Vector2 dir = target.position - transform.position;

        bool IsTargetRight = transform.position.x < target.transform.position.x;

        if ((_IsFacingRight && !IsTargetRight) || (!_IsFacingRight && IsTargetRight))
        {
            _IsFacingRight = IsTargetRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            fov.IsFacingRight = _IsFacingRight;
        }
    }

    public bool Mindistance(Transform target,float minDistance) => Vector2.Distance(transform.position,
            target.position) < minDistance;

    public CustomNodes FindClosestNode()
    {
        CustomNodes closest = null;
        float minDist = Mathf.Infinity;
        foreach (var node in gameManager.pathfinding.GetAllNodes())
        {
            float dist = Vector3.Distance(transform.position, node.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = node;
            }
        }
        return closest;
    }

}

public enum TypeFSM
{
    Walk,
    Pursuit,
    Attack,
    Returning,
    Death
}
