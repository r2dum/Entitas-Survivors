using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Infrastructure.SceneLoading
{
  public interface ISceneLoader
  {
    UniTask LoadAsync(string nextScene);
  }
}