using SpacePiercer.Managers;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SpacePiercer.UI
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Button Components")]
        public Button launchButton;
        public Button abortButton;

        [Header("HUD Component")]
        public HUD hud;

        private static bool inMainMenu;
        public static bool InMainMenu
        {
            get { return inMainMenu; }
            set { inMainMenu = value; }
        }

        // Use this for initialization
        void Start()
        {
            inMainMenu = true;
        }

        private void Update()
        {
            if (inMainMenu)
            {
                if (Input.GetButtonDown("XboxOne_A") || Input.GetKeyDown(KeyCode.A))
                {
                    GameManager.instance.baseSound.PlayUISound(0, new Vector3(0, 0, 0), 0.0f);
                    inMainMenu = false;
                    launchButton.interactable = false;
                    BeginGame();
                }
                if (Input.GetButtonDown("XboxOne_B") || Input.GetKeyDown(KeyCode.B))
                {
                    GameManager.instance.baseSound.PlayUISound(0, new Vector3(0, 0, 0), 0.0f);
                    inMainMenu = false;
                    abortButton.interactable = false;
                    Application.Quit();
                }
            }
        }

        private void BeginGame()
        {
            GameManager.instance.baseSound.mainMenuAudio.enabled = false;
            GameManager.instance.baseSound.gameAudio.Play();
            GetComponent<FadeChange>().FadeTo(0.0f);
            hud.ShowHUD();
        }

        private void OnDestroy()
        {
           
        }




    }
}
