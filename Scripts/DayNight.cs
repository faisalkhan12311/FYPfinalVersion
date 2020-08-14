using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNight : MonoBehaviour {
    [SerializeField] private Light sun;
    [SerializeField] private float secondsInFullDay = 120f;
    public TextMeshProUGUI dayText;

    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    public SpawnZombies spawnZombie;
    public int dayNo, dayNoOverall;

    private void Start() {
        sunInitialIntensity = sun.intensity;
        dayNo = 1;
        dayNoOverall = 1;
        dayText.text = "Day : " + dayNoOverall;
    }
    private void Update() {
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1) {
            currentTimeOfDay = 0;
            if (dayNo < 3) {
                dayNo++;
            }

            dayNoOverall++;
            dayText.text = "Day : " + dayNoOverall;
            spawnZombie.Spawn();

            if(PlayerPrefs.GetInt("TotalDays") < dayNoOverall)
            {
                PlayerPrefs.SetInt("TotalDays", dayNoOverall);
            }
        }

    }
    void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75) {
            intensityMultiplier = 0;
        } else if (currentTimeOfDay <= 0.25f) {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        } else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));

        }
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
