using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private InputSystem _inputSystem;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        _inputSystem = new InputSystem();

    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    public Vector2 OnMove() => _inputSystem.Player.Move.ReadValue<Vector2>();

    public bool OnShoot() => _inputSystem.Player.Shoot.WasPerformedThisFrame();


}
