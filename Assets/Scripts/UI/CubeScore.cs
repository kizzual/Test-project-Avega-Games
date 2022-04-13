using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeScore : MonoBehaviour
{
    public static CubeScore _instance;
    [SerializeField] private Text greenCube_text;
    [SerializeField] private Text redCube_text;
    [SerializeField] private Text yellowCube_text;
    private int greenCube_count = 0;
    private int redCube_count = 0;
    private int yellowCube_count = 0;
    void Awake()
    {
        _instance = this;
    }

    public void DisplayScoreColor(Color color)
    {
        if (color == Color.red)
        {
            redCube_count++;
            redCube_text.text = redCube_count.ToString();
        }
        else if (color == Color.yellow)
        {
            yellowCube_count++;
            yellowCube_text.text = yellowCube_count.ToString();
        }
        else if (color == Color.green)
        {
            greenCube_count++;
            greenCube_text.text = greenCube_count.ToString();
        }
    }

}
 