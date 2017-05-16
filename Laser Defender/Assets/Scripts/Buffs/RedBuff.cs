using UnityEngine;
using System.Collections;

public class RedBuff : MonoBehaviour {

	private float health = 250 ;
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();		
			if(health <= 0){
				Destroy(gameObject);
				PlayerController.redbuuf = true;
				
				
			}
		}
	}
}
