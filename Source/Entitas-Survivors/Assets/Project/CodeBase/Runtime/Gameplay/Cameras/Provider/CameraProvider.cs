using CodeBase.Runtime.Gameplay.Cameras.Holder;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Cameras.Provider
{
  public class CameraProvider : ICameraProvider, IInitializable
  {
    private readonly CamerasHolder _camerasHolder;

    public Camera MainCamera => _camerasHolder.MainCamera;

    public float WorldScreenHeight { get; private set; }
    public float WorldScreenWidth { get; private set; }

    public CameraProvider(CamerasHolder camerasHolder) =>
      _camerasHolder = camerasHolder;

    public void Initialize() =>
      RefreshBoundaries();

    private void RefreshBoundaries()
    {
      Vector2 bottomLeft = MainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, MainCamera.nearClipPlane));
      Vector2 topRight = MainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, MainCamera.nearClipPlane));
      WorldScreenWidth = topRight.x - bottomLeft.x;
      WorldScreenHeight = topRight.y - bottomLeft.y;
    }
  }
}