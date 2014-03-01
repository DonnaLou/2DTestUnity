using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Camera mainCam;
	public BoxCollider2D WallBottom;
	public BoxCollider2D WallRight;
	public BoxCollider2D WallTop;
	public BoxCollider2D WallLeft;
	
	
	void Start () {
		WallTop.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		WallTop.center = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);
		
		WallBottom.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		WallBottom.center = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);
		
		WallLeft.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		WallLeft.center = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, 0f);
		
		WallRight.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3( 0f, Screen.height * 2f, 0f)).y);
		WallRight.center = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x, 0f);
	}
}
