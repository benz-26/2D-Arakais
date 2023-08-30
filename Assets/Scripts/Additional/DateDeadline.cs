using System;
using UnityEngine;

namespace UnityRoyale
{
    public class DateDeadline : MonoBehaviour
    {
        public GameObject targetGameObject;
        public int targetYear;
        public int targetMonth;
        public int targetDay; 

        private void Start()
        {
            DateTime currentDateTime = DateTime.UtcNow;

            DateTime targetDateTime = new DateTime(targetYear, targetMonth, targetDay, 0, 0, 0, DateTimeKind.Utc);
            if (currentDateTime >= targetDateTime)
            {
                targetGameObject.SetActive(true);
                Debug.Log("Bro");
            }
            else
            {
                targetGameObject.SetActive(false);
                Debug.Log("Brao");
            }
        }
    }
}
