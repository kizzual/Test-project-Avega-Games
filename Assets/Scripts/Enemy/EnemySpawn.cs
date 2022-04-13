using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spanw_positions;
    [SerializeField] private int spawn_time;
    [SerializeField] Enemy enemy_prefab;
    [SerializeField]public LayerMask layer;

    [HideInInspector] public GameObject player;
    [HideInInspector]public float SphereRadius;
    private Vector3 spawnPos;
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= spawn_time)
        {
            spawnPos = GetRandomSpawnPoint();
            
            var go = Instantiate(enemy_prefab, spawnPos, Quaternion.identity);
            go.GetPlayerTransform(player.transform);
            timer = 0;
        }


    }

    private Vector3 GetRandomSpawnPoint()
    {
        int i = 0;
        var ranndom_number = Random.Range(0, spanw_positions.Count);
        Vector3 random_position = GetRandomPoint(spanw_positions[ranndom_number]);

        do
        {
            i++;
            ranndom_number = Random.Range(0, spanw_positions.Count);
            random_position = GetRandomPoint(spanw_positions[ranndom_number]);
            CheckColliderInSpawn(random_position);
            
            if (CheckColliderInSpawn(random_position))
                return random_position;

        } while (i < 20);

        
        return random_position;

    }
    private bool CheckColliderInSpawn(Vector3 center)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, 1);
        if(hitColliders.Length > 1)
            return false;
        else
            return true;
    }
    public Vector3 GetRandomPoint(Transform spawn_position)
    {
        Vector3 randomPos = Random.insideUnitSphere * SphereRadius + spawn_position.position;
        Vector3 pos = new Vector3(randomPos.x, 1, randomPos.z);

        while (!Physics.Linecast(pos, player.transform.position, layer))
        {
             randomPos = Random.insideUnitSphere * SphereRadius + spawn_position.position;
             pos = new Vector3(randomPos.x, 1, randomPos.z);
        }

        return pos;
    }
}
