using UnityEngine;

namespace MenuManager.Demo_New.Screens
{
    public class GameScreen: BaseScreen
    {
        public override void Show<T>(T navArguments)
        {
            if (navArguments is GameScreenArguments args)
            {
                Debug.Log($"{args.Message}");
            }
            base.Show(navArguments);
        }
    }

    public class GameScreenArguments
    {
        public string Message { get; set; }
    }
}