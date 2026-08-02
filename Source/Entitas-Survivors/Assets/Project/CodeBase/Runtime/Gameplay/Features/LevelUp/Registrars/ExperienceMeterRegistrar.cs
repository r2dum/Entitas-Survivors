using CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours;
using CodeBase.Runtime.Infrastructure.EntityView.Registrars;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Registrars
{
  public class ExperienceMeterRegistrar : EntityComponentRegistrar
  {
    [SerializeField] private ExperienceMeter _experienceMeter;

    public override void RegisterComponents() =>
      Entity.AddExperienceMeter(_experienceMeter);

    public override void UnregisterComponents()
    {
      if (Entity.hasExperienceMeter)
        Entity.RemoveExperienceMeter();
    }
  }
}