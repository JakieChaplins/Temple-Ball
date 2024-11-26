using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] DeadPauseWinMenu Menu;
    [SerializeField] DoorScript Door;
    [SerializeField] PlacaPresion Placa;
    [SerializeField] PlacaPresion2 Placa2;
    [SerializeField] PlacaPresion0_2 Placa3;
    [SerializeField] PlacaPresion2_2 Placa4;

    public float speed = 0;
    public float jumpSpeed = 0;
    public TMP_Text CountText;
    public TMP_Text KeyText;
    public Transform respawnPoint;
    public Material Inmortal;
    public GameObject[] heartscontroller;

    private int heartscount;
    private int count;
    private int hearts;
    private bool Key;
    private bool istouching;
    private bool noDead = false;
    private Rigidbody rb;

    Renderer rend;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Key = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        hearts = 3;

        KeyText.text = "";
        SetCountText();
        heartscontroller[0].SetActive(false);
        heartscontroller[1].SetActive(false);
        heartscontroller[2].SetActive(true);
        heartscount = 2;
    }  
    
    void FixedUpdate ()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if((Input.GetKey(KeyCode.Space)) && istouching == true)
        {
            Vector3 balljump = new Vector3(0.0f, 6.0f, 0.0f); 

            rb.AddForce (balljump * jumpSpeed);         
        }

        istouching = false;

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            istouching = true;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            KeyText.text = ("¡¡You have the Key!!");
            Key = true;
        }
        if (other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);
            Menu.WinGame();
        }
        if (other.gameObject.CompareTag("GoomyBerry"))
        {
            other.gameObject.SetActive(false);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (other.gameObject.CompareTag("LembasBerry"))
        {
            other.gameObject.SetActive(false);
            noDead = true;
            rend.sharedMaterial = Inmortal;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            if (noDead == true)
            {

            }
            else
            {
                if (hearts > 1)
                {
                    Respawn();
                    Hearts();
                }
                else
                {
                    Hearts();
                    EndGame();
                    Respawn();
                }
            }
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            if (Key == true)
            {
                Door.OpenDoor();
            }
            else
            {
                KeyText.text = "You need a Key";
            }
        }
        if (collision.gameObject.CompareTag("Pression1"))
        {
            Placa.OpenDoor1();
            Placa3.PlacaDown1();
        }
        if (collision.gameObject.CompareTag("Pression2"))
        {
            Placa2.OpenDoor2();
            Placa4.PlacaDown2();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }


    void SetCountText()
    {
        CountText.text = "Coins " + count.ToString ();
        if (count >= 52)
        {
            CountText.text = "¡¡Gold King!!";
        }
    }

    void EndGame()
    {
        Menu.LoseGame();
    }

    public void Hearts()
    {
        if (heartscount > 0)
        {
            hearts--;
            heartscontroller[heartscount].SetActive(false);
            heartscount--;
            heartscontroller[heartscount].SetActive(true);
        }
        else
        {
            heartscontroller[heartscount].SetActive(false);
        }
    }
}
