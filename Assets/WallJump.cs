using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {
    CharacterController2D movement;
    public float wallSlideSpeedMax = 3;
	// Use this for initialization
	void Start () {
        movement = GetComponent<CharacterController2D>();
	}
    private void Update()
    {
        bool wallSliding = false;
        if (movement.GetComponent<Collider2D>() != null && movement.m_Velocity.y < 0)
        {
            wallSliding = true;
            if(movement.m_Velocity.y < -wallSlideSpeedMax)
            {
                movement.m_Velocity.y = -wallSlideSpeedMax;
            }
        }
    }
}
