using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyDash : MonoBehaviour
{
    enum EnemyState
    {
        Move,
        Follow,
        Dash,
    }
    EnemyState state = EnemyState.Move;

    public Transform Player;

    [Header("Movement variables-----------------------")]

    public float walkSpeed = 4;

    [Header("Dash variables---------------------------")]

    public float dashDistance = 6;
    public float dashDuration = .20f;
    private float dashTimer;
    private Vector3 dashDirection;

    
    void Start()
    {
        
    }

    void Update()
    {
        switch (state)
        {
            //case PlayerState.Idle: TickIdle(); break;

            case EnemyState.Move:
                TickMove();
                break;

            case EnemyState.Follow:
                TickFollow();
                break;

            case EnemyState.Dash:
                TickDash();
                break;
        }
    }

    void TickMove()
    {

    }
    void TickFollow()
    {

    }
    void TickDash()
    {

    }

    IEnumerator CheckPlayerDistance()
    {
        return null;
    }
}
