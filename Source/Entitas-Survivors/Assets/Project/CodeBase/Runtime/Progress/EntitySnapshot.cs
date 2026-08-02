using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeBase.Runtime.Progress
{
  public class EntitySnapshot
  {
    [JsonProperty("c")] public List<ISavedComponent> Components;
  }
}