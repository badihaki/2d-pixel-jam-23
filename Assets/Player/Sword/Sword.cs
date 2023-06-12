using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [field: SerializeField] public Player _Player { get; private set; }
    [field: SerializeField] public SwordStateLogic _StateLogic { get; private set; }
    [field: SerializeField] public SwordMovement _MoveController { get; private set; }

    [field: SerializeField] public bool _IsEquipped { get; private set; }
    private Transform body;

    public float _DistanceToPlayer;

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
        _Player = GameObject.Find("Player").GetComponent<Player>();
        _StateLogic = GetComponent<SwordStateLogic>();
        _StateLogic.InitializeState(_Player, this);
        _MoveController = GetComponent<SwordMovement>();
        _MoveController.InitializeSword(this);
        body = transform.Find("Body").transform;

        _State = SwordState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_State)
        {
            case SwordState.idle:
                _StateLogic.IdleState();
                break;
            case SwordState.flyingDangerously:
                _StateLogic.FlyingState();
                break;
            case SwordState.heldByPlayer:
                _StateLogic.HeldState();
                break;
        }
    }

    public void ChangeSwordState(SwordState newState)
    {
        _State = newState;
    }

    public void TurnOnOffBody()
    {
        if (body.gameObject.activeSelf == true) body.gameObject.SetActive(false);
        else body.gameObject.SetActive(true);
    }
}
