using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [SerializeField] private int count;
    [SerializeField] private float speed = 0.0f;
    public TextMeshProUGUI countText;
    public AudioSource collectedSound;
    public GameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = count.ToString() + "/12";
    }

    void FixedUpdate()
    {
        Vector3 movement =  new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            collectedSound.Play();
            other.gameObject.SetActive(false);
            count++;
            collectedSound.Play();
            SetCountText();
            if (count >= 12)
            {
                this.gameObject.SetActive(false);
                manager.VictoryScreen();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Death();
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

}
