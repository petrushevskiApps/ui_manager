using MenuManager.Scripts.Utilitis;

public class NoInternetPopupViewModel : INoInternetPopupViewModel
{
    public IReactiveProperty<string> Title { get; protected set; }
    public IReactiveProperty<string> Message { get; protected set; }

    // Injected
    private readonly INavigationController _navigationController;

    public NoInternetPopupViewModel(INavigationController navigationController)
    {
        _navigationController = navigationController;
        Title = new ReactiveProperty<string>("Network connection failed.");
        Message = new ReactiveProperty<string>("Please check your cellular or Wi-Fi connection and retry.");
    }

    public void BackgroundClicked()
    {
        _navigationController.GoBack();
    }

    public void OkButtonClicked()
    {
        _navigationController.GoBack();
    }
}