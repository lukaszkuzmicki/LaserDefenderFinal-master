using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject enemyLevel2;
	public GameObject buffGreen;
	public GameObject buffRed;
	public GameObject buffBlue;
	
	public float width = 10f;
	public float height = 5f; 
	public float speed =5f;
	
	
	private bool movingRight = false;
	private float xmax;
	private float xmin;
	public float spawnDelay = 0.5f;	
	public bool buff = false;
	private int spawnCounter = 0;
	

	// Use this for initialization
	void Start () {
	buff = false;
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		xmax = rightBoundary.x;
		xmin = leftBoundary.x;
			
		SpawnUntilFull();
}
	
	 void SpawnEnemies(){
	
		foreach( Transform child in transform){			
				GameObject enemy = Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
				enemy.transform.parent = child;		

		}
	}
	
	void BuffRespawn(){
		//buff respawn
	if(spawnCounter == 10){
			buff = true;
		
			if(buff){
				buff = false;
				Vector3 startPosition = transform.position + new Vector3(0,0,0);
				GameObject missile = Instantiate(buffRed,startPosition,Quaternion.identity) as GameObject;	
			}
		}
	if(spawnCounter == 25){
		buff = true;
		
		if(buff){
			buff = false;
			Vector3 startPosition = transform.position + new Vector3(0,0,0);
			GameObject missile = Instantiate(buffBlue,startPosition,Quaternion.identity) as GameObject;	
		}
	}
	
		if(spawnCounter == 55){
			buff = true;
			
			if(buff){
				buff = false;
				Vector3 startPosition = transform.position + new Vector3(0,0,0);
				GameObject missile = Instantiate(buffGreen,startPosition,Quaternion.identity) as GameObject;	
			}
		}
	}	
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();		
		if(freePosition){
			if(ScoreKeeper.score < 1000){
				GameObject enemy = Instantiate(enemyPrefab,freePosition.position,Quaternion.identity) as GameObject;
				enemy.transform.parent = freePosition;
				spawnCounter++;	
				Debug.Log (spawnCounter);
				BuffRespawn();
			}
			else{
				spawnCounter++;	
				Debug.Log (spawnCounter);
				GameObject enemy = Instantiate(enemyLevel2,freePosition.position,Quaternion.identity) as GameObject;
				enemy.transform.parent = freePosition;
				BuffRespawn();
				
			}
		}
		if(NextFreePosition()){
			Invoke("SpawnUntilFull",spawnDelay);
		}
	}
	
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {
	if(movingRight){
		transform.position += new Vector3(speed*Time.deltaTime,0);
	}else{
		transform.position += new Vector3(-speed*Time.deltaTime,0);	
		}
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		
		if(leftEdgeOfFormation < xmin){
			movingRight = true;
		}else if(rightEdgeOfFormation > xmax){
			movingRight = false;
		}
	
		if(AllMembersDead()){
		Debug.Log("Empty formation");
		SpawnUntilFull();
		}
	}
	
	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		return null;	
		}
	
	
	
		public bool AllMembersDead(){
			foreach(Transform childPositionGameObject in transform){
				if(childPositionGameObject.childCount>0){
				return false;
				}
			}
		return true;
		}
}
