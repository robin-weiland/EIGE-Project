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

        private PlayerProperties _playerprops;
        private GameObject _view;
        private Image _image;


        private void Start()
        {
            _playerprops = player.GetComponent<PlayerManager>().properties;
            _view = transform.GetChild(0).gameObject;
            _image = _view.GetComponent<Image>();
        }


        private void Update()
        {
            if (_playerprops.currentOrb != null)
                switch (_playerprops.currentOrb.type)
                {
                    // not enabling here to prevent flashing; hate the repeated enabling...
                    case OrbType.DoubleJump:
                        _view.SetActive(true);
                        _image.sprite = cloudOrb;
                        break;

                    case OrbType.Dash:
                        _view.SetActive(true);
                        _image.sprite = lightOrb;
                        break;

                    case OrbType.Pull:
                        _view.SetActive(true);
                        _image.sprite = hookOrb;
                        break;

                    // only one gravity view for now
                    case OrbType.GravityUp:
                    case OrbType.GravityRight:
                    case OrbType.GravityLeft:
                        _view.SetActive(true);
                        _image.sprite = gravityOrb;
                        break;

                    default:
                        _view.SetActive(false);
                        break;
                }
            else
                _view.SetActive(false);
        }

        public void SetAlpha(float alpha)
        {
            // apparently more efficient that way
            var color = _image.color;
            color = new Color(color.r, color.g, color.b, alpha);
            _image.color = color;
        }
    }
}