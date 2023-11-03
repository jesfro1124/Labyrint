using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Spel : MonoBehaviour
{

    public GameObject[] blinkväggar;
    public float timeOut = 3f;
    private float timer = 0;
    private int coin = 0;
    public TextMeshProUGUI text;
    public GameObject panelStart;
    public GameObject panelEnd;
    public TextMeshProUGUI textEnd;
    public Gubbe gubbe;

    // Start is called before the first frame update
    void Start()
    {
        panelStart.SetActive(true);
        panelEnd.SetActive(false);
        gubbe.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeOut) {
            timer = 0;
            foreach (var blinkvägg in blinkväggar)
            {
                blinkvägg.SetActive(!blinkvägg.activeSelf);
            }
        }

        if (Input.GetAxis("Vertical") != 0) {
            panelStart.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CoinTagen()
    {
        coin ++;
        text.text = "Coins insamlade: " + coin;
    }

    public void End()
    {
        gubbe.enabled = false;
        textEnd.text = "Du lyckades samla in " + coin + " Coins!";
        panelEnd.SetActive(true);
    }
}
