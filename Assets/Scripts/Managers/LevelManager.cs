using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UnityRoyale
{
    public class LevelManager : MonoBehaviour
    {
        public LevelData levelData;
        public Button[] levelButtons; // Reference to the level buttons in the scene

        private static LevelManager instance;

        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("LevelManager instance has not been initialized.");
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
                InitializeButtons();

                // Check if any levels have been unlocked and update the button states accordingly
                for (int i = 0; i < levelData.levels.Length; i++)
                {
                    LevelData.LevelInfo level = levelData.levels[i];
                    bool unlocked = IsLevelUnlocked(level.sceneName);

                    if (unlocked)
                    {
                        UpdateButtonState(level.sceneName, true);
                    }
                }

        }

        private void InitializeButtons()
        {
            for (int i = 0; i < levelData.levels.Length; i++)
            {
                LevelData.LevelInfo level = levelData.levels[i];

                Button button = levelButtons[i];
                button.onClick.AddListener(() => LoadScene(level.sceneName));

                bool unlocked = level.unlocked && IsLevelUnlocked(level.sceneName);
                button.interactable = unlocked;

                ColorBlock colors = button.colors;
                colors.normalColor = unlocked ? level.unlockedColor : level.lockedColor;
                colors.disabledColor = level.lockedColor;
                button.colors = colors;
            }
        }

        private void LoadScene(string sceneName)
        {
            Addressables.LoadSceneAsync(sceneName);
        }

        public bool IsLevelUnlocked(string sceneName)
        {
            return PlayerPrefs.GetInt(sceneName, 0) == 1;
        }

        public void UnlockLevel(string sceneName)
        {
            foreach (LevelData.LevelInfo level in levelData.levels)
            {
                if (level.sceneName == sceneName)
                {
                    level.unlocked = true;
                    PlayerPrefs.SetInt(sceneName, 1);
                    PlayerPrefs.Save();

                    UpdateButtonState(level.sceneName, true);
                    return;
                }
            }
        }

        private void UpdateButtonState(string sceneName, bool unlocked)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (levelData.levels[i].sceneName == sceneName)
                {
                    Button button = levelButtons[i];
                    button.interactable = unlocked;

                    ColorBlock colors = button.colors;
                    colors.normalColor = unlocked ? levelData.levels[i].unlockedColor : levelData.levels[i].lockedColor;
                    colors.disabledColor = levelData.levels[i].lockedColor;
                    button.colors = colors;

                    break;
                }
            }
        }

        public Color GetLevelLockedColor(string sceneName)
        {
            foreach (LevelData.LevelInfo level in levelData.levels)
            {
                if (level.sceneName == sceneName)
                {
                    return level.lockedColor;
                }
            }
            return Color.white;
        }

        public Color GetLevelUnlockedColor(string sceneName)
        {
            foreach (LevelData.LevelInfo level in levelData.levels)
            {
                if (level.sceneName == sceneName)
                {
                    return level.unlockedColor;
                }
            }
            return Color.white;
        }
    }
}
