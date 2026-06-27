using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Cameras.Holder
{
  public class CamerasHolder : MonoBehaviour
  {
    [SerializeField] private Camera _mainCamera;

    public Camera MainCamera => _mainCamera;
  }
}