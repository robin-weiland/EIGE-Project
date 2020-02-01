using System;
using UnityEngine;
using UnityEngine.UI;

namespace GeneralScripts
{
    public class OrbViewManager : MonoBehaviour
    {
        public GameObject player;

        [Header("Add all orbs here")] public Sprite cloudOrb;
        public Sprite gravityOrb;
        public Sprite hookOrb;
        public Sprite lightOrb;

        private PlayerProperties playerprops;
        private SpriteRenderer renderer;
        private GameObject view;
        private Image image;


        private void Start()
        {
            playerprops = player.GetComponent<PlayerManager>().properties;
            renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            view = transform.GetChild(0).gameObject;
            image = view.GetComponent<Image>();
        }


        private void Update()
        {
            if (playerprops.currentOrb != null)
                switch (playerprops.currentOrb.type)
                {
                    // not enabling here to prevent flashing; hate the repeated enabling...
                    case OrbType.DoubleJump:
                        view.SetActive(true);
                        image.sprite = cloudOrb;
                        break;
            
                    case OrbType.Dash:
                        view.SetActive(true);
                        image.sprite = lightOrb;
                        break;
                    
                    case OrbType.Pull:
                        view.SetActive(true);
                        image.sprite = hookOrb;
                        break;
            
                    // only one gravity view for now
                    case OrbType.GravityUp:
                    case OrbType.GravityRight:
                    case OrbType.GravityLeft:
                        view.SetActive(true);
                        image.sprite = gravityOrb;
                        break;
            
                    default:
                        view.SetActive(false);
                        break;
                }
            else
                view.SetActive(false);
        }
    }
}