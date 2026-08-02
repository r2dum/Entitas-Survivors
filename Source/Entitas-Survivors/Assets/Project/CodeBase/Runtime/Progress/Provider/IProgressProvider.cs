using CodeBase.Runtime.Progress.Data;

namespace CodeBase.Runtime.Progress.Provider
{
  public interface IProgressProvider
  {
    ProgressData ProgressData { get; }
    EntityData EntityData { get; }
    void SetProgressData(ProgressData data);
  }
}