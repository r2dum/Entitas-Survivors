using CodeBase.Runtime.Gameplay.Core.Visuals.Status;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public class AppearanceSkin : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private StatusVisuals _statusVisuals;

    public SpriteRenderer Renderer => _renderer;
    public Animator Animator => _animator;
    public IStatusVisuals StatusVisuals => _statusVisuals;
  }
}