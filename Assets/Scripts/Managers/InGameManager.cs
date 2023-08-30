using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityRoyale
{
    public class InGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject pausedPanel;

        private void Start()
        {
            Time.timeScale = 1;
            pausedPanel.SetActive(false);
        }

        public void PausedGame()
        {
            pausedPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            pausedPanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void SceneGo(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
