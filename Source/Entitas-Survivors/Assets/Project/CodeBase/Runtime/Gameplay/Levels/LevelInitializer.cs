using CodeBase.Runtime.Gameplay.Cameras.Provider;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Levels
{
  public class LevelInitializer : MonoBehaviour, IInitializable
  {
    [SerializeField] private Transform _startPoint;

    private ILevelDataProvider _levelDataProvider;

    [Inject]
    private void Construct(ILevelDataProvider levelDataProvider)
    {
      _levelDataProvider = levelDataProvider;
    }

    public void Initialize()
    {
      _levelDataProvider.SetStartPoint(_startPoint.position);
    }
  }
}