using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Factory
{
  public interface ILootFactory
  {
    GameEntity CreateLootItem(LootTypeId typeId, Vector3 at);
  }
}