using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour



{
    public GameObject correctForm;
    private bool moving;
    private bool finish;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);

            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (!finish)
        {
            if (Mathf.Abs(this.transform.position.x - correctForm.transform.position.x) <= 0.5f &&
                Mathf.Abs(this.transform.position.y - correctForm.transform.position.y) <= 0.5f)
            {
                this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
                finish = true;
            }
            else
            {
                this.transform.position = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
            }
        }
        else // Als finish true is, betekent dit dat het object al op zijn plaats is en kan worden verwijderd.
        {
            RemoveClothing();
        }
    }

    private void RemoveClothing()
    {
        finish = false;
        // Reset de positie van het object
        this.transform.position = resetPosition;
        // Optioneel: Voer hier extra logica uit voor het verwijderen van kledingstukken, zoals het uitschakelen van het spelobject.
        // gameObject.SetActive(false);
    }
}