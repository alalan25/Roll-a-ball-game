using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text afterGameText;
    float horizontalSpeed = 9.0f;
    float verticalSpeed = 9.0f;
    public float WaitTime = 2.0f;

    void Start()
    {
    rb = GetComponent<Rigidbody>();
        setCount();
        afterGameText.text = "";
    }

    private void Instantiate(object pickup_capsule, Vector3 vector3, object rotation)
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()  // render this while using physics in our project
    {
        float moveHorizontal = horizontalSpeed * Input.GetAxis("Horizontal");
        float moveVertical = verticalSpeed * Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collision"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCount();
        }
        else if (other.gameObject.CompareTag("collision1"))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
            setCount();
        }
        else if(other.gameObject.CompareTag("collision2"))
        {
            other.gameObject.SetActive(false);
            count = count + 3;
            setCount();
        }
    }

    void setCount()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 19)
        {
            afterGameText.text = "You won, Now play again!";

            StartCoroutine(Restart());


        }
        

        
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5); //delay program for 5 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restart scene
    }
    

}
