using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNiceTry : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    // Start is called before the first frame update
    void Start()
    {
        print("press f to pay respect");
    }
    double dx, dz, dg;
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

        // длина гепотинузы
        dg = System.Math.Sqrt(System.Math.Pow(hitPosition.y - this.transform.position.x, 2) + System.Math.Pow(hitPosition.x - this.transform.position.y, 2));
        // длина вектора прилежащего катета
        dx = hitPosition.y - this.transform.position.x;
        // длина вектора протеволежащего катета
        dz = hitPosition.x - this.transform.position.y;
        //if (Input.GetKeyDown("f")) {
        //    print("dz = ");
        //    print(dz);
        //    print("dx = ");
        //    print(dx);
        //    print("z0 = ");
        //    print(this.transform.position.y );
        //    print("x0 = ");
        //    print(this.transform.position.x );
        //    print("z = ");
        //    print(hitPosition.y);
        //    print("x = ");
        //    print(hitPosition.x);
        //    print("tan = ");
        //    print(dz / dx);
        //    print("atan = ");
        //    print(System.Math.Atan(dz / dx)*(180/System.Math.PI));
        //}

        /**
        * если sin > 0 и tan > 0 то 90 - asin + 90
        * если sin > 0 и tan < 0 то asin
        * если sin < 0 и tan > 0 то asin
        * если sin < 0 и tan < 0 то -90 - - asin - 90
        */
        double sinus = dz / dg, tangens = dz / dx,
        asinus = System.Math.Atan(dz / dg) * (180 / System.Math.PI), atangens = System.Math.Atan(dz / dx) * (180 / System.Math.PI);
        double rotate = 0;
        if (sinus > 0 && tangens > 0)
        {
            rotate = 90 - asinus + 90;
        }
        else if (sinus > 0 && tangens < 0)
        {
            rotate = asinus;
        }
        else if (sinus < 0 && tangens > 0) {
            rotate = asinus;
        }
        else if (sinus < 0 && tangens < 0)
        {
            rotate = -90 + asinus - 90;
        }
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z + System.Convert.ToSingle(rotate)
        );
    }

}