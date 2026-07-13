using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public class AppearanceVisuals : MonoBehaviour, IAppearanceVisuals
  {
    [SerializeField] private AppearanceSkin _defaultSkin;
    [SerializeField] private Transform _container;

    private IAppearanceSkinFactory _appearanceSkinFactory;
    private AppearanceSkin _activeSkin;

    public AppearanceSkin CurrentSkin => _activeSkin != null ? _activeSkin : _defaultSkin;
    public SpriteRenderer Renderer => CurrentSkin.Renderer;
    public Animator Animator => CurrentSkin.Animator;

    [Inject]
    private void Construct(IAppearanceSkinFactory appearanceSkinFactory) =>
      _appearanceSkinFactory = appearanceSkinFactory;

    public void ApplySkin(AppearanceSkin appearanceSkin)
    {
      if (_activeSkin != null)
        ClearSkin();

      _defaultSkin.gameObject.SetActive(false);
      _activeSkin = _appearanceSkinFactory.Create(appearanceSkin, _container);
    }

    public void ClearSkin()
    {
      if (_activeSkin == null)
        return;

      Destroy(_activeSkin.gameObject);
      _activeSkin = null;
      _defaultSkin.gameObject.SetActive(true);
    }
  }
}