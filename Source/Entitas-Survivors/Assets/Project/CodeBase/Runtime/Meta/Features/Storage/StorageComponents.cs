using Entitas;

namespace CodeBase.Runtime.Meta.Features.Storage
{
  [Meta] public class Storage : IComponent { }
  [Meta] public class Gold : IComponent { public float Value; }
  [Meta] public class GoldPerSecond : IComponent { public float Value; }
}