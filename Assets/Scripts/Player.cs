using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

 
	
	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "EnemyShape") {
           
                GameMaster.LoseLife(this);
            }
        }

    
}
