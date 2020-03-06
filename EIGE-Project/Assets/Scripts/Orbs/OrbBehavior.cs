using System.Collections;
using UnityEngine;

public class OrbBehavior : MonoBehaviour
{
    public OrbMechanic mechanic;

    [SerializeField]
    public OrbType type = OrbType.NoEffect;
    private bool pickedUp = false;
    private bool playerInRange = false;
    private PlayerManager currentPlayer;

    public AudioSource audiosrc;
    public AudioClip clip;
    public PedestalBehavior currentPedestal;

    private int current = 20;
    [SerializeField]
    private int cooldown = 5;

    [Header("Mechanic References")]
    [SerializeField]
    public GameObject dashArrow;
    [SerializeField]
    public LayerMask dashAnchor;
    [SerializeField]
    public GameObject dashField;
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public GameObject hook;
    [SerializeField]
    public ParticleSystem gravityParticles;

    // Start is called before the first frame update
    void Start()
    {
        mechanic = OrbMechanic.GetOrbMechanic(type, this);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current > 0) current--;
        if (!pickedUp) {
            if (Input.GetButtonDown("Interact") && playerInRange && current == 0 && currentPlayer.properties.currentOrb == null)
            {
                //Sound
                if (!audiosrc.isPlaying)
                {
                    Debug.Log(audiosrc.clip + "hi");
                    audiosrc.clip = clip;
                    audiosrc.PlayOneShot(clip, 0.8f);
                }
                // Drop
                CameraBehavior.Shake(0.4f, 0.25f);
                currentPlayer.properties.currentOrb = this;
                // Disable orb
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                foreach (Transform child in transform)
                    child.gameObject.SetActive(false);
                // UI
                if (currentPlayer.orbUI != null)
                {
                    currentPlayer.orbUI.loadMechanic(type);
                    currentPlayer.orbUI.setActive();
                    currentPlayer.orbUI.setFillStatus(0);
                }
                // Event
                mechanic.onPickup(currentPlayer);
                current = cooldown;
                pickedUp = true;
                if (currentPedestal != null)
                {
                    currentPedestal.onOrbRemove(this);
                    currentPedestal.hasOrb = false;
                    currentPedestal = null;
                }
            }
        }
    }
    public void drop(PedestalBehavior pedestal)
    {
        if (pickedUp && current == 0)
        {
            if (!audiosrc.isPlaying)
            {
                Debug.Log(audiosrc.clip + "hi");
                audiosrc.clip = clip;
                audiosrc.PlayOneShot(clip, 1);
            }
            CameraBehavior.Shake(0.4f, 0.25f);
            mechanic.onDrop(currentPlayer);
            pedestal.onOrbAdd(this);
            currentPlayer.properties.currentOrb = null;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            pickedUp = false;
            current = cooldown;
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
            currentPedestal = pedestal;
            this.transform.SetParent(currentPedestal.transform);

            transform.position = pedestal.transform.position + pedestal.transform.up * pedestal.heightOffset;
            pedestal.hasOrb = true;
            if (currentPlayer.orbUI != null)
            {
                currentPlayer.orbUI.setDisabled();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayer = collision.gameObject.GetComponent<PlayerManager>();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
