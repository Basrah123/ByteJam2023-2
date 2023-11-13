using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Armor : MonoBehaviour
{
    public Image shieldImage;
    private int currentShield = 100;
    private int maxShield = 100;
    private float targetShieldPercentage;
    private bool isCooldownActive = false;
    private float cooldownDuration = 10f;

    // Removed unnecessary initialShield and maximumShield variables

    void Start()
    {
        // Initialize shield values
        currentShield = maxShield; // Set currentShield to the maximum value initially
        UpdateShieldSymbol();
    }

    void Update()
    {
        // Start cooldown when the shield is fully depleted
        if (currentShield <= 0 && !isCooldownActive)
        {
            StartCoroutine(StartCooldown());
        }
    }

    public void UpdateShieldSymbol(int damage = 10)
    {
        // Decrease shield based on damage
        currentShield -= damage;
        currentShield = Mathf.Clamp(currentShield, 0, maxShield);
        targetShieldPercentage = (float)currentShield / maxShield;
        StartCoroutine(UpdateShieldOverTime());
    }

    private IEnumerator UpdateShieldOverTime()
    {
        float elapsedTime = 0f;
        float duration = 1f;

        float startPercentage = shieldImage.fillAmount;

        while (elapsedTime < duration)
        {
            shieldImage.fillAmount = Mathf.Lerp(startPercentage, targetShieldPercentage, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        shieldImage.fillAmount = targetShieldPercentage;
    }

    private IEnumerator StartCooldown()
    {
        isCooldownActive = true;
        yield return new WaitForSeconds(cooldownDuration);

        // Reset shield values
        currentShield = maxShield;
        UpdateShieldSymbol();

        isCooldownActive = false;
    }
}




