using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject Chest, Tip;
    
  
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenChest()
    {
        Tip.SetActive(false);
        gameObject.SetActive(false);
        Invoke("SetFirstAnim", 0);
        Invoke("SetSecondAnim", 1);
    }

   private void SetFirstAnim()
    {
        Chest.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("chest_almost_opened");
    }

    private void SetSecondAnim()
    {
        Chest.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("chest_opened");
    }
}
