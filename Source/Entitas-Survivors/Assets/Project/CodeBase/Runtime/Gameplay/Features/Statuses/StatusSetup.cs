using System;

namespace CodeBase.Runtime.Gameplay.Features.Statuses
{
  [Serializable]
  public class StatusSetup
  {
    public StatusTypeId StatusTypeId;
    public float Value;
    public float Duration;
    public float Period;
  }
}