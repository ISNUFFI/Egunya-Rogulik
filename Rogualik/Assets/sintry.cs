using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sintry : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    // Start is called before the first frame update
    void Start()
    {
        print("press f to pay respect");
    }
    double dg, dz;
    Vector3 hitPosition;
    // Update is called once per frame
    void Update()
    {
        // check if user has pressed some input keys
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

        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) //check if the ray hit something
        {
            hitPosition = hit.point; //use this position for what you want to do
        }

        dg = System.Math.Sqrt(System.Math.Pow(hitPosition.y - this.transform.position.x, 2) + System.Math.Pow(hitPosition.x - this.transform.position.y, 2));
        dz = hitPosition.x - this.transform.position.y;
        if (Input.GetKeyDown("f"))
        {
            print("dz = ");
            print(dz);
            print("dx = ");
            print(dg);
            print("z0 = ");
            print(this.transform.position.y);
            print("x0 = ");
            print(this.transform.position.x);
            print("z = ");
            print(hitPosition.y);
            print("x = ");
            print(hitPosition.x);
            print("sin = ");
            print(dz / dg);
            print("asin = ");
            print(System.Math.Asin(dz / dg) * (180 / System.Math.PI));
        }
    }

}