using CodeBase.Runtime.Infrastructure.EntityView.Registrars;

namespace CodeBase.Runtime.Gameplay.Core.Registrars
{
  public class TransformRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity.AddTransform(transform);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasTransform)
        Entity.RemoveTransform();
    }
  }
}