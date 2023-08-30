using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UnityRoyale
{
    public class Countdown : MonoBehaviour
    {
        public TextMeshProUGUI countdownText;
        [SerializeField] private float initialCountdownTime;
        private float countdownTime;

        private void OnEnable()
        {
            ResetCountdown();
            StartCoroutine(StartCountdown());
        }

        private void OnDisable()
        {
            // Stop the countdown coroutine when the object is deactivated
            StopAllCoroutines();
        }

        private void ResetCountdown()
        {
            countdownTime = initialCountdownTime;
        }

        private IEnumerator StartCountdown()
        {
            while (countdownTime > 0)
            {
                // Update the countdown text
                countdownText.text = countdownTime.ToString("F0");

                yield return new WaitForSeconds(1f);

                countdownTime--;
            }

            // Countdown is finished
            countdownText.text = "Countdown Finished!";
        }
    }
}
