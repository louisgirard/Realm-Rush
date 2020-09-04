using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float destructionDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }
}