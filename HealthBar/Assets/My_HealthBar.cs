using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_HealthBar : MonoBehaviour {

    public float currentHealth;
    public float newHealth;

    private Rect HealthBar;
    private Rect add;
    private Rect minus;

    public Slider healthSlider;

    // Use this for initialization
    void Start()
    {
        HealthBar = new Rect(50, 50, 200, 20);
        add = new Rect(200, 70, 40, 20);
        minus = new Rect(55, 70, 40, 20); 

        newHealth = currentHealth = 0.75f; 
    }

    void OnGUI()
    {
        if (GUI.Button(add, "加血"))
        {
            newHealth = newHealth + 0.1f > 1.0f ? 1.0f : newHealth + 0.1f;
        }
        if (GUI.Button(minus, "减血"))
        {
            newHealth = newHealth - 0.1f < 0.0f ? 0.0f : newHealth - 0.1f;
        }

        //插值计算currentHealth值，以实现血条值平滑变化
        currentHealth = Mathf.Lerp(currentHealth, newHealth, 0.05f);

        // 用水平滚动条的宽度作为血条的显示值
        GUI.HorizontalScrollbar(HealthBar, 0.0f, currentHealth, 0.0f, 1.0f);
        healthSlider.value = newHealth;
    }
}