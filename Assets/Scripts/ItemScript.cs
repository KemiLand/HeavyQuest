using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    private int itemsCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itemsCount += 1;
            Debug.Log("Items picked up : " + itemsCount);
            Destroy(gameObject);
        }
    }
}
