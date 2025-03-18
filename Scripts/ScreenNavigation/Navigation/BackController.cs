using UnityEngine;
using Zenject;

public class BackController: MonoBehaviour
{
    [Inject]
    private INavigationController _navigationController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _navigationController.GetActiveBackHandler()?.OnBackTriggered();
        }
    }

}