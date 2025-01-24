using System.Runtime.Serialization;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private const string UIRootPath = "UI/UIRoot";
    private readonly IAssetProvider _assets;
    private readonly IStaticDataService _staticData;
    
    private Transform _uiRoot;
    private readonly IPersistentProgressService _progressService;
    private readonly IInstantiator _container;

    public UIFactory(IAssetProvider assets, IStaticDataService staticData, IPersistentProgressService progressService, IInstantiator container)
    {
      _assets = assets;
      _staticData = staticData;
      _progressService = progressService;
      _container = container;
    }

    public void CreateShop()
    {
      WindowConfig confing = _staticData.ForWindow(WindowId.Shop);
      WindowBase window = _container.InstantiatePrefabForComponent<WindowBase>(confing.Template, _uiRoot);
      window.Construct(_progressService);
    }

    public void CreateUIRoot()
    {
      GameObject prefab = _assets.Load(UIRootPath);
      _uiRoot = _container.InstantiatePrefab(prefab).transform;
    }
  }
}