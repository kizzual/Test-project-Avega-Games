using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [HideInInspector] public MeshRenderer mesh;
    [HideInInspector] public float speed;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(timer >= 5)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
