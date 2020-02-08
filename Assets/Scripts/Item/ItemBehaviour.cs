using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ItemBehaviour : MonoBehaviour
{
    public readonly int   score   = 10;
    public float lifeSpan { get; private set; } = 12.0f;
    
    public ItemBehaviour(int score, float lifeSpan) {
        this.score    = score;
        this.lifeSpan = lifeSpan;
    }
    
    private IEnumerator CountLifeSpan() {
        yield return new WaitForSeconds(lifeSpan);
        // Send Message to the GameMaster
        ItemManager.Instance.ItemRemoved(this.gameObject);
    }
    // player got the item
    public abstract void OnItemGet();
    
    private void Start() {
        var autoRemove = CountLifeSpan();
        StartCoroutine(autoRemove);
    }
    
}

public class NutritionItem : ItemBehaviour {
    public NutritionItem(int score, float lifeSpan) : base(score, lifeSpan) {
        
    }
    public override void OnItemGet() {
        
    }
}
