using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        // Miss (Wall, Enemy)
        if (col.collider.tag == "Miss") {
            GameMaster.Instance.Missed();
        }
        else if (GameData.IsItemTag(col.collider.tag)) {
            GameMaster.Instance.Score += GameData.ItemScore[col.collider.tag];
            Destroy(col.gameObject);
            Debug.Log("Item touched");
        }
    }
}
