using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityRoyale
{
    public class MainMenuManager : MonoBehaviour
    {
        private const string storyReadFlag = "StoryReadFlag";

        public void LoadScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void GameQuit()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            bool storyRead = PlayerPrefs.GetInt("StoryReadFlag", 0) == 1;

            if (storyRead)
            {
                LoadScene(2); // Go to Scene 2 if the story has already been read
            }
            else
            {
                PlayerPrefs.SetInt("StoryReadFlag", 1); // Set the flag to indicate the player has read the story
                PlayerPrefs.Save();

                LoadScene(1); // Go to Scene 1 for the first time
            }
        }


    }
}
