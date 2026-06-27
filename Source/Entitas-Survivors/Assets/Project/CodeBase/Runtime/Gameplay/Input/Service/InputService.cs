using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Input.Service
{
  public class InputService : IInputService, IInitializable, IDisposable
  {
    private const string PlayerActionMap = "Player";
    private const string AttackAction = "Attack";
    private const string MoveAction = "Move";

    private readonly InputActionAsset _inputActionAsset;

    private InputActionMap _playerInputActionMap;
    private InputAction _attackAction;
    private InputAction _moveAction;

    private Camera _mainCamera;

    private Camera CameraMain => _mainCamera ??= Camera.main;

    public InputService(InputActionAsset inputActionAsset) =>
      _inputActionAsset = inputActionAsset;

    public void Initialize()
    {
      _inputActionAsset.Enable();
      _playerInputActionMap = _inputActionAsset.FindActionMap(PlayerActionMap);
      _attackAction = _playerInputActionMap.FindAction(AttackAction);
      _moveAction = _playerInputActionMap.FindAction(MoveAction);
    }

    public void Dispose() =>
      _inputActionAsset.Disable();

    public Vector2 GetScreenMousePosition() =>
      CameraMain && Mouse.current != null ? Mouse.current.position.ReadValue() : Vector2.zero;

    public Vector2 GetWorldMousePosition()
    {
      if (CameraMain == null || Mouse.current == null)
        return Vector2.zero;
      return CameraMain.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    public bool HasAxisInput() =>
      _moveAction.ReadValue<Vector2>().sqrMagnitude > 0;

    public float GetVerticalAxis() =>
      _moveAction.ReadValue<Vector2>().y;

    public float GetHorizontalAxis() =>
      _moveAction.ReadValue<Vector2>().x;

    public bool GetLeftMouseButton() =>
      _attackAction.IsPressed() && IsPointerOverGameObject() == false;

    public bool GetLeftMouseButtonDown() =>
      _attackAction.WasPressedThisFrame() && IsPointerOverGameObject() == false;

    public bool GetLeftMouseButtonUp() =>
      _attackAction.WasReleasedThisFrame() && IsPointerOverGameObject() == false;

    private bool IsPointerOverGameObject() =>
      EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
  }
}