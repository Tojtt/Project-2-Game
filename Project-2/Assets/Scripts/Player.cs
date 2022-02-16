using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player_variables
    public bool hasTreasure;
    public float size;
	#endregion

	#region Movement_variables
	public float movespeed;
	float x_input;
	float y_input;
	Vector2 curDir;
	#endregion

	#region Physics_components
	Rigidbody2D PlayerRB;
    #endregion

    void Awake()
    {
		PlayerRB = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
		// movement
		x_input = Input.GetAxisRaw("Horizontal");
		y_input = Input.GetAxisRaw("Vertical");
		Move();
		// grow size of Player
	}

	#region Movement_funcs
	private void Move()
	{
		//anim.SetBool("Moving", true);

		if (x_input > 0)
		{
			PlayerRB.velocity = Vector2.right * movespeed;
			curDir = Vector2.right;
		}
		else if (x_input < 0)
		{
			PlayerRB.velocity = Vector2.left * movespeed;
			curDir = Vector2.left;
		}
		else if (y_input > 0)
		{
			PlayerRB.velocity = Vector2.up * movespeed;
			curDir = Vector2.up;
		}
		else if (y_input < 0)
		{
			PlayerRB.velocity = Vector2.down * movespeed;
			curDir = Vector2.down;
		}
		else
		{
			PlayerRB.velocity = Vector2.zero;
			//anim.SetBool("Moving", false);
		}

		//anim.SetFloat("DirX", currDirection.x);
		//anim.SetFloat("DirY", currDirection.y);
	}

    #endregion

    #region Misc_funcs
	public void IncreaseSize()
    {
		Vector3 original = this.transform.localScale;
		this.transform.localScale = new Vector3(original.x + 1, original.y + 1, original.z);
		size += 1;
	}

    #endregion

}
