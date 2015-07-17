using SpacePiercer.UI;
using UnityEngine;
using System.Collections;

namespace SpacePiercer.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance; /*private reference only this class can access*/

        /*This is the public reference Singleton that other classes will use*/
        public static GameManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }

        [Header("Sound Manager")]
        public BaseSoundController baseSound;

        [Header("Game Controller")]
        public GameController gameControl;

        [Header("Main Menu")]
        public MainMenu uiManager;
    }


}
