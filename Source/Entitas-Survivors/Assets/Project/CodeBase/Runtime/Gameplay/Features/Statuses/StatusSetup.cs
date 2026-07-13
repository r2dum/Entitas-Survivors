using System;
using CodeBase.Runtime.Gameplay.Core.Visuals.Appearance;

namespace CodeBase.Runtime.Gameplay.Features.Statuses
{
  [Serializable]
  public class StatusSetup
  {
    public AppearanceSkin AppearanceSkin;
    public StatusTypeId StatusTypeId;
    public float Value;
    public float Duration;
    public float Period;
  }
}