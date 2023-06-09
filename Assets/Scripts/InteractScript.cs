using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [Header("Doors")]
    private bool doorIsOpen = false;
    public GameObject openText;
    public AudioSource doorCreak;

    [Header("Movable")]
    private bool isInPlace = true;
    public GameObject moveText;

    [Header("Easter Egg")]
    public GameObject waterPlantText;

    [Header("Lights")]
    public GameObject darkText;
    public GameObject atticHatch;
    public GameObject WClight;

    public GameObject flashlight;
    public GameObject foundFlashlightText;

    [Header("Attic")]
    public Animator cameraPullback;
    public GameObject bossEnemy;
    public GameObject openHatchText;
    private bool hatchIsOpen = false;
    private bool flashlightFound = false;
    public GameObject bossHealthMeter;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && flashlightFound)
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Movable"))
        {
            if (isInPlace)
            {
                moveText.SetActive(true);

                if (Input.GetKey(KeyCode.Return))
                {
                    other.transform.Translate(new Vector3(-1.5f, 0, 0));
                    moveText.SetActive(false);
                    isInPlace = false;
                }
            }
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (!doorIsOpen)
            {
                openText.SetActive(true);

                if (Input.GetKey(KeyCode.Return))
                {
                    other.transform.eulerAngles = new Vector3(0, -100f, 0);
                    doorCreak.Play();
                    openText.SetActive(false);
                    Destroy(other.GetComponent<Collider>());
                }
            }
        }

        if (other.gameObject.CompareTag("Hatch") && !hatchIsOpen)
        {
            openHatchText.SetActive(true);

            if (Input.GetKey(KeyCode.Return))
            {
                atticHatch.transform.eulerAngles = new Vector3(70, 0, 0);
                hatchIsOpen = true;
                doorCreak.Play();
                openHatchText.SetActive(false);
            }
        }


        if (other.gameObject.CompareTag("DarkTrigger") && !flashlightFound)
        {
            darkText.SetActive(true);
        }

        if (other.gameObject.CompareTag("WCEnemy"))
        {
            WClight.SetActive(true);
        }

        if(other.gameObject.CompareTag("Plant"))
        {
            waterPlantText.SetActive(true);
        }

        if (other.gameObject.CompareTag("Flashlight"))
        {
            foundFlashlightText.SetActive(true);
            flashlightFound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        moveText.SetActive(false);
        openText.SetActive(false);
        darkText.SetActive(false);
        waterPlantText.SetActive(false);

        if (other.gameObject.CompareTag("DarkTrigger") && flashlightFound)
        {
            Instantiate(bossEnemy);
            bossHealthMeter.SetActive(true);
            cameraPullback.SetTrigger("Boss");
            atticHatch.transform.eulerAngles = new Vector3(0, 0, 0);
            doorCreak.Play();
            hatchIsOpen = false;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Flashlight"))
        {
            foundFlashlightText.SetActive(false);
            Destroy(other.gameObject);
        }

    }
}
