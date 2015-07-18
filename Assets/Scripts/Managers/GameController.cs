using SpacePiercer.UI;
using UnityEngine;
using System.Collections;

namespace SpacePiercer.Managers
{
    public class GameController : MonoBehaviour
    {

        private float gameTime;
        public float GameTime
        {
            get { return gameTime; }
            set { gameTime = value; }
        }

        private float playerHealth;
        public float PlayerHealth
        {
            get { return playerHealth; }
            set { playerHealth = value; }
        }

        private float playerPower;
        public float PlayerPower
        {
            get { return playerPower; }
            set { playerPower = value; }
        }

        private bool playerAlive;
        public bool PlayerAlive
        {
            get { return playerAlive; }
            set { playerAlive = value; }
        }

        private void Start()
        {
            playerHealth = 1.0f;
            playerPower = 100.0f;
            playerAlive = true;
        }

        void Update()
        {
            if (!MainMenu.InMainMenu)
            {
                gameTime += Time.deltaTime;
            }
        }

        public IEnumerator EndGame()
        {
            yield return new WaitForSeconds(4.0f);
            Application.LoadLevel(0);
        }
    }
}
