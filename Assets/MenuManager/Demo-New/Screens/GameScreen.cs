using UnityEngine;

namespace MenuManager.Demo_New.Screens
{
    public class GameScreen: UIScreen
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