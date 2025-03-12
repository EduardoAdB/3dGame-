using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator controle;


    private void Start()
    {
        controle.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            controle.SetBool("Forward", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            controle.SetBool("Forward", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            controle.SetBool("Backward", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            controle.SetBool("Backward", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            controle.SetBool("Leftward", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            controle.SetBool("Leftward", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            controle.SetBool("Rightward", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            controle.SetBool("Rightward", false);
        }

    }
}
