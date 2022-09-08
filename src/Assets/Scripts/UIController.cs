using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static int health, coins;
    public GameObject Heart1, Heart2, Heart3, Key;
    public Text CoinCounter;
    private PlayerController pc;
    public GameObject Player;
    public Text DeathText;
    public Text WinText;
    public GameObject Shade;
    public GameObject UI, Coin;
    
    
    void Start()
    {
        pc = Player.GetComponent<PlayerController>();
        health = pc.Health;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        coins = pc.Coins;
        CoinCounter.text = $"x{coins}";
    }

    void Update()
    {
        health = pc.Health;
        coins = pc.Coins;
        switch (pc.GotKey)
        {
            case true:
                Key.SetActive(true);
                break;
            case false:
                Key.SetActive(false);
                break;
        }
        switch (health)
        {
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                break;
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;
            default:
                break;
        }
        CoinCounter.text = $"x{coins}";
    }

    public void SetWinText()
    {
        pc.IsWon = true;
        UI.SetActive(false);
        Coin.SetActive(false);
        StartCoroutine(shadeTransparency(255, 500));
        WinText.text = $"Победа!\n\nВы собрали {pc.Coins} монет(-ы)\n\nНажмите R чтобы попробовать еще раз или Escape чтобы выйти";
        StartCoroutine(textTransparency(WinText, 255, 500));
    }

    public void SetDeathText()
    {
        UI.SetActive(false);
        Coin.SetActive(false);
        StartCoroutine(shadeTransparency(255, 500));
        StartCoroutine(textTransparency(DeathText, 255, 500));
    }

    IEnumerator shadeTransparency(float value, float time)
    {
        SpriteRenderer sr = Shade.GetComponent<SpriteRenderer>();
        float k = 0.0f;
        Color c0 = sr.color;
        Color c1 = c0;
        c1.a = value;

        while ((k += Time.deltaTime) <= time)
        {
            sr.color = Color.Lerp(c0, c1, k / time);

            yield return null;
        }

        sr.color = c1;
        pc.gameObject.SetActive(false);
    }

    IEnumerator textTransparency(Text text, float value, float time)
    {
        float k = 0.0f;
        Color c0 = text.color;
        Color c1 = c0;
        c1.a = value;

        while ((k += Time.deltaTime) <= time)
        {
            text.color = Color.Lerp(c0, c1, k / time);

            yield return null;
        }

        text.color = c1;
    }
}
