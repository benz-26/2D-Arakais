using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityRoyale
{
    public class ManagerAudio : MonoBehaviour
    {
        public Button muteButton;
        public Sprite unmutedSprite;
        public Sprite mutedSprite;

        private const string MuteKey = "IsMuted";
        private bool isMuted;
        private Image buttonImage;

        private void Start()
        {
            // Load the mute state from player preferences, defaulting to unmuted if it doesn't exist
            isMuted = PlayerPrefs.GetInt(MuteKey, 0) == 1;

            // Initialize the button appearance
            buttonImage = muteButton.GetComponent<Image>();
            UpdateButtonAppearance();

            // Add a click listener to the mute button
            muteButton.onClick.AddListener(OnMuteButtonClick);

            // Set the initial audio mute state
            SetAudioMute(isMuted);
        }

        private void OnMuteButtonClick()
        {
            // Toggle the mute state
            isMuted = !isMuted;

            // Update the audio settings and save to player preferences
            SetAudioMute(isMuted);
            PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
            PlayerPrefs.Save();

            // Update the button appearance
            UpdateButtonAppearance();
        }

        private void SetAudioMute(bool isMuted)
        {
            // Set the mute state of the audio system
            AudioListener.volume = isMuted ? 0f : 1f;
        }

        private void UpdateButtonAppearance()
        {
            // Update the button sprite based on the mute state
            if (isMuted)
            {
                buttonImage.sprite = mutedSprite;
            }
            else
            {
                buttonImage.sprite = unmutedSprite;
            }
        }
    }
}
