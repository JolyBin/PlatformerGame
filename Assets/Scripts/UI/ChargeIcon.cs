// ChargeIcon
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
	public Image Background;

	public Image Foreground;

	public Text TextTimer;

	public void StartCharge()
	{
		Background.color = new Color(1f, 1f, 1f, 0.2f);
		Foreground.enabled = true;
		TextTimer.enabled = true;
	}

	public void StopCharge()
	{
		Background.color = new Color(1f, 1f, 1f, 1f);
		Foreground.enabled = false;
		TextTimer.enabled = false;
	}

	public void SetCharrgeValue(float currentCharge, float maxCharge)
	{
		Foreground.fillAmount = currentCharge / maxCharge;
		TextTimer.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
	}
}
