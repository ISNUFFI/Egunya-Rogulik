using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    public float speed;
    private Vector2 currentDirection = new Vector3(0.0f, 1.0f, 0.0f);
    private Transform transformObj;
    private Vector2 currentDir;
    // Start is called before the first frame update
    void Start()
    {
        transformObj = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {

            // convert user input into world movement
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

            //assign movement to a single vector3
            Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);

            // apply movement to player's transform
            gameObject.transform.Translate(directionOfMovement);
        }
        //Look at Mouse
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 objPos = transform.position;

            Vector2 direction = mousePos - objPos;

            direction.Normalize();

            currentDirection = Vector2.Lerp(currentDirection, direction, Time.deltaTime * speed);
            transformObj.up = currentDirection;
            //var addAngle = 270;
            //var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        
        
    }

}
