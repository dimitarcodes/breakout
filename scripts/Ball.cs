using UnityEngine;

namespace group1.Breakout.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float speed;
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.CompareTag("Water")) //I added these tags to the water and brick objects manually!
            {
                gameManager.CollideWater();
            }
            if(other.gameObject.CompareTag("Brick"))
            {
                gameManager.CollideBrick(other);
            }
        }

        private void Reset()
        {
            speed = 12;
        }

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody.AddForce(new Vector3(0.15f, -speed, 0), ForceMode.VelocityChange); 
        }
    }
}