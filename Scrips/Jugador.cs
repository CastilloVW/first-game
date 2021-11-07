using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    

    public float runSpeed;
    public float rotationSpeed;

    public Animator animator;

    private float x, y;

    public Rigidbody rb;
    public BoxCollider bx;
    public float jumpHeight;

    bool floorDetectedd = false;

    public float jumpForce;

    public int FuerzaExtra;
    public float velCorrer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
    }

    // Update is called once per frame

    void Update()
    {




        //Maneja los movimientos del jugador

        jump();

    }
    void FixedUpdate()
    {




        //Maneja los movimientos del jugador
        movement(); 
        animationControl();
    }






    //All functions
    public void movement()
    {
        

        x = Input.GetAxis("Horizontal");

        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);


        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);




    }


    public void jump()
    {



        Vector3 floor = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, floor, 0.2f))
        {

            floorDetectedd = true;
            print("contacto");
            animator.SetBool("Suelo", true);

        }
        else
        {
            floorDetectedd = false;
            print("No hay contacto");
            animator.SetBool("Suelo", false);

        }


        if (Input.GetKeyDown(KeyCode.Space) && floorDetectedd)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            animator.Play("Jump");
        }


        rb.AddForce(FuerzaExtra * Physics.gravity);



    }


    public void Run()
    {
        rotationSpeed = 400;
        runSpeed = 6.0f;
    }

    public void Run2()

    {
        rotationSpeed = 300;
        runSpeed = 4.0f;
    }




    public void animationControl()
    {
        /*Animación de movimiento*/

        //Si presiono W o S y luego shift entonces Corro o atras
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (Input.GetKey(KeyCode.W))
            {

                animator.SetBool("Correr", true);
                Invoke("Run", 0.3f);

            }
            else if (Input.GetKey(KeyCode.S))
            {

                animator.SetBool("atras", true);
                Invoke("Run2", 0.3f);

            }

            else
            {
                rotationSpeed = 200;
                runSpeed = 2.0f;
                animator.SetBool("atras", false);
                animator.SetBool("Correr", false);
            }
        }

        //Si presiono shift y luego W entonces corro
        else if (Input.GetKeyDown(KeyCode.W))
        {

            if (Input.GetKey(KeyCode.P))
            {

                animator.SetBool("Correr", true);
                Invoke("Run", 0.3f);

            }
            else
            {
                rotationSpeed = 200;
                runSpeed = 2.0f;
                animator.SetBool("Correr", false);
            }
        }
        //Si persiono shift y luego S entonces corro hacia atras
        else if (Input.GetKeyDown(KeyCode.S))
        {

            if (Input.GetKey(KeyCode.P))
            {

                animator.SetBool("atras", true);
                Invoke("Run2", 0.7f);

            }
            else
            {
                rotationSpeed = 200;
                runSpeed = 2.0f;
                animator.SetBool("atras", false);
            }
        }


        if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rotationSpeed = 200;
            runSpeed = 2.0f;
            animator.SetBool("Correr", false);
            animator.SetBool("atras", false);

        }

        /*Animación de movimiento*/



        if (floorDetectedd)
        {
            animator.SetBool("Suelo", true);

        }
        else

        {
            animator.SetBool("Suelo", false);

        }







}
}
