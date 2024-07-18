using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


interface Interactable
{
    public void Interact();
}

public class Interaction : MonoBehaviour
{
    public AudioClip bite;
    public AudioClip slurp;
    public AudioClip chest;

    [SerializeField] public GameObject currentChestModel;
    [SerializeField] public GameObject nextChestModel;
    [SerializeField] public GameObject cupFull;
    [SerializeField] public GameObject cup;
    [SerializeField] public GameObject lemon;
    [SerializeField] public GameObject lemonBite;

    public Transform InteracterSource;
    private void Start()
    {
        nextChestModel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            
            RaycastHit hit;
            if (Physics.Raycast(InteracterSource.position, InteracterSource.forward, out hit, 10))
            {   
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Lemon")
                {
                    Debug.Log("Lemon");
                    Destroy(hit.collider.gameObject);
                    Instantiate(lemonBite, hit.collider.transform.position, hit.collider.transform.rotation);
                    gameObject.GetComponent<AudioSource>().PlayOneShot(bite);
                }

                if (hit.transform.tag == "LemonBite")
                {
                    Debug.Log("LemonBite");
                    gameObject.GetComponent<AudioSource>().PlayOneShot(bite);
                    Destroy(hit.collider.gameObject);
                }
                if (hit.transform.tag == "CupFull")
                {
                    Debug.Log("CupFull");
                    gameObject.GetComponent<AudioSource>().PlayOneShot(slurp);
                    Destroy(hit.collider.gameObject);
                    Instantiate(cup, hit.collider.transform.position, hit.collider.transform.rotation);
                }
                
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("collision");
        if (collision.gameObject.tag == "Chest")
        {
            this.GetComponent<AudioSource>().PlayOneShot(chest);
            Invoke("changeChest", 0.2f);
            
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
       
        if (collision.transform.tag == "ChestOpen")
        {
            this.GetComponent<AudioSource>().PlayOneShot(chest);
            Invoke("changeChestBack", 0.2f);
        }
    }
    private void changeChest()
    {
        Debug.Log("Chest changed");
        
        currentChestModel.SetActive(false);
        nextChestModel.SetActive(true);
        gameObject.GetComponent<AudioSource>().PlayOneShot(chest);

    }

    private void changeChestBack()
    {
        Debug.Log("Chest changed");
       
        currentChestModel.SetActive(true);
        nextChestModel.SetActive(false);
        gameObject.GetComponent<AudioSource>().PlayOneShot(chest);

    }

}





// you uhh gotta probably make it so when you look at an interactible it shows up like 'press e' or sum shit you can do that prob 
// by checking the tag of a thing you're looking at.
//
// idk how to do the text tho google that, then change it to a diff gameobjectso we dont gotta write 3 scripts for 3 things 
// just drag a diff gameobject in.
//
// for the lemon tho idk how to make it disappear without a different script, probably just a diff function :)
//
// thats just what i think you dont gotta follow this <3