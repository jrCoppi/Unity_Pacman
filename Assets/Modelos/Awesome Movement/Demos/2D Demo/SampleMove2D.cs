using System.Collections;
using UnityEngine;

public class SampleMove2D : MonoBehaviour
{
    public float Distance = 0;

    private Movement2D mvnt = null;

    private void Start()
    {
        mvnt = GetComponent<Movement2D>();
    }

    private void Update()
    {
        mvnt.MoveAlongX(Input.GetAxis("Horizontal") * Distance * Time.deltaTime);
        mvnt.MoveAlongY(Input.GetAxis("Vertical") * Distance * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			mvnt.SmoothGridMove(Vector2.right, Distance, false);
		}
    }
}