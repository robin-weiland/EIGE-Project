using UnityEngine;

public class PlayerMove : PlayerCommand
{
    private bool facingLeft = true;
    public override void run(PlayerManager player)
    {
        float speed = player.properties.movementSpeed * Input.GetAxis("Horizontal");

        player.transform.Translate(Vector2.right * speed);
        //Animations
        player.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(speed)*10);
        if (Input.GetAxis("Horizontal") > 0 && facingLeft == false){
            facingLeft = true;
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0&& facingLeft == true) {
            facingLeft = false;
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
