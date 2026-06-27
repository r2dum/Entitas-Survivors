using CodeBase.Runtime.Infrastructure.EntityView;
using Entitas;

namespace CodeBase.Runtime.Common
{
  [Game] public class Destructed : IComponent { }
  [Game] public class ViewAddressLoading : IComponent { }
  
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class ViewAddress : IComponent { public string Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
  [Game] public class Radius : IComponent { public float Value; }
}