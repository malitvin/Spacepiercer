using SpacePiercer.Managers;
using UnityEngine;
using System.Collections;

namespace SpacePiercer.Gameplay
{
    public class CollisionDetection : MonoBehaviour
    {
        [Header("Explosion")]
        public GameObject explosionPrefab;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Trash")
            {
                GameManager.instance.gameControl.PlayerHealth -= 10.0f;
                GameManager.instance.uiManager.hud.UpdateSlider();
                Destroy(other.gameObject);
                StartCoroutine(SpawnExplosion(other.transform.position));
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
