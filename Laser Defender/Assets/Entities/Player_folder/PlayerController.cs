using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject projectile;
	public GameObject smallrocket; 
	public GameObject bluerocket;
	public GameObject greenrocket;
	public GameObject hearth;
	
	public float speed = 15.0f;
	public float padding = 1f;
	float xmin;
	float xmax;
	public float projectileSpeed;
	public float firingRate;
	public static float health = 250;
	public static bool greenbuuf;
	public static bool redbuuf;
	public static bool bluebuuf;
	
	public AudioClip fireSound;
	public AudioClip playerDead;
	
	void Start(){
	greenbuuf = false;
	redbuuf = false;
	
	health = 250;
	float distance = transform.position.z - Camera.main.transform.position.z;	
	Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
	Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
	xmin = leftmost.x + padding;
	xmax = rightmost.x - padding;
	
	}
	
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,1,0);
		GameObject shot = Instantiate(projectile,startPosition,Quaternion.identity) as GameObject;	
		shot.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);	
		AudioSource.PlayClipAtPoint(fireSound,transform.position);	
	}
	void FireQ(){
		Vector3 startPosition = transform.position + new Vector3(0,1,0);
		GameObject shot = Instantiate(smallrocket,startPosition,Quaternion.identity) as GameObject;	
		shot.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);	
		AudioSource.PlayClipAtPoint(fireSound,transform.position);	
	}
	void FireW(){
		Vector3 startPosition = transform.position + new Vector3(0,1,0);
		GameObject shot = Instantiate(bluerocket,startPosition,Quaternion.identity) as GameObject;	
		shot.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);	
		AudioSource.PlayClipAtPoint(fireSound,transform.position);	
	}
	void FireE(){
		Vector3 startPosition = transform.position + new Vector3(0,1,0);
		GameObject shot = Instantiate(greenrocket,startPosition,Quaternion.identity) as GameObject;	
		shot.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);	
		AudioSource.PlayClipAtPoint(fireSound,transform.position);	
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){		
			transform.position += Vector3.left * speed * Time.deltaTime;		
		}else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		//restrict the player to the game space
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);	
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
		// normal shot	
		if(Input.GetKeyDown(KeyCode.Space)){
			
			InvokeRepeating("Fire",0.00001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		
		// Q shot - red rocket
		if(Input.GetKeyDown(KeyCode.Q)){
		if(redbuuf == true){
			InvokeRepeating("FireQ",0.00001f, firingRate);
			}
		}
		if(Input.GetKeyUp (KeyCode.Q)){
			CancelInvoke("FireQ");
		}
		
		// W shot - blue rocket
		
		if(Input.GetKeyDown(KeyCode.W)){
		if(bluebuuf == true){
			InvokeRepeating("FireW",0.00001f, firingRate);	
			}	
		}
		if(Input.GetKeyUp(KeyCode.W)){
			CancelInvoke("FireW");
		}
		
		// E shot - green rocket
		
		if(Input.GetKeyDown(KeyCode.E)){
		if(greenbuuf == true){
			InvokeRepeating("FireE",0.0001f, firingRate);	
			}	
		}
		if(Input.GetKeyUp(KeyCode.E)){
			CancelInvoke("FireE");
		}
		}
		
		
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
		Debug.Log("GITGITGTIGITG");
			health -= missile.GetDamage();
									
			missile.Hit();
				if(health <= 0){
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(playerDead,transform.position);
				Application.LoadLevel("Lose Screen");
			}
		}
	}	
		
		
		
		
}	

