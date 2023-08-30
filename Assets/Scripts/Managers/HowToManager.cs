using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityRoyale
{
    public class HowToManager : MonoBehaviour
    {
        [SerializeField] private GameObject instructionPanel;
        private const string instructionReadFlag = "instructionFlag";

        // Start is called before the first frame update
        void Awake()
        {
            bool instructionRead = PlayerPrefs.GetInt(instructionReadFlag, 0) == 1;
            if (instructionRead)
            {
                instructionPanel.SetActive(false);
            }
            else
            {
                instructionPanel.SetActive(true);
                // Set the instructionReadFlag to 1 to indicate that the instruction panel has been shown.
                PlayerPrefs.SetInt(instructionReadFlag, 1);
                PlayerPrefs.Save();
            }
        }

        public void OpenHowTo()
        {
            instructionPanel.SetActive(true);
        }

        public void CloseHowTo()
        {
            instructionPanel.SetActive(false);
        }
    }
}
