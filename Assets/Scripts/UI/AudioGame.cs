using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityRoyale
{
    public class AudioGame : MonoBehaviour
    {
        [SerializeField] private GameObject audioGame; 

        public void Awake()
        {
            audioGame.SetActive(false);
        }
    }
}
