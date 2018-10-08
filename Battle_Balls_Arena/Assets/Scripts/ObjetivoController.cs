using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoController : MonoBehaviour {
    public GameObject m_Canvas;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Mechanics m_Script = m_Canvas.GetComponent<Mechanics>();
        if (other.tag == "Player")
        {
            Debug.Log("Objeto está dentro do colisor!");
            m_Script.ChangeTurn();
        }
    }
}
