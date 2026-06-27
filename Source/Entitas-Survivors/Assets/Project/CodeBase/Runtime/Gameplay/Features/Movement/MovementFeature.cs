using CodeBase.Runtime.Gameplay.Features.Movement.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Movement
{
  public sealed class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<DirectionalDeltaMoveSystem>());

      Add(systemFactory.Create<OrbitalDeltaMoveSystem>());
      Add(systemFactory.Create<OrbitCenterFollowSystem>());

      Add(systemFactory.Create<TurnAlongDirectionSystem>());
      Add(systemFactory.Create<UpdateTransformPositionSystem>());
      Add(systemFactory.Create<RotateAlongDirectionSystem>());
    }
  }
}