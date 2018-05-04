using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    private float defaultSpeed;
    private Rigidbody2D rb2d;
    private Animator param;
    public AudioSource audio;

    public void ChangeSpeed(float speedChange)
    {
        speed = defaultSpeed + speedChange;
        Debug.Log("bsssss");
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        param = GetComponent<Animator>();
        defaultSpeed = speed;
    }

    private void FixedUpdate()
    {
        //mouse control
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        rb2d.angularVelocity = 0;

        //Movement for vertical/horizotal axis
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            param.SetBool("isMoving", true);
            if (audio.isPlaying == false)
            audio.Play();
        }

        else
        {
            param.SetBool("isMoving", false);
            audio.Stop();
        }
        
    }

    public IEnumerator SpeedBoostF(float[] values)
    {
        //values[0] - speed difference, values[1] - execution time
        speed = defaultSpeed + values[0];
        yield return new WaitForSeconds(values[1]);
        speed = defaultSpeed;
    }

}
