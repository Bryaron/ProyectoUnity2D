using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

    private void OnEnable() {
        GameManager.OnUpdateScore += Deactivate;
    }

    private void OnDisable() {
        GameManager.OnUpdateScore.Invoke();
        GameManager.OnUpdateScore -= Deactivate;
    }

    [Header("Information")]
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {
            //Destruyendo al jugador y spawneando explosiones
            Destroy(gameObject);
            SpawnExplosions(transform.position, 0.5f);
            Deactivate();
        }

        if (collision.CompareTag("Bullet")) {
            Deactivate();
            //Destruyendo al jugador y spawneando explosiones
            Destroy(gameObject);
            SpawnExplosions(transform.position, 0.5f);
        }
    }

    private void Deactivate() {
        //Destroy o desactivar
        //gameObject.SetActive(false);
        Debug.Log("Se borraran todos los gameobjects suscritos a este evento");
    }

    public void SpawnExplosions(Vector3 centerPosition, float spawnRadius) {
        for (int i = 0; i < 10; i++) {
            Vector3 randomPosition = centerPosition + Random.insideUnitSphere * spawnRadius;
            
            GameObject explosion = ObjectPooler.instance.GetPoolObject("Explosion");
            explosion.transform.position = randomPosition;
            explosion.SetActive(true);
        }
    }
}
