using UnityEngine;
using Zenject;

namespace TwoOneTwoGames.UIManager.ScreenNavigation
{
    public class BackController : MonoBehaviour
    {
        [Inject]
        private INavigationController _navigationController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) _navigationController.GetActiveBackHandler()?.OnBackTriggered();
        }
    }
}