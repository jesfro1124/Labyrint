using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float rotationstid = 2f;
    public Spel spel;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 360f*Time.deltaTime/rotationstid );
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        spel.CoinTagen();

    }
}
