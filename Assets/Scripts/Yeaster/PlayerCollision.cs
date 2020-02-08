using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject PlayerHeadObject;
    
    void OnTriggerEnter2D(Collider2D col) {
        // Miss (Wall, Enemy)
        if (col.tag == "Miss") {
            GameMaster.Instance.Missed();
        }
        else if (col.tag == "Item") {
            // effect of items
            col.gameObject.GetComponent<ItemBehaviour>().OnItemGet();
            // score increase
            PlayerHeadObject.GetComponent<YeasterHeadManager>().PlusScore(col.GetComponent<ItemBehaviour>().score);
            // send message to game master
            ItemManager.Instance.ItemGet(col.gameObject);
            Debug.Log("Item touched, score: " + PlayerHeadObject.GetComponent<YeasterHeadManager>().score.ToString());
        }
    }
}
