using Project.Services;
using Project.Settings;
using Project.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project
{
    public class MainLifetimeScope : LifetimeScope
    {
        [Header("Settings")]
        [SerializeField] private MainSettings _mainSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_mainSettings);
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton);
            
            builder.RegisterComponentInHierarchy<UIController>();
        }
    }
}
