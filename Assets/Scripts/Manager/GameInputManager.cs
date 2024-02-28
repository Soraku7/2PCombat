using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class GameInputManager : Singleton<GameInputManager>
{
    private Player1 _inputActions;

    protected override void Awake()
    {
        base.Awake();
        _inputActions ??= new Player1();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();
    public bool Foot => _inputActions.Player.Foot.triggered;
    public bool Head => _inputActions.Player.Head.triggered;
    public bool Torso => _inputActions.Player.Torso.triggered;
}