using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject spikewall;
    public GameObject Audio;
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            
            player = coll.gameObject;
            

            Destroy(spikewall.GetComponent<Rigidbody2D>()); //freeze
            Destroy(player.GetComponent<Rigidbody2D>()); //freeze

            Audio.GetComponent<AudioSource>().Stop();

            IEnumerator coroutine = TriggerEnd();
            StartCoroutine(coroutine);
        }
    }

    public IEnumerator TriggerEnd()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false; //hide platform
        yield return new WaitForSeconds(0.75f);
        spikewall.SetActive(false); //disable spikewall
        yield return new WaitForSeconds(1);
        player.SetActive(false); //disable player
        yield return new WaitForSeconds(0.3f);
        BlueScreenOfDeath.Instance.TriggerBSOD(); //trigger BSOD
    }
}
