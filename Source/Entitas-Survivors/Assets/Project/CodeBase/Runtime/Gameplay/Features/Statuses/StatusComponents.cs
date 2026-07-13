using CodeBase.Runtime.Gameplay.Core.Visuals.Appearance;
using CodeBase.Runtime.Gameplay.Core.Visuals.Status;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace CodeBase.Runtime.Gameplay.Features.Statuses
{
  [Game] public class Status : IComponent { }
  [Game] public class StatusTypeIdComponent : IComponent { public StatusTypeId Value; }
  [Game] public class StatusVisualsComponent : IComponent { public IStatusVisuals Value; }
  [Game] public class AppearanceVisualsComponent : IComponent { public IAppearanceVisuals Value; }
  [Game] public class AppearanceSkinComponent : IComponent { public AppearanceSkin Value; }
  
  [Game] public class Duration : IComponent { public float Value; }
  [Game] public class TimeLeft : IComponent { public float Value; }
  [Game] public class Period : IComponent { public float Value; }
  
  [Game] public class TimeSinceLastTick : IComponent { public float Value; }
  [Game] public class ApplierStatusLink : IComponent { [EntityIndex] public int Value; }
  
  [Game] public class Applied : IComponent { }
  [Game] public class Affected : IComponent { }
  [Game] public class Unapplied : IComponent { }
  
  [Game] public class Poison : IComponent { }
  [Game] public class Freeze : IComponent { }
  [Game] public class Heal : IComponent { }
  [Game] public class SpeedModifier : IComponent { }
  [Game] public class SheepHex : IComponent { }
}