using PetrushevskiApps.UIManager;
using slowBulletGames.MemoryValley;
using UnityEngine;
using Zenject;

public class NoInternetPopup : UIPopup
{
    [SerializeField]
    private UIButton _okButton;
    
    // Injected
    private INoInternetPopupViewModel _viewModel;

    protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
    [Inject]
    private void Initialize(INoInternetPopupViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override void Resume()
    {
        base.Resume();
        _okButton.onClick.AddListener(_viewModel.OkButtonClicked);
    }

    public override void Hide()
    {
        base.Hide();
        _okButton.onClick.RemoveListener(_viewModel.OkButtonClicked);
    }
}