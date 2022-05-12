using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageLifes : MonoBehaviour
{
    private CharacterController _charController;
    [SerializeField]
    private Text _numberOfLifes;
    private int _currentLifes = 3;
    [SerializeField]
    private GameObject _checkpoint;
    private bool _loseLife = false;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (_charController.velocity.y < -22)
            _loseLife = true;

        if (_charController.isGrounded && _loseLife)
        {
            _loseLife = false;
            if (_currentLifes >= 1)
            {
                _currentLifes--;
                ChangeLifes();
                //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);

                //Debug.Log(_checkpoint.transform.position.x + " " + _checkpoint.transform.position.y + " " + _checkpoint.transform.position.z);
                _charController.enabled = false;
                _charController.transform.position = _checkpoint.transform.position;
                _charController.enabled = true;                //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);

            }
            if (_currentLifes == 0)
            {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }

        }
    }

    private void ChangeLifes()
    {
        _numberOfLifes.text = _currentLifes.ToString();
    }
}
