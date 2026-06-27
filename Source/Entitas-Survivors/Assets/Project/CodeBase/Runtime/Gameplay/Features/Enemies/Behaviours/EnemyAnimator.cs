using CodeBase.Runtime.Gameplay.Core.Visuals;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Behaviours
{
  public class EnemyAnimator : MonoBehaviour, IDamageTakenAnimator
  {
    private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");
    private readonly int _diedHash = Animator.StringToHash("died");

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Material Material => _spriteRenderer.material;

    public void PlayDied() =>
      _animator.SetTrigger(_diedHash);

    public void PlayDamageTaken()
    {
      if (DOTween.IsTweening(Material))
        return;

      Material.DOFloat(0.4f, OverlayIntensityProperty, 0.15f)
        .OnComplete(() =>
        {
          if (_spriteRenderer)
            Material.DOFloat(0, OverlayIntensityProperty, 0.15f);
        });
    }

    public void ResetAll() =>
      _animator.ResetTrigger(_diedHash);
  }
}