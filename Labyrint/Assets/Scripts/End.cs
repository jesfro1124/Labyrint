using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Spel spel;

    private void OnTriggerEnter(Collider other)
    {
        spel.End();

    }
}
