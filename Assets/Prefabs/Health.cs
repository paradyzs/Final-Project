using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Cek apakah objek yang ditabrak memiliki tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Hancurkan player
            Destroy(gameObject);

            // (Opsional) Tambahkan logika tambahan, seperti game over
            Debug.Log("Player has been destroyed by an enemy!");
        }
    }
}
