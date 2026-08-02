namespace CodeBase.Runtime.Progress.SaveLoad
{
  public interface ISaveLoadService
  {
    void SaveProgress();
    void LoadProgress();
    void CreateProgress();
    bool HasSavedProgress { get; }
  }
}