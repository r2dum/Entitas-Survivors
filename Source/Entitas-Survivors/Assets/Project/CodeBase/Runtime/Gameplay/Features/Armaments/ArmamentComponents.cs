using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Armaments
{
  [Game] public class Armament : IComponent { }
  [Game] public class TargetLimit : IComponent { public int Value; }
  [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
  [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value; }
  [Game] public class Processed : IComponent { }
  [Game] public class FollowingProducer : IComponent { }
}