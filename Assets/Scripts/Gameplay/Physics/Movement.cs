using SpacePiercer.UI;
using UnityEngine;
using System.Collections;

namespace SpacePiercer.Gameplay
{
    public class Movement : MonoBehaviour
    {
        [Header("Ship Speed")]
        public float movementSpeed;

        private void Update()
        {
            if (MainMenu.InMainMenu) return;
            ShipMovement();
        }

        private void ShipMovement()
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //moving left
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 15f)), 0.1f);
                transform.position += new Vector3(-(Time.deltaTime * movementSpeed), 0, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //moving right
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -15f)), 0.1f);
                transform.position += new Vector3((Time.deltaTime * movementSpeed), 0, 0);
            }
            else //not moving
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0f)), 0.1f); 
            }

            if (Input.GetKey(KeyCode.DownArrow)) //moving down
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(10, 0, 0)), 0.1f);
                transform.position += new Vector3(0, -(Time.deltaTime * movementSpeed), 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow)) //moving up
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-10, 0, 0)), 0.1f);
                transform.position += new Vector3(0, (Time.deltaTime * movementSpeed), 0);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0f)), 0.1f); 
            }

        }
    }
}
