using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private FP_Input playerInput;

    [SerializeField] private float reloadTime;
    [SerializeField] private Bullet bullet_prefab;
    [SerializeField] private float bullet_speed;
    [SerializeField] private int ammo_count;
    [SerializeField] private float shootRate;

    [HideInInspector] public static Color bullet_color;
    private int ammo;
    private bool reloading;
    private float timer;

    void Start()
    {
        ammo = ammo_count;
        bullet_color = Color.white;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(playerInput.UseMobileInput)
        {
            if (playerInput.Shoot())
                if (timer > shootRate && !reloading)
                {
                    Debug.Log("Shoot");
                    Shoot();
                    timer = 0;
                }
            if (playerInput.Reload())
                if (!reloading && ammo_count < ammo)
                    StartCoroutine("Reload");
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                if (timer > shootRate && !reloading)
                {
                    Debug.Log("Shoot");
                    Shoot();
                    timer = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                if (!reloading && ammo_count < ammo)
                    StartCoroutine("Reload");
            }
        } 
    }
    private void Shoot()
    {
        if (ammo_count > 0)
        {
            var bullet = Instantiate(bullet_prefab, transform.position, transform.rotation);
            bullet.speed = bullet_speed;
            bullet.mesh.material.color = bullet_color;
            ammo_count--;
        }
        else
        {
            Debug.Log("Need reload");
        }
    }
    private IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        ammo_count = ammo;
        reloading = false;
    }
    void OnGUI()
    {
        GUILayout.Label("AMMO: " + ammo_count);
    }
}
