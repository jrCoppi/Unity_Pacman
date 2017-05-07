using System.Collections;
using UnityEngine;

//this script will move the pacman one unit cell in grid with each key press
//this is like the playstation version of the pacman game.
[RequireComponent(typeof(Movement))] //Movement component does the real ray tracing and movement
internal class ModernPacmanInput : MonoBehaviour
{
	//public AnimationClip eatingAnimation;
	public float speed = 5; //speed of the pacman movement

	private enum Direction { left, right, up, down, none }; //enum for the direction of movement

	private Direction currentDirection = Direction.none; //current direction of movement
	private Movement movement; //movement component's reference
	private bool controllable = true; //can pacman be controlled by keys at this time or not

	private void Start()
	{
		currentDirection = Direction.none;
		movement = GetComponent<Movement>(); //caching the reference to movement component for fast access
	}

	//pause the pacman
	public void Pause()
	{
		controllable = false;
	}

	//resume the pacman
	public void UnPause()
	{
		controllable = true;
	}

	private void Update()
	{
		if (!controllable) return; //if we should not respond to keyboard so let's go out
		if (movement.isMovingUsingSmoothMove == false) //if we are not inside a movement.
		{
			//respond to key presses
			if (Input.GetKey(KeyCode.UpArrow))
			{
				if (MoveSmoothly(0, 0, 1, speed))
				{
					currentDirection = Direction.up; //if we changed direction of movement so this variable should be changed to.
					transform.rotation = Quaternion.Euler(0, 180, 0);
				}
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				if (MoveSmoothly(0, 0, -1, speed))
				{
					currentDirection = Direction.down;
					transform.rotation = Quaternion.Euler(0, 0, 0);
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				if (MoveSmoothly(1, 0, 0, speed))
				{
					currentDirection = Direction.right;
					transform.rotation = Quaternion.Euler(0, 270, 0);
				}
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				if (MoveSmoothly(-1, 0, 0, speed))
				{
					currentDirection = Direction.left;
					transform.rotation = Quaternion.Euler(0, 90, 0);
				}
			}
		}
	}

	//this function will move the pacman toward current direction.
	//in this way users can easily hold the key of their turning direction an   d move till riching the turn place
	//we call this function when we can not move to the new requested direction to continue movement based on the current movement direction.
	private void ContinueMoving()
	{
		if (currentDirection == Direction.up && movement.CanMoveTo(0, 0, 1))
		{
			StartCoroutine(movement.SmoothGridMoveCoroutine(new Vector3(0, 0, 1), speed, false));
		}
		else if (currentDirection == Direction.down && movement.CanMoveTo(0, 0, -1))
		{
			StartCoroutine(movement.SmoothGridMoveCoroutine(new Vector3(0, 0, -1), speed, false));
		}
		else if (currentDirection == Direction.right && movement.CanMoveTo(1, 0, 0))
		{
			StartCoroutine(movement.SmoothGridMoveCoroutine(new Vector3(1, 0, 0), speed, false));
		}
		else if (currentDirection == Direction.left && movement.CanMoveTo(-1, 0, 0))
		{
			StartCoroutine(movement.SmoothGridMoveCoroutine(new Vector3(-1, 0, 0), speed, false));
		}
	}

	//a nice wrapper to call the real movement function if possible.
	//if not possible it will call ContinueMoving() to move along the current direction if possible
	//this will allow a good gameplay. user can hold up when moving to right and he will continue moving to right
	//as soon as moving to up is possible it will change it's direction.
	private bool MoveSmoothly(float x, float y, float z, float speed)
	{
		if (movement.CanMoveTo(x, y, z))
		{
			StartCoroutine(movement.SmoothGridMoveCoroutine(new Vector3(x, y, z), speed, false));
			return true;
		}
		else
		{
			ContinueMoving();
			return false;
		}
	}
}