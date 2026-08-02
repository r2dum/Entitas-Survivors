using CodeBase.Runtime.Infrastructure.GameFlowStateMachine;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates;
using CodeBase.Runtime.UI.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Runtime.Meta.UI.HUD
{
  public class LobbyWindow : WindowBase
  {
    [SerializeField] private Button _startBattleButton;
    [SerializeField] private Button _shopButton;

    private GameStateMachine _gameStateMachine;
    private IWindowService _windowService;

    [Inject]
    private void Construct(GameStateMachine gameStateMachine, IWindowService windowService)
    {
      _gameStateMachine = gameStateMachine;
      _windowService = windowService;
    }

    protected override void SubscribeUpdates()
    {
      _startBattleButton.onClick.AddListener(EnterMeadowFlowState);
      _shopButton.onClick.AddListener(OpenShop);
    }

    protected override void UnsubscribeUpdates()
    {
      _startBattleButton.onClick.RemoveListener(EnterMeadowFlowState);
      _shopButton.onClick.RemoveListener(OpenShop);
    }

    private void EnterMeadowFlowState() =>
      _gameStateMachine.Enter<MeadowFlowState>();

    private void OpenShop() =>
      _windowService.Open(WindowTypeId.ShopWindow);
  }
}