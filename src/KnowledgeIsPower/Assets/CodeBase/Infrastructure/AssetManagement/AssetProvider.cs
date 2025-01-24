using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public GameObject Load(string path) => 
      Resources.Load<GameObject>(path);
  }
}