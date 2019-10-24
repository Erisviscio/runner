using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.Interfaces.Services;
using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
		Container.Bind<IHealthService>().To<HealthService>().AsSingle();
		Container.Bind<IScoreService>().To<ScoreService>().AsSingle();
	}
}