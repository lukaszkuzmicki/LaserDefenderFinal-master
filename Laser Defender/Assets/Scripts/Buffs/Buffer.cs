using UnityEngine;
using System.Collections;

public class Buffer : MonoBehaviour {
private float health = 100 ;
	
void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();		
			if(health <= 0){
				Destroy(gameObject);
				PlayerController.greenbuuf = true;
							
				asdasd
			}
		}
	}
	
}
