using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour{

	public GameObject projectile;	
	public float health = 150f;
	public float projectileSpeed = 5;
	public float shotPerSeconds = 0.5f;
	public int scoreValue = 150;
	
	private ScoreKeeper scoreKeeper;
	public AudioClip enemyDead;
	public AudioClip enemyFire;
	
	void Start(){	
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	


	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			PlayerHealth.UpdateHP();
				
			if(health <= 0){
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(enemyDead,transform.position);
				scoreKeeper.Score(scoreValue);
			
			}
		}
	}
	
	
	public void Update(){
	
	float probability = Time.deltaTime * shotPerSeconds;
	if(Random.value < probability){	Fire();}			
	}
	
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,-1,0);
		GameObject missile = Instantiate(projectile,startPosition,Quaternion.identity) as GameObject;	
		missile.rigidbody2D.velocity = new Vector2(0,-projectileSpeed);	
		AudioSource.PlayClipAtPoint(enemyFire,transform.position);
	}
	
}
