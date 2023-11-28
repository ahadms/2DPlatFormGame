using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int PlayerHealth = 3;

    [SerializeField] private Image[] hearths;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite EmptyHeart;

    private void Update()
    {
        foreach (Image img in hearths)
        {
            img.sprite = EmptyHeart;
        }
        for (int i = 0; i <PlayerHealth; i++)
        {
            hearths[i].sprite = fullHeart;
        }
    }

}
