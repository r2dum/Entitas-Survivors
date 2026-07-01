using System.Runtime.CompilerServices;

namespace CodeBase.Runtime.Infrastructure.Debugs.Log
{
  public class LogService : ILogService
  {
    public void Write(string massage, [CallerMemberName] string member = "",
      [CallerFilePath] string file = "", [CallerLineNumber] int line = 0) =>
      UnityEngine.Debug.Log(
        $"[{System.IO.Path.GetFileName(file)}:{line} - {member}] {massage}");

    public void WriteError(string massage, [CallerMemberName] string member = "",
      [CallerFilePath] string file = "", [CallerLineNumber] int line = 0) =>
      UnityEngine.Debug.LogError(
        $"[{System.IO.Path.GetFileName(file)}:{line} - {member}] <color=red>{massage}</color>");

    public void WriteWarning(string massage, [CallerMemberName] string member = "",
      [CallerFilePath] string file = "", [CallerLineNumber] int line = 0) =>
      UnityEngine.Debug.LogWarning(
        $"[{System.IO.Path.GetFileName(file)}:{line} - {member}] <color=yellow>{massage}</color>");
  }
}