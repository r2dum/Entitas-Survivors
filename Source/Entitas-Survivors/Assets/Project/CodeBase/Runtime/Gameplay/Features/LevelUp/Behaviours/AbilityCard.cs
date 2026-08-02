using System;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Abilities.Configs;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Behaviours
{
  public class AbilityCard : MonoBehaviour
  {
    private const int StampAnimationDelay = 1000;

    [SerializeField] private AbilityId _abilityId;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private GameObject _stamp;
    [SerializeField] private Button _button;

    private Action<AbilityId> _onSelected;

    public AbilityId AbilityId => _abilityId;

    public void Setup(AbilityId abilityId, AbilityLevel abilityLevel, Action<AbilityId> onSelected)
    {
      _abilityId = abilityId;
      _icon.sprite = abilityLevel.Icon;
      _description.text = abilityLevel.Description;

      _onSelected = onSelected;

      _button.onClick.AddListener(SelectCard);
    }

    private void OnDestroy() =>
      _button.onClick.RemoveListener(SelectCard);

    private async void SelectCard()
    {
      _stamp.SetActive(true);
      await UniTask.Delay(StampAnimationDelay);
      _onSelected?.Invoke(_abilityId);
    }
  }
}