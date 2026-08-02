using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Common.Extensions;
using CodeBase.Runtime.Gameplay.Features.Loot.Configs;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Infrastructure.Identifiers;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Factory
{
  public class LootFactory : ILootFactory
  {
    private readonly IGameplayStaticDataService _staticDataService;
    private readonly IIdentifierService _identifierService;

    public LootFactory(IGameplayStaticDataService staticDataService, IIdentifierService identifierService)
    {
      _staticDataService = staticDataService;
      _identifierService = identifierService;
    }

    public GameEntity CreateLootItem(LootTypeId typeId, Vector3 at)
    {
      LootConfig lootConfig = _staticDataService.GetLootConfig(typeId);

      return CreateEntity.Empty()
        .AddId(_identifierService.Next())
        .AddWorldPosition(at)
        .AddLootTypeId(typeId)
        .AddViewPrefab(lootConfig.ViewPrefab)
        .With(x => x.AddExperience(lootConfig.Experience), when: lootConfig.Experience > 0)
        .With(x => x.AddEffectSetups(lootConfig.EffectSetups), when: lootConfig.EffectSetups.IsNullOrEmpty() == false)
        .With(x => x.AddStatusSetups(lootConfig.StatusSetups), when: lootConfig.StatusSetups.IsNullOrEmpty() == false)
        .With(x => x.isPullable = true);
    }
  }
}