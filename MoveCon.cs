using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCon : MonoBehaviour
{
    [Header("Скорость")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private GameObject GG;
    Transform tr;
    CharacterController charactres;
    [Header("Прыжок")]
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float timeJump;
    [Header("Спринт")]
    [SerializeField] private float stamina;
    [SerializeField] private float staminaConsumption;
    [SerializeField] private float staminaRegeneration;
    [SerializeField] private float runSpeed;
    [Header("Отображение стамины")]
    [SerializeField] private GameObject showSt;
    private Rigidbody rb;
    private float height;
    private bool isJump;
    private bool isGrounded;
    private Image imSt;
    [SerializeField] private AudioClip sourceClip;
    [SerializeField] private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        tr = GG.GetComponent<Transform>();
        charactres = GG.GetComponent<CharacterController>();
        rb = GG.GetComponent<Rigidbody>();
        imSt = showSt.GetComponent<Image>();
    }
    private void FixedUpdate()
    {
        if (height <= 1 && isJump == false)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    float timeRun = 0;
    void Update()
    {
        
        Vector3 movement = Vector3.zero;
        bool running = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (audio.isPlaying == false)
            {
                audio.PlayOneShot(sourceClip);
            }

            running = true;
        }
        GG.GetComponent<Animator>().SetBool("IsRun", running);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            timeRun = 3;
        }

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 && timeRun <= 0)
        {
            stamina -= staminaConsumption *Time.deltaTime;
            movement = new Vector3(moveHorizontal, 0f, moveVertical) * runSpeed;
            
        }
        else
        {
            if (stamina <= 100)
            {
                stamina += staminaRegeneration * Time.deltaTime;
            }
           movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed;
            if (timeRun > 0)
                timeRun -= 1 * Time.deltaTime;
            else
                timeRun = 0;
        }


        if (!running)
        {
            audio.Stop();
        }
        imSt.fillAmount =  stamina/100; 
        movement = transform.TransformDirection(movement);


        #region Прыжок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isJump = true; 
            }
        }
        if (timeJump <= 0)
        {
            isJump = false;
            timeJump = 0.5f;
            height = 0;
        }
        if (isJump)
        {
            movement.y = 0 + jumpHeight * timeJump + ((1 / 2) * gravity * (timeJump * timeJump));
            timeJump -= Time.deltaTime;
           
        }
        else
        {
            height += (2 * (gravity / 2) / gravity);
            if (!charactres.isGrounded)
            {
                movement.y -= gravity * (2 * height / gravity); 
            }
            else
            {
                height = 0;
            }
        }


        #endregion






        charactres.Move(movement  * Time.deltaTime);
    }

   
}
