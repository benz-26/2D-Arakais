using UnityEngine;

namespace UnityRoyale
{
    public class UnlockerLevel : MonoBehaviour
    {
        public string sceneName; // The scene name associated with the level

        private void Awake()
        {
            LevelManager.Instance.UnlockLevel(sceneName);
        }
    }
}
