using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Runtime.UI.Windows.Factory
{
  public interface IWindowFactory
  {
    void SetUIRoot(RectTransform uiRoot);
    UniTask<WindowBase> CreateWindow(WindowTypeId windowTypeId);
  }
}