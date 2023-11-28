using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private int cherries = 0;
    [SerializeField] private TextMeshProUGUI CherryCount;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log("cherries"  +  1);
            CherryCount.text = "cherries" + " : "  + cherries.ToString();
        }
    }
}
