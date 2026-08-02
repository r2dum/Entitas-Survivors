using System.Collections.Generic;
using CodeBase.Runtime.UI.Windows.Factory;
using UnityEngine;

namespace CodeBase.Runtime.UI.Windows
{
  public class WindowService : IWindowService
  {
    private readonly IWindowFactory _windowFactory;

    private readonly List<WindowBase> _openedWindows = new();

    public WindowService(IWindowFactory windowFactory) =>
      _windowFactory = windowFactory;

    public async void Open(WindowTypeId windowTypeId) =>
      _openedWindows.Add(await _windowFactory.CreateWindow(windowTypeId));

    public void Close(WindowTypeId windowTypeId)
    {
      WindowBase window = _openedWindows.Find(x => x.TypeId == windowTypeId);

      _openedWindows.Remove(window);

      Object.Destroy(window.gameObject);
    }
  }
}