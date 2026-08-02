using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours
{
  public class ExperienceMeter : MonoBehaviour
  {
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Image _fill;

    public void SetExperience(float herpExperience, float experienceForLevelUp) =>
      _progressBar.value = herpExperience / experienceForLevelUp;
  }
}