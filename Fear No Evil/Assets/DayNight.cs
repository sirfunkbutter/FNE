using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour
{

    void Start()
    {
        // Creating everything needed to demonstrate this from a single cube
        sun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sun.name = "sun";
        sun.GetComponent<Renderer>().material.color = Color.yellow;
        sun.AddComponent<Light>().type = LightType.Directional;
        sun.GetComponent<Light>().shadows = LightShadows.Hard;
        sun.GetComponent<Light>().color = new Color(1, 1, 0.75f);
        sun.GetComponent<Renderer>().castShadows = false;
        moon = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        moon.name = "moon";
        moon.GetComponent<Renderer>().material.color = new Color(0.75f, 0.75f, 0.75f);
        moon.AddComponent<Light>().type = LightType.Directional;
        moon.GetComponent<Light>().shadows = LightShadows.Hard;
        moon.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f);
        moon.GetComponent<Light>().intensity = 0.1f;
        moon.GetComponent<Renderer>().castShadows = false;
    }

    public Transform player;

    public GameObject sun;
    public GameObject moon;

    public float radius = 6;

    public Color daytimeSkyColor = new Color(0.31f, 0.88f, 1f);
    public Color middaySkyColor = new Color(0.58f, 0.88f, 1f);
    public Color nighttimeSkyColor = new Color(0.04f, 0.19f, 0.27f);

    // implementing minecraft PC defaults
    public const float daytimeRLSeconds = 10.0f * 60;
    public const float duskRLSeconds = 1.5f * 60;
    public const float nighttimeRLSeconds = 7.0f * 60;
    public const float sunsetRLSeconds = 1.5f * 60;
    public const float gameDayRLSeconds = daytimeRLSeconds + duskRLSeconds + nighttimeRLSeconds + sunsetRLSeconds;

    public const float startOfDaytime = 0;
    public const float startOfDusk = daytimeRLSeconds / gameDayRLSeconds;
    public const float startOfNighttime = startOfDusk + duskRLSeconds / gameDayRLSeconds;
    public const float startOfSunset = startOfNighttime + nighttimeRLSeconds / gameDayRLSeconds;


    private float timeRT = 0;
    public float TimeOfDay // game time 0 .. 1
    {
        get { return timeRT / gameDayRLSeconds; }
        set { timeRT = value * gameDayRLSeconds; }
    }

    void Update()
    {
        timeRT = (timeRT + Time.deltaTime) % gameDayRLSeconds;
        Camera.main.backgroundColor = CalculateSkyColor();
        float sunangle = TimeOfDay * 360;
        float moonangle = TimeOfDay * 360 + 180;
        Vector3 midpoint = player.position; midpoint.y -= 0.5f; //midpoint = playerposition at floor height
        sun.transform.position = midpoint + Quaternion.Euler(0, 0, sunangle) * (radius * Vector3.right);
        sun.transform.LookAt(midpoint);
        moon.transform.position = midpoint + Quaternion.Euler(0, 0, moonangle) * (radius * Vector3.right);
        moon.transform.LookAt(midpoint);
    }

    Color CalculateSkyColor()
    {
        float time = TimeOfDay;
        if (time <= 0.25f)
            return Color.Lerp(daytimeSkyColor, middaySkyColor, time / 0.25f);
        if (time <= 0.5f)
            return Color.Lerp(middaySkyColor, daytimeSkyColor, (time - 0.25f) / 0.25f);
        if (time <= startOfNighttime)
            return Color.Lerp(daytimeSkyColor, nighttimeSkyColor, (time - startOfDusk) / (startOfNighttime - startOfDusk));
        if (time <= startOfSunset) return nighttimeSkyColor;
        return Color.Lerp(nighttimeSkyColor, daytimeSkyColor, (time - startOfSunset) / (1.0f - startOfSunset));
    }

    /*void OnGUI()
    {
        Rect rect = new Rect(10, 10, 120, 20);
        GUI.Label(rect, "time: " + TimeOfDay); rect.y += 20;
        GUI.Label(rect, "timeRT: " + timeRT);
        rect = new Rect(120, 10, 200, 10);
        TimeOfDay = GUI.HorizontalSlider(rect, TimeOfDay, 0, 1);
    }*/
}