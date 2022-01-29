using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //RAY 
    [SerializeField] private float maxDistancePickp;
    [SerializeField] private LayerMask layerMask;
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
    /// Verifie si le joueur pointe vers un objet
    /// </summary>
    private void CheckPickUp()
    {
        //on set la ray de detection
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit hit;

        //on verifie s'il hit un objet portable
        //si oui
        if (Physics.Raycast(ray.origin, ray.direction, out hit, maxDistancePickp, layerMask))
        {
            _canPickUp = true;
            GetMaterial(hit.transform.gameObject);
        }
        //si non
        else
        {
            _canPickUp = false;
            ReturnMaterial();
        }
    }

    /// <summary>
    /// Permet de pick un objet si le joueur appuie sur le bouton d'interaction
    /// </summary>
    private void PickingUpObject()
    {
        //si le joueur 
        if (!_canPickUp)
            return;

        //si il intéragit
        if (_inputs.Interact)
        {
            //on set la position du nouvel objet qu'on pick
            _pickPosition = _pickableObject.transform;
            //si le joueur a deja pick un objet
            if (_pickObject != null)
            {
                Drop();

                Pick();
            }
            //s'il n'a pas d'objet deja pick
            else
                Pick();
        }
    }

    /// <summary>
    /// aller chercher le materiau de l'objet a pick
    /// </summary>
    /// <param name="obj"></param>
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
    /// return le material de base qui est set
    /// </summary>
    private void ReturnMaterial()
    {
        if (_pickMaterial)
            _pickableObject.GetComponent<Renderer>().material = _basedMaterial;

        _pickMaterial = false;
    }


    /// <summary>
    /// pick un objet
    /// </summary>
    private void Pick()
    {
        //l'objet qu'on peut pick
        _pickObject = _pickableObject;
        //set son ayer sur 0
        _pickObject.layer = 0;
        //on set le nouvel objet en enfant
        _pickObject.transform.parent = transform;
        //set sa position
        _pickObject.transform.position = pickUpPosition.position;
        ReturnMaterial();
    }

    /// <summary>
    /// drop un objet
    /// </summary>
    private void Drop()
    {
        //on lache l'objet qu'il portait
        _pickObject.transform.parent = null;
        //on le place a la position du dernier objet recup
        _pickObject.transform.position = _pickPosition.position;
        //on reset l'objet en pickablesObjects
        _pickObject.layer = layerNumber;
    }
}