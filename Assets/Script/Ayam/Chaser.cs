using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public float chaseRadius = 10f; // Radius untuk mendeteksi pemain
    public Transform player; // Referensi ke Transform pemain
    private NavMeshAgent agent; // Komponen NavMeshAgent untuk pergerakan
    private bool isChasing = false; // Status pengejaran

    public float wanderRadius = 5f; // Radius untuk random movement saat idle
    public float wanderDelay = 3f; // Waktu jeda antara setiap random movement
    private float wanderTimer; // Timer untuk mengatur delay

    void Start()
    {
        // Mengambil komponen NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        wanderTimer = wanderDelay; // Inisialisasi timer
    }

    void Update()
    {
        if (isChasing && player != null)
        {
            // Jika sedang mengejar, set tujuan ke posisi pemain
            agent.SetDestination(player.position);
        }
        else
        {
            // Jika tidak mengejar, lakukan random movement
            Wander();
        }
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;
        if (wanderTimer >= wanderDelay)
        {
            // Pilih posisi random dalam radius tertentu
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
            randomDirection += transform.position;

            // Pastikan posisi berada di area navigasi
            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }

            wanderTimer = 0f; // Reset timer
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Cek jika GameObject yang masuk adalah Player
        if (other.CompareTag("Player"))
        {
            isChasing = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Cek jika GameObject yang keluar adalah Player
        if (other.CompareTag("Player"))
        {
            isChasing = false;
            agent.ResetPath(); // Hentikan pergerakan enemy
            player = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Menggambar radius untuk visualisasi di editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);

        // Menggambar radius wander
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }

    void OnValidate()
    {
        // Menyesuaikan ukuran Collider agar sesuai dengan chaseRadius
        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider != null)
        {
            collider.isTrigger = true;
            collider.radius = chaseRadius;
        }
    }
}
