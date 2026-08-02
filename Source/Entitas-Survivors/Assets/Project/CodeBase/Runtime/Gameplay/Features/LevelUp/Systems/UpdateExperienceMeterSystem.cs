using CodeBase.Runtime.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Systems
{
  public class UpdateExperienceMeterSystem : IExecuteSystem
  {
    private readonly ILevelUpService _levelUpService;

    private readonly IGroup<GameEntity> _experienceMeters;
    private readonly IGroup<GameEntity> _heroes;

    public UpdateExperienceMeterSystem(GameContext gameContext, ILevelUpService levelUpService)
    {
      _levelUpService = levelUpService;
      _experienceMeters = gameContext.GetGroup(GameMatcher.ExperienceMeter);

      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Experience));
    }

    public void Execute()
    {
      foreach (GameEntity experienceMeter in _experienceMeters)
      foreach (GameEntity hero in _heroes)
        experienceMeter.ExperienceMeter.SetExperience(hero.Experience, _levelUpService.ExperienceForLevelUp());
    }
  }
}