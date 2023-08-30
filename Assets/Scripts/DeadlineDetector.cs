using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityRoyale
{
    public class DeadlineDetector : MonoBehaviour
    {
        public int deadlineHour;
        public int deadlineMinute;
        public GameObject uiPanel;

        private int currentHour;
        private int currentMinute;
        private float startTime;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("StartTime"))
            {
                startTime = PlayerPrefs.GetFloat("StartTime");
            }
            else
            {
                startTime = Time.time;
                PlayerPrefs.SetFloat("StartTime", startTime);
            }
        }

        private void Update()
        {
            CalculateElapsedTime();

            if (currentHour >= deadlineHour && currentMinute >= deadlineMinute)
            {
                ShowUIPanel();
            }
        }

        private void CalculateElapsedTime()
        {
            float elapsedTime = Time.time - startTime;
            currentHour = Mathf.FloorToInt(elapsedTime / 3600) % 24;
            currentMinute = Mathf.FloorToInt(elapsedTime / 60) % 60;
        }

        private void ShowUIPanel()
        {
            if (uiPanel != null && !uiPanel.activeSelf)
            {
                uiPanel.SetActive(true);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (uiPanel != null && uiPanel.activeSelf)
            {
                uiPanel.SetActive(false);
            }
        }

        private void OnApplicationQuit()
        {
            // Save the start time when the application is closed
            PlayerPrefs.SetFloat("StartTime", startTime);
            PlayerPrefs.Save();
        }
    }
}
