using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {  

	public Camera MyCamera;
	public Rigidbody m_Rigidbody;
    public float m_MaxForce;

    [Header("Force UI")]
    public float m_TimeToMaxForce;
    public Slider m_ForceSlider;
    public Image m_ForceFillImage;
    public Color m_MinForceColor;
    public Color m_MaxForceColor;
    public AnimationCurve m_Curve;
	public enum ShooterState
    {
        None, Charging, Moving
    }
    private bool m_Shoot;
	private ShooterState m_CurrentState = ShooterState.None;
	private float m_ForceDirection = 1;
   	private void Update()
    {
        if (m_CurrentState == ShooterState.None && Input.GetMouseButtonDown(0))
        {
			m_ForceSlider.gameObject.SetActive(true);
            m_ForceSlider.value = 0.0f;
            m_ForceDirection = 1;
            m_CurrentState = ShooterState.Charging;
        }

        if (m_CurrentState == ShooterState.Charging && Input.GetMouseButton(0))
        {
            m_ForceSlider.value += (Time.deltaTime / m_TimeToMaxForce) * m_ForceDirection;

            m_ForceFillImage.color = Color.Lerp(m_MinForceColor, m_MaxForceColor, m_Curve.Evaluate(m_ForceSlider.value));

            if (m_ForceSlider.value >= 1.0f || m_ForceSlider.value <= 0.0f)
            {
                m_ForceDirection *= -1;
            }
        }

		if (m_CurrentState == ShooterState.Charging && Input.GetMouseButtonUp(0))
        {
			m_CurrentState = ShooterState.Moving;
            float force = m_ForceSlider.value * m_MaxForce;
            m_Rigidbody.AddForce(Vector3.Scale(MyCamera.transform.forward, Vector3.forward + Vector3.right) * force);     
			m_ForceSlider.gameObject.SetActive(false);
        }
    }

	private void LateUpdate ()
    {	
		if (m_CurrentState == ShooterState.Moving)
			if (m_Rigidbody.IsSleeping())
			{
				m_CurrentState = ShooterState.None;
			}
    }
}
