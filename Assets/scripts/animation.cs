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


    }
}
