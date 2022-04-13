using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    private MeshRenderer mesh;
    private Color mesh_color;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        int randomColor = Random.Range(0, 100);

        if(randomColor < 33)
        {
            mesh_color = Color.red;
        }
        else if(randomColor > 33 && randomColor < 66)
        {
            mesh_color = Color.yellow;
        }
        else
        {
            mesh_color = Color.green;
        }
        mesh.material.color = mesh_color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon.bullet_color = mesh_color;
            CubeScore._instance.DisplayScoreColor(mesh_color);
            Destroy(gameObject);
        }
    }
}
