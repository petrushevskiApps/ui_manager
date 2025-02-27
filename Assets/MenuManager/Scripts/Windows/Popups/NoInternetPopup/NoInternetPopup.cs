using PetrushevskiApps.UIManager;
using slowBulletGames.MemoryValley;
using Zenject;

public class NoInternetPopup : UIPopup
{
    // Injected
    private INoInternetPopupViewModel _viewModel;

    protected override IPopupViewModel GetPopupViewModel() => _viewModel;
        
    [Inject]
    private void Initialize(INoInternetPopupViewModel viewModel)
    {
        _viewModel = viewModel;
    }
}