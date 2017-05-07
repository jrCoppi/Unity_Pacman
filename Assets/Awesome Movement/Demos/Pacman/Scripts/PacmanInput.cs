using System.Collections;
using UnityEngine;

//this script will handle the pacman input
//unlike the modern movement it's not grid based.
//based on keys and movement direction we set horizontal and vertical speeds along x axis and z axis and then apply the movement in last line of Update()
//it's like the old SEGA genisis version of the game
[RequireComponent(typeof(Movement))]
class PacmanInput : MonoBehaviour
{
	public float speed = 5; //movement speed

	private enum Direction { left, right, up, down, none }; //movement direction
	private Direction currentDirection = Direction.none; //current movement direction
	private Movement movement; //reference to the real movement component
	private float verSpeed; //vertical speed
	private float horSpeed; //horizontal speed
	private bool controllable = true; //is pacman controlable or not

	//pause function. we use this for cutscenes and game pause
	public void Pause()
	{
		controllable = false;
	}

	//resume function
	public void UnPause()
	{
		controllable = true;
	}

	void Start()
	{
		currentDirection = Direction.none;
		movement = GetComponent<Movement>(); //cache the movement component
	}

	void Update()
	{
		if (!controllable) return; //if we are not allowed to do anything so let's go away. the game is paused or we are in a cutscene
		//for now just do some movement
		if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) //if right key is pressed and left is not pressed
		{
			if (currentDirection != Direction.right && movement.CanMoveTo(1, 0, 0)) //check if we are not already moving toward right direction and movement to right is possible
			{
				currentDirection = Direction.right; //change the direction
				//set horspeed and verspeed to correct values for moving to right direction
				horSpeed = speed;
				verSpeed = 0;
			}
		}
		//others are same as right but with their own keys and directions
		if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
		{
			if (currentDirection != Direction.left && movement.CanMoveTo(-1, 0, 0))
			{
				currentDirection = Direction.left;
				horSpeed = -speed;
				verSpeed = 0;
			}
		}
		if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
		{
			if (currentDirection != Direction.up && movement.CanMoveTo(0, 0, 1))
			{
				currentDirection = Direction.up;
				verSpeed = speed;
				horSpeed = 0;
			}
		}
		if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
		{
			if (currentDirection != Direction.down && movement.CanMoveTo(0, 0, -1))
			{
				currentDirection = Direction.down;
				verSpeed = -speed;
				horSpeed = 0;
			}
		}
		//now let's apply the horizontal and vertical movements.
		movement.Move(horSpeed * Time.deltaTime, 0, verSpeed * Time.deltaTime);
	}

}