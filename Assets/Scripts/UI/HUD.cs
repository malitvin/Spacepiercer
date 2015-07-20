using SpacePiercer.Managers;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace SpacePiercer.UI
{
    public class HUD : MonoBehaviour
    {
        [Header("Slider Components")]
        public Slider healthSlider;
        public Slider powerSlider;

        [Header("Game Time")]
        public Text gameTime;
        public Text highScore;

        [Header("GameObjects")]
        public GameObject inGameHUD;
        public GameObject menuHUD;

        void Start()
        {
            highScore.text = "High Score: " + ToString_Time((float)Math.Round(DataManager.GetHighScore(), 2));
        }

        private void Update()
        {
            gameTime.text = ToString_Time((float)Math.Round(GameManager.instance.gameControl.GameTime, 2));
        }

        public void ShowHUD()
        {
            menuHUD.GetComponent<CanvasGroup>().alpha = 0.0f;
            inGameHUD.GetComponent<FadeChange>().FadeTo(1.0f);
            AnimateSlider();
        }

        public void UpdateSlider()
        {
            healthSlider.value = GameManager.instance.gameControl.PlayerHealth;
            powerSlider.value = GameManager.instance.gameControl.PlayerPower;
        }

        public void AnimateSlider()
        {
            iTween.ValueTo(this.gameObject, iTween.Hash(
              "from", 0.0f,
              "to", 100.0f,
              "time", 1.0f,
              "onupdate", "Slide"));
        }

        private void Slide(float newValue)
        {
            healthSlider.value = newValue;
            powerSlider.value = newValue;
        }

        /** Returns a custom string version of the value. */
        public string ToString_Time(float seconds)
        {
            string str = (int)(seconds / 60) + ":";

            if ((int)(seconds % 60) > 9) { str += (int)(seconds % 60); }
            else if ((int)(seconds % 60) == 0) { str += "00"; }
            else { str += "0" + (int)(seconds % 60); }

            return str;
        }

    }
}
