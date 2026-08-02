namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Services
{
  public interface ILevelUpService
  {
    float CurrentExperience { get; }
    int CurrentLevel { get; }
    void AddExperience(float value);
    float ExperienceForLevelUp();
  }
}