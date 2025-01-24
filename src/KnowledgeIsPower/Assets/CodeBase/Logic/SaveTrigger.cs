using CodeBase.Services;
using CodeBase.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
  public class SaveTrigger : MonoBehaviour
  {
    private ISaveLoadService _saveLoadService;

    public BoxCollider Collider;

    [Inject]
    private void Construct(ISaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
    }

    private void OnTriggerEnter(Collider other)
    {
      _saveLoadService.SaveProgress();
      Debug.Log("Progress saved!");
      gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
      if(!Collider) return;
      
      Gizmos.color = new Color32(30, 200, 30, 130);
      Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
    }
  }
}