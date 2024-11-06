using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winPanel.SetActive(true);
        }
    }

}
