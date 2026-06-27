using CodeBase.Runtime.Infrastructure.EntityView.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Infrastructure.EntityView
{
  public sealed class BindViewFeature : Feature
  {
    public BindViewFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<LoadEntityViewFromAddressSystem>());
      Add(systemFactory.Create<BindEntityViewPrefabSystem>());
    }
  }
}