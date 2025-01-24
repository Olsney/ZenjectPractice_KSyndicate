using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class GameRunner : MonoBehaviour
  {
    [Inject]
    private void Construct(GameBootstrapper bootstrapper)
    {
      if(bootstrapper != null) return;

      Instantiate(bootstrapper);
    }
  }
}