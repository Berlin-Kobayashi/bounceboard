using UnityEngine;
using System.Collections;
using SVGImporter;

public class Background : MonoBehaviour {

    // dependencies
    public Transform obstaclePrefab;

    int seconds = 1;
	int maxSeconds = 6;
    int spawnObstacleSeconds = 5;
	Color original;

	void Start() {
		// change behaviour every 2 seconds
		InvokeRepeating("ChangeSecondInterval", maxSeconds, maxSeconds);
		InvokeRepeating("Tick", seconds, seconds);
        InvokeRepeating("SpawnObstacle", spawnObstacleSeconds, spawnObstacleSeconds);
        original = this.GetComponent<SVGRenderer>().color;
	}
	
	void ChangeSecondInterval() {
		seconds = Random.Range(1, maxSeconds);
		CancelInvoke("Tick");
		InvokeRepeating("Tick", seconds, seconds);
	}
	
	void Tick() {
		Color lerping = Color.Lerp(this.RandomColor(), original,  0.6F);
		this.GetComponent<SVGRenderer>().color = lerping;
	}
	
	Color RandomColor() {
		return new Color(Random.value, Random.value, Random.value);
    }

    void SpawnObstacle()
    {
        Transform obstacle = (Transform)Instantiate(obstaclePrefab, new Vector2(7,-4), Quaternion.identity);
        obstacle.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10,0) * Time.deltaTime * 1000, ForceMode2D.Force);
    }
}
