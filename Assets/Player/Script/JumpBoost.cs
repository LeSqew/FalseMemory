using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMoveController player;
    public int Boost = 2;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump Boost")
        {
            player.JumpForce *= Boost;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump Boost")
        {
            player.JumpForce /= Boost;
        }
    }
}
