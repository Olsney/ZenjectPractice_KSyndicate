using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Start() => 
            DontDestroyOnLoad(this);
    }
}