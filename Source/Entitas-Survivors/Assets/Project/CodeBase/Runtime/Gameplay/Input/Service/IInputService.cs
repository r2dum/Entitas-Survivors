using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Input.Service
{
  public interface IInputService
  {
    float GetVerticalAxis();
    float GetHorizontalAxis();
    bool HasAxisInput();

    bool GetLeftMouseButton();
    bool GetLeftMouseButtonDown();
    Vector2 GetScreenMousePosition();
    Vector2 GetWorldMousePosition();
    bool GetLeftMouseButtonUp();
  }
}