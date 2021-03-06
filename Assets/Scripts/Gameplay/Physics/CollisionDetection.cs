﻿using SpacePiercer.Managers;
using UnityEngine;
using System.Collections;

namespace SpacePiercer.Gameplay
{
    public class CollisionDetection : MonoBehaviour
    {
        [Header("Explosion")]
        public GameObject explosionPrefab;

        [Header("EndExplosion")]
        public GameObject shipBOOM;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Trash" && GameManager.instance.gameControl.PlayerAlive)
            {
                GameManager.instance.gameControl.PlayerHealth -= 10.0f;
                GameManager.instance.uiManager.hud.UpdateSlider();
                Destroy(other.gameObject);
                StartCoroutine(SpawnExplosion(other.transform.position));

                if (GameManager.instance.gameControl.PlayerHealth <= 0.0f)
                {
                    GameManager.instance.baseSound.PlayGameplaySound(1, new Vector3(0, 0, 0), 0.0f);
                    shipBOOM.SetActive(true);
                    GetComponentInParent<Animation>().Play("Death");
                    StartCoroutine(GameManager.instance.gameControl.EndGame());                   
                }
            }
        }

        private IEnumerator SpawnExplosion(Vector3 pos)
        {
            GameManager.instance.baseSound.PlayGameplaySound(0, this.transform.position, 0.0f);
            GameObject exp = Instantiate(explosionPrefab, pos, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(3.0f);
            Destroy(exp);
        }
    }
}
