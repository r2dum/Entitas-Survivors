using System;
using UnityEngine;

namespace CodeBase.Runtime.Common.Times
{
  public class UnityTimeService : ITimeService
  {
    private bool _paused;

    public float DeltaTime => _paused == false ? Time.deltaTime : 0f;

    public DateTime UtcNow => DateTime.UtcNow;

    public void StopTime() =>
      _paused = true;

    public void StartTime() =>
      _paused = false;
  }
}