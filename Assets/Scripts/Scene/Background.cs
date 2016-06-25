using UnityEngine;
using System.Collections;
using SVGImporter;

public class Background : MonoBehaviour {

	int seconds = 1;
	int maxSeconds = 6;
	Color original;

	void Start() {
		// change behaviour every 2 seconds
		InvokeRepeating("ChangeSecondInterval", maxSeconds, maxSeconds);
		InvokeRepeating("Tick", seconds, seconds);
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
}
