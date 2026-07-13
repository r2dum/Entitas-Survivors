using CodeBase.Runtime.Gameplay.Core.Visuals;
using CodeBase.Runtime.Gameplay.Core.Visuals.Appearance;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Behaviours
{
  public class EnemyAnimator : MonoBehaviour, IDamageTakenAnimator
  {
    private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");
    private readonly int _diedHash = Animator.StringToHash("died");

    [SerializeField] private AppearanceVisuals _appearanceVisuals;

    private MaterialPropertyBlock _materialPropertyBlock;
    private float _overlayIntensity;

    private void Awake() =>
      _materialPropertyBlock = new MaterialPropertyBlock();

    public void PlayDied() =>
      _appearanceVisuals.Animator.SetTrigger(_diedHash);

    public void PlayDamageTaken()
    {
      DOTween.Kill(this);

      DOTween.To(() => _overlayIntensity, x => _overlayIntensity = x, 0.4f, 0.15f)
        .OnUpdate(ApplyOverlay)
        .OnComplete(() =>
        {
          DOTween.To(() => _overlayIntensity, x => _overlayIntensity = x, 0f, 0.15f)
            .OnUpdate(ApplyOverlay);
        })
        .SetTarget(this);
    }

    public void ResetAll()
    {
      _appearanceVisuals.Animator.ResetTrigger(_diedHash);
      _overlayIntensity = 0f;
      ApplyOverlay();
    }

    private void ApplyOverlay()
    {
      _appearanceVisuals.Renderer.GetPropertyBlock(_materialPropertyBlock);
      _materialPropertyBlock.SetFloat(OverlayIntensityProperty, _overlayIntensity);
      _appearanceVisuals.Renderer.SetPropertyBlock(_materialPropertyBlock);
    }
  }
}