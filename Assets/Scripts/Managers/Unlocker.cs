using UnityEngine;

namespace UnityRoyale
{
    public class Unlocker : MonoBehaviour
    {
        public string sceneName; // The scene name associated with the level

        private void Start()
        {
            LevelManager.Instance.UnlockLevel(sceneName);
        }
    }
}
