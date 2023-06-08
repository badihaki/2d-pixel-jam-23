using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [field: SerializeField] public Player player { get; private set; }
    [field: SerializeField] public SwordStateLogic stateLogic { get; private set; }
    [field: SerializeField] public SwordMovement moveController { get; private set; }

    [field: SerializeField] public bool _IsEquipped { get; private set; }

    public enum SwordState
    {
        debug,
        idle,
        flyingDangerously,
        heldByPlayer
    }
    [field: SerializeField] public SwordState _State { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        stateLogic = GetComponent<SwordStateLogic>();
        moveController = GetComponent<SwordMovement>();

        _State = SwordState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_State)
        {
            case SwordState.idle:
                stateLogic.IdleState();
                break;
            case SwordState.flyingDangerously:
                stateLogic.FlyingState();
                break;
            case SwordState.heldByPlayer:
                stateLogic.HeldState();
                break;
        }
    }

    public void ChangeSwordState(SwordState newState)
    {
        _State = newState;
    }
}
