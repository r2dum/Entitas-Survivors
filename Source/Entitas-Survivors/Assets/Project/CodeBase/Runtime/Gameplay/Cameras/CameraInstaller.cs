using CodeBase.Runtime.Gameplay.Cameras.Holder;
using CodeBase.Runtime.Gameplay.Cameras.Provider;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Cameras
{
  public class CameraInstaller : MonoInstaller
  {
    [SerializeField] private CamerasHolder _camerasHolder;

    public override void InstallBindings()
    {
      Container.Bind<CamerasHolder>().FromInstance(_camerasHolder).AsSingle();
      Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
    }
  }
}