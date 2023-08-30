using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityRoyale
{

    public class BackgroundSlider : MonoBehaviour
    {

        [SerializeField] private RawImage slider;
        [SerializeField] private RawImage sliderE;
        [SerializeField] private float xPos, yPos;
        [SerializeField] private float speed;


        private void Update()
        {
            slider.uvRect = new Rect(slider.uvRect.position + new Vector2(xPos, yPos) * Time.deltaTime, slider.uvRect.size);
            sliderE.uvRect = new Rect(sliderE.uvRect.position + new Vector2(xPos, yPos) * Time.deltaTime, sliderE.uvRect.size);
        }

    }
}
