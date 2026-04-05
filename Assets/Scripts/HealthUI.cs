using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
[SerializeField] GameObject healthIcon;
[SerializeField] List<GameObject> healthIcons = new List<GameObject>();
public void SetupHealth(int health)
    {
        for (int i = 0; i < health; i++)
        {
            GameObject icon = Instantiate(healthIcon, transform);
            healthIcons.Add(icon);
        }
    }
    public void UpdateHealth(int health)
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            if (i < health)
            {
                healthIcons[i].SetActive(true);
            }
            else
            {
                healthIcons[i].SetActive(false);
            }
        }
    }
}
