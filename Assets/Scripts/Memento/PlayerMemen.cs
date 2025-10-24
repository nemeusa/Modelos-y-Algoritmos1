using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMemen : MonoBehaviour, IRewind
{
    Rigidbody2D _rb;
    public float speed;
    private Vector2 _moveInput;

    public float life;
    public int gold;

    MementoState _mementoState;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mementoState = new MementoState();
    }
    private void Update()
    {
        Flip();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            life = Random.Range(0, 100);
            gold = Random.Range(0, 1000);
            Debug.Log("RANDOM");
        }
    }


    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveInput * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveInput = new Vector2(moveX, moveY).normalized;
    }


    public void Save()
    {
        Debug.Log("guardo datos player");
        _mementoState.Rec(transform.position, transform.rotation, life, gold);
    }

    public void Load()
    {
        if (!_mementoState.IsRemember()) return;
        Debug.Log("cargo datos player");

        var x = _mementoState.Remember();

        transform.position = (Vector3)x.parameters[0];
        transform.rotation = (Quaternion)x.parameters[1];
        life = (float)x.parameters[2];
        gold = (int)x.parameters[3];

    }

    public bool IsRemember()
    {
        return _mementoState.IsRemember();
    }
}
