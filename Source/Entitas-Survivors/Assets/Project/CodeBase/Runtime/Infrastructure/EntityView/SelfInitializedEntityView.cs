using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.EntityView
{
  public class SelfInitializedEntityView : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityBehaviour;

    private IIdentifierService _identifierService;

    [Inject]
    private void Construct(IIdentifierService identifierService) =>
      _identifierService = identifierService;

    private void Awake()
    {
      GameEntity entity = CreateEntity.Empty()
        .AddId(_identifierService.Next());

      _entityBehaviour.SetEntity(entity);
    }
  }
}