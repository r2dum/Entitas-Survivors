using CodeBase.Runtime.Common.Entity;
using CodeBase.Runtime.Gameplay.GameplayStaticData;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Services
{
  public class LevelUpService : ILevelUpService
  {
    private readonly IGameplayStaticDataService _staticDataService;

    public float CurrentExperience { get; private set; }
    public int CurrentLevel { get; private set; }

    public LevelUpService(IGameplayStaticDataService staticDataService) =>
      _staticDataService = staticDataService;

    public void AddExperience(float value)
    {
      CurrentExperience += value;
      UpdateLevel();
    }

    public float ExperienceForLevelUp() =>
      _staticDataService.ExperienceForLevel(CurrentLevel + 1);

    private void UpdateLevel()
    {
      if (CurrentLevel >= _staticDataService.MaxLevel())
        return;

      float experienceForLevel = _staticDataService.ExperienceForLevel(CurrentLevel + 1);

      if (CurrentExperience < experienceForLevel)
        return;

      CurrentExperience -= experienceForLevel;
      CurrentLevel++;

      CreateEntity.Empty()
        .isLevelUp = true;

      UpdateLevel();
    }
  }
}