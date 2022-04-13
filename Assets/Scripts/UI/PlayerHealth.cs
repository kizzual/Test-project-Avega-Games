using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth _instance;

    [SerializeField] private Slider slider;
    [SerializeField] private int player_heals;

    void Start()
    {
        _instance = this;
        slider.maxValue = player_heals;
        slider.value = player_heals;  
    }
    public void TakeDamage(int damage)
    {
        player_heals -= damage;
        slider.value = slider.maxValue - (slider.maxValue - player_heals);
        if(player_heals <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
