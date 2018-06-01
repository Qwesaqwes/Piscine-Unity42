using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
	private	Vector3		    _target;
	private	Vector3		    _endDragPos;
    public SpriteRenderer   RangeImage;
    public GameObject       Tower;
    private towerScript     _towerScript;
    [HideInInspector] public int energyOfTower = 0;
    [HideInInspector] public bool enableDrag = true;       
   	// private Text		_textEnergy;
  

    // Use this for initialization
    void Start ()
	{
		_target = transform.position;
        // _textEnergy = GameObject.Find("TextEnergy").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	 public void OnDrag(PointerEventData eventData)
    {
        if (enableDrag)
        {
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
            RangeImage.enabled = true;
            RangeImage.transform.position = _target;
            transform.position = _target;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && enableDrag)
        { 
            _endDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _endDragPos.z = _target.z;
            Tower.transform.position = _endDragPos;
            Instantiate(Tower, Tower.transform.position, Quaternion.identity);
            towerScript _towerScript = Tower.GetComponent<towerScript>();
            energyOfTower = _towerScript.energy;
        }
        transform.localPosition = Vector3.zero;
        RangeImage.transform.position = Vector3.zero;
        RangeImage.enabled = false;
    }
}
