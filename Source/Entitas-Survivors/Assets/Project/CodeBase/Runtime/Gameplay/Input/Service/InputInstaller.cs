using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Input.Service
{
  public class InputInstaller : MonoInstaller
  {
    [SerializeField] private InputActionAsset _inputActionAsset;

    public override void InstallBindings()
    {
      Container.Bind<InputActionAsset>().FromInstance(_inputActionAsset).AsSingle();
      Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
    }
  }
}