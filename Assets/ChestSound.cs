using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSound : MonoBehaviour
{

    [SerializeField] public GameObject currentChestModel;
    [SerializeField] public GameObject nextChestModel;
    public AudioClip chest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

 
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>().PlayOneShot(chest);
            currentChestModel.SetActive(false);
            nextChestModel.SetActive(true);
        }

    }

    private void OnCollisionExit(Collision collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>().PlayOneShot(chest);
            
        }

    }
}
