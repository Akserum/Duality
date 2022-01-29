using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //RAY 
    [SerializeField] private float maxDistancePickp;
<<<<<<< HEAD
    [SerializeField] private LayerMask interactibleLayer;
    [SerializeField] private int layerNum;
=======
    [SerializeField] private int LayerNumPickable;
    [SerializeField] private int LayerNumCloset;
>>>>>>> parent of fde6b4f (obj ok + des trucs avec la camera)
    [SerializeField] private Material highlightMaterial;

    //
    [SerializeField] private Transform pickUpPosition;

    [SerializeField] private int layerNumber;

    private PlayerInputs _inputs;

    //pick up
    private bool _canPickUp;
    private bool _pickMaterial;
    private GameObject _pickableObject;
    private GameObject _pickObject;
    private Transform _pickPosition;

    //material
    private Material _basedMaterial;

    public bool getCanPickUp => _canPickUp;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        CheckPickUp();
        //PickingUpObject();
    }

    private void Initialize()
    {
        _inputs = GetComponentInParent<PlayerInputs>();
    }

    /// <summary>
    /// Check if an object can be grab
    /// </summary>
    private void CheckPickUp()
    {
        //set the ray
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit hit;

<<<<<<< HEAD

        if (Physics.Raycast(ray.origin, ray.direction, out hit, maxDistancePickp, interactibleLayer))
        {
            GetMaterial(hit.transform.gameObject);

            if (hit.transform.gameObject.tag == "PickableObject")
            {
                _canPickUp = true;
            }
            else if(hit.transform.gameObject.tag == "Closet")
            {
                Debug.Log("Armoire");
                OpenCloset(hit.transform.gameObject);
=======
        if (Physics.Raycast(ray.origin, ray.direction, out hit, maxDistancePickp))
        {
            Debug.Log(hit.transform.gameObject.name);

            if (hit.transform.gameObject.layer == LayerNumPickable)
            {
                Debug.Log("Je suis un objet");
                _canPickUp = true;
                GetMaterial(hit.transform.gameObject);
            }

            if (hit.transform.gameObject.layer == LayerNumCloset)
            {
                Debug.Log("Je suis une armoire");
                GetMaterial(hit.transform.gameObject);
>>>>>>> parent of fde6b4f (obj ok + des trucs avec la camera)
            }
        }
        else
        {
            _canPickUp = false;
            ReturnMaterial();
        }
    }

    #region ClosetInteractions
    private void OpenCloset(GameObject obj)
    {
        if (_inputs.Interact)
        {
            Debug.Log(obj.name);
            obj.GetComponent<ClosetScript>().ClosetBool();
        }
    }
    #endregion

    #region GetAndReturnMaterial
    /// <summary>
    /// get the material of the picked up object
    /// </summary>
    private void GetMaterial(GameObject obj)
    {
        if (!_pickMaterial)
        {
            _pickableObject = obj;
            Renderer renderer = obj.GetComponent<Renderer>();
            _basedMaterial = renderer.material;
            renderer.material = highlightMaterial;
            Debug.Log(obj);
            _pickMaterial = true;
        }
    }

    /// <summary>
    /// return the previous material
    /// </summary>
    private void ReturnMaterial()
    {
        if (_pickMaterial)
            _pickableObject.GetComponent<Renderer>().material = _basedMaterial;

        _pickMaterial = false;
    }
    #endregion

    #region PickObjects

    /// <summary>
    /// Pick an Object if the mouse 0 button is pressed
    /// </summary>
    private void PickingUpObject()
    {
        if (!_canPickUp)
            return;

        if (_inputs.PickUp)
        {
            _pickPosition = _pickableObject.transform;
            //if the player already have an object 
            if (_pickObject != null)
            {
                Drop();

                Pick();
            }
            //if not
            else
                Pick();
        }
    }
    #endregion

    #region PickObjects

    /// <summary>
    /// Pick an Object if the mouse 0 button is pressed
    /// </summary>
    private void PickingUpObject()
    {
        if (!_canPickUp)
            return;

        if (_inputs.PickUp)
        {
            _pickPosition = _pickableObject.transform;
            //if the player already have an object 
            if (_pickObject != null)
            {
                Drop();

                Pick();
            }
            //if not
            else
                Pick();
        }
    }


    /// <summary>
    /// pick an object
    /// </summary>
    private void Pick()
    {
        //pickable object
        _pickObject = _pickableObject;
        //set his new layer
        _pickObject.layer = 0;
        //set his new parent
        _pickObject.transform.parent = transform;
        //set his new position
        _pickObject.transform.position = pickUpPosition.position;
        ReturnMaterial();
    }

    /// <summary>
    /// drop an object
    /// </summary>
    private void Drop()
    {
        //set the parent of the previous object at null
        _pickObject.transform.parent = null;
        //set his position at the same positon of the pickable object
        _pickObject.transform.position = _pickPosition.position;
        //reset his layer
        _pickObject.layer = layerNum;
    }
    #endregion
}