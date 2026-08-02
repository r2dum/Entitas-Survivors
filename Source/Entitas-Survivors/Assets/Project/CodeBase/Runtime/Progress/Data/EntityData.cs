using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeBase.Runtime.Progress.Data
{
  public class EntityData
  {
    [JsonProperty("es")] public List<EntitySnapshot> MetaEntitySnapshots;
  }
}