using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang masuk memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            // Logika saat player masuk ke safe zone
            Debug.Log("Player has entered the safe zone!");
        }
        else
        {
            // Logika jika objek lain mencoba masuk (opsional)
            Debug.Log(other.gameObject.name + " is not allowed in the safe zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cek apakah player meninggalkan safe zone
        if (other.CompareTag("Player"))
        {
            // Logika saat player keluar dari safe zone
            Debug.Log("Player has exited the safe zone!");
        }
    }
}
