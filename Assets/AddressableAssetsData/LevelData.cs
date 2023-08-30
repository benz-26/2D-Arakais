using UnityEngine;

namespace UnityRoyale
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "UnityRoyale/Level Data")]
    public class LevelData : ScriptableObject
    {
        [System.Serializable]
        public class LevelInfo
        {
            public string sceneName;
            public bool unlocked;
            public Color lockedColor;
            public Color unlockedColor;
        }

        public LevelInfo[] levels;
    }
}
