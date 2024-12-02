using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang ditabrak memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            // Hancurkan Player
            Destroy(other.gameObject);

            // (Opsional) Tambahkan logika tambahan, seperti game over
            Debug.Log("Player has been destroyed!");
        }
    }
}
