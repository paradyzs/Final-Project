using UnityEngine;
using UnityEngine.AI;

public class EnemyRoaming : MonoBehaviour
{
    public Transform roamingArea; // Transform untuk batas area roaming
    public float roamingRadius = 10f; // Radius roaming
    public float waitTime = 2f; // Waktu tunggu di setiap titik
    private NavMeshAgent agent;
    private Vector3 targetPosition;
    private bool isWaiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isWaiting)
        {
            StartCoroutine(WaitBeforeNextRoam());
        }
    }

    void SetRandomDestination()
    {
        // Pilih titik acak dalam radius tertentu
        Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
        randomDirection += roamingArea.position;

        // Cek apakah titik berada di NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, roamingRadius, NavMesh.AllAreas))
        {
            targetPosition = hit.position;
            agent.SetDestination(targetPosition);
        }
    }

    System.Collections.IEnumerator WaitBeforeNextRoam()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        SetRandomDestination();
    }
}
