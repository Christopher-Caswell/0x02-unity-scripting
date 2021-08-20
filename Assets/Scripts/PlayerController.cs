using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Start and update the Player
/// </summary>
public class PlayerController : MonoBehaviour
{
    public int health = 5;
    private int score = 0;
    public float speed = 5000f;
    public Rigidbody x;

    /// <summary>
    /// Hardbody setup
    /// </summary>
    void Start()
    {
        x = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health <= 0)
        {
            // SceneManager.LoadScene("GameOver");
            // wait(5)
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey("w"))
        {
            x.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            x.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            x.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            x.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Object.Destroy(other.gameObject);
        }

        if (other.GetComponent<Collider>().tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.GetComponent<Collider>().tag == "Goal")
        {
            Debug.Log("You Win!");
        }
    }
}
