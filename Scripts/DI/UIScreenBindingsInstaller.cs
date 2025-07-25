﻿using TwoOneTwoGames.UIManager.Windows;
using Zenject;

namespace TwoOneTwoGames.UIManager.Di
{
    public class UIScreenBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindMainScreenDependencies();
            Container.BindInGameScreenDependencies();
            Container.BindLevelFailedScreenDependencies();
            Container.BindLevelCompletedScreenDependencies();
            Container.BindLevelsScreenDependencies();
        }
    }
}