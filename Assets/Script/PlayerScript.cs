using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private int CoinCount;
    public Text CoinText;
    public int CoinAmount;

    public Text TimerText;
    public float TimerCount;

    public GameObject CoinParticle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount -= Time.deltaTime;   

        TimerText.text = "Time Left: " + TimerCount.ToString("F2");

        if (TimerCount <= 0)
        {
            //LockCursor(false);
            SceneManager.LoadScene("GameLose");
        }
        else if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            //LockCursor(false);
            SceneManager.LoadScene("GameWin");
        }

        //print("Status: " + UnityStandardAssets.Characters.FirstPerson.MouseLook.m_cursorIsLocked);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            CoinCount += CoinAmount;
            CoinText.text = "Score: " + CoinCount;
            Instantiate(CoinParticle, other.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.tag == "Water")
        {
            //LockCursor(false);
            SceneManager.LoadScene("GameLose");
        }
    }
    /*public void LockCursor(bool state)
    {
        UnityStandardAssets.Characters.FirstPerson.MouseLook.m_cursorIsLocked = state;
    }
    */
}
