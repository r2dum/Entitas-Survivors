using CodeBase.Runtime.Gameplay.Core.Visuals;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Hero.Behaviours
{
  public class HeroAnimator : MonoBehaviour, IDamageTakenAnimator
  {
    private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");

    private readonly int _isMovingHash = Animator.StringToHash("isMoving");
    private readonly int _attackHash = Animator.StringToHash("attack");
    private readonly int _diedHash = Animator.StringToHash("died");

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Material Material => _spriteRenderer.material;

    public void PlayMove() =>
      _animator.SetBool(_isMovingHash, true);
    public void PlayIdle() =>
      _animator.SetBool(_isMovingHash, false);

    public void PlayAttack() =>
      _animator.SetTrigger(_attackHash);

    public void PlayDied() =>
      _animator.SetTrigger(_diedHash);

    public void PlayDamageTaken()
    {
      if (DOTween.IsTweening(Material))
        return;

      Material.DOFloat(0.5f, OverlayIntensityProperty, 0.15f)
        .OnComplete(() =>
        {
          if (_spriteRenderer)
            Material.DOFloat(0, OverlayIntensityProperty, 0.15f);
        });
    }

    public void ResetAll()
    {
      _animator.ResetTrigger(_attackHash);
      _animator.ResetTrigger(_diedHash);
    }
  }
}