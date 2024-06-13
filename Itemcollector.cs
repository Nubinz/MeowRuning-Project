using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollector : MonoBehaviour
{
    private int Items = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            Items++;
            Debug.Log("Items: " + Items);
        }
    }
}
