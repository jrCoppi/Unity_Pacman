using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectLocation : MonoBehaviour {
	
	private float latitude, longitude, oldLatitude = 0, oldLongitude = 0;
	private bool enableByRequest = true;
	private int maxWait = 10;
	public Text text;

	void Start(){
	}

	private void getLocation(){
		LocationService service = Input.location;
		if (!enableByRequest && !service.isEnabledByUser) {
			Debug.Log("Location Services not enabled by user");
		}
		service.Start(0.00001f,0.00001f);
		while (service.status == LocationServiceStatus.Initializing && maxWait > 0) {
			maxWait--;
		}
		if (maxWait < 1){
			Debug.Log("Timed out");
		}
		if (service.status == LocationServiceStatus.Failed) {
			Debug.Log("Unable to determine device location");
		} else {
			latitude = service.lastData.latitude;
			longitude = service.lastData.longitude;
			maxWait = 10;
		}
		service.Stop();
	}


	void Update(){
		getLocation ();
		startCalculate ();
	}


	public void startCalculate(){
		text.text = "Location: " + latitude.ToString() + ", " + longitude.ToString();
		Vector2 oldCoordinates = new Vector2(oldLatitude, oldLongitude);
		Vector2 deviceCoordinates = new Vector2(latitude, longitude);
		float distance = Vector2.Distance(oldCoordinates,deviceCoordinates);
		float distanceFrom = 0.00001f;
		if (distance >= distanceFrom) {
			text.text = text.text + "\nDistance: " + distance.ToString();
			text.text += "\nAndou";
			oldLatitude = latitude;
			oldLongitude = longitude;
		} else {
			text.text = text.text + "\nDistance: " + distance.ToString();
			text.text += "\nNão andou";
		}
	}
}
