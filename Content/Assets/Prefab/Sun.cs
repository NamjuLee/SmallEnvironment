using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Globalization;

public class Sun : MonoBehaviour
{

    Scrollbar ui_Lat;
    Scrollbar ui_Day;
    Scrollbar ui_Time;
    Scrollbar ui_SunDis;
    Toggle SunVisToggle;

    Text ui_LatText;
    Text ui_DayText;
    Text ui_TimeText;
    Text TextDateTop;

    public GameObject sunSphere;
    Solar sun;

    void Awake()
    {
        ui_Lat = GameObject.Find("ui_Lat").GetComponent<Scrollbar>();
        ui_Day = GameObject.Find("ui_Day").GetComponent<Scrollbar>();
        ui_Time = GameObject.Find("ui_Time").GetComponent<Scrollbar>();
        ui_SunDis = GameObject.Find("ui_SunDis").GetComponent<Scrollbar>();
        SunVisToggle = GameObject.Find("SunVisToggle").GetComponent<Toggle>();

        ui_LatText = GameObject.Find("ui_LatText").GetComponent<Text>();
        ui_DayText = GameObject.Find("ui_DayText").GetComponent<Text>();
        ui_TimeText = GameObject.Find("ui_TimeText").GetComponent<Text>();


        TextDateTop = GameObject.Find("TextDateTop").GetComponent<Text>();

        sun = new Solar();
    }


    public float Lat = 45f;
    public float Day = 100;
    public float Time = 12;




    void Update()
    {

        ui_LatText.text = "Latitude: " + ui_Lat.value * 90f;
        ui_DayText.text =  CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)Mathf.Round((ui_Day.value * 365f)/31.5f)) + " , " + (int)(Mathf.Round((ui_Day.value * 365f)) % 31.5);
        ui_TimeText.text = "Time : " + Mathf.Round(ui_Time.value * 24f);
        sun.UpdateSun(ui_Lat.value * 90f - 0.01f, ui_Day.value * 360f, ui_Time.value * 24);
        transform.rotation = Quaternion.LookRotation(new Vector3(-sun.VectorSun.x, -sun.VectorSun.z, -sun.VectorSun.y));

        if (SunVisToggle.isOn)
        {
            sunSphere.transform.position = new Vector3(sun.VectorSun.x, sun.VectorSun.z, sun.VectorSun.y) * ((ui_SunDis.value + 0.2f) * 20f);
            sunSphere.transform.rotation = Quaternion.LookRotation(new Vector3(-sun.VectorSun.x, -sun.VectorSun.z, -sun.VectorSun.y));
        }
        else {
            sunSphere.transform.position = new Vector3(-1000f, 1000f);
        }
        TextDateTop.text = ui_LatText.text + " , "+ ui_DayText.text + "th , "+ ui_TimeText.text;
    }






    public class Solar
    {
        string strMonthName;

        public Vector3 VectorOrigin = new Vector3();
        public Vector3 VectorSun = new Vector3();
        public Vector3 SunPoint;

        public float declination;
        public float solarAltitude;
        public float solarAzimuth;

        public float southDegree = -90f;
        public float sunDistance = 100f;

        public float day = 1;
        public float latitude = 42.3f;
        public float hour = 14f;

        public List<int> Shadowness = new List<int>();

        public void UpdateSun(float Latitude, float theDay, float Hour, float sundistance = 100f, float sphereSize = 10.0f, float south = -90f)
        {
            strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);

           
            day = theDay;
            latitude = Latitude;
            hour = Hour;

            southDegree = south;
            sunDistance = sundistance;


            declination = Declination(day);
            solarAltitude = SolarAltitude(latitude, declination, hour - 12);
            solarAzimuth = SolarAzimuth(latitude, declination, hour - 12, solarAltitude);

            VectorSun.x = Mathf.Cos(Radians(southDegree - solarAzimuth));
            VectorSun.y = Mathf.Sin(Radians(southDegree - solarAzimuth));
            VectorSun.z = Mathf.Tan(Radians(solarAltitude));

            VectorSun.Normalize();
        }


        public override string ToString()
        {
            return base.ToString() + ": Latitude = " + latitude + " Day = " + day + " Hour = " + hour + " { the declination :  '" + declination + "' Degree. The Solar Altitude : '" + solarAltitude + "' Degree. The Solar Azimuth : '" + solarAzimuth + "' Degree. } ";
        }


        public float Declination(float day)
        {
            return (23.45f * Mathf.Sin(Radians(360f * (284f + day)) / 365.25f));
        }

        public float SolarAltitude(float latitude, float declination, float hour)
        {
            float newValue = (Mathf.Asin(Mathf.Cos(Radians(latitude)) * Mathf.Cos(Radians(declination)) * Mathf.Cos(Radians(hour * 15)) + Mathf.Sin(Radians(latitude)) * Mathf.Sin(Radians(declination))));
            return Degrees(newValue);
        }

        public float SolarAzimuth(float latitude, float declination, float hour, float solarAltitude)
        {
            if (hour == 0)
            {
                hour = 0.1f;
            }
            if (hour < 0)
            {
                return (-Degrees(Mathf.Acos(((Mathf.Sin(Radians(solarAltitude)) * Mathf.Sin(Radians(latitude)) - Mathf.Sin(Radians(declination))) / (Mathf.Cos(Radians(solarAltitude)) * Mathf.Cos(Radians(latitude)))))));
            }
            else
            {
                return Degrees(Mathf.Acos(((Mathf.Sin(Radians(solarAltitude)) * Mathf.Sin(Radians(latitude)) - Mathf.Sin(Radians(declination))) / (Mathf.Cos(Radians(solarAltitude)) * Mathf.Cos(Radians(latitude))))));
            }
        }



        public List<float> CalValue(List<int> valueList, float scale, int minVal)
        {
            List<float> newVal = new List<float>();
            foreach (int n in valueList)
            {
                if (n > minVal)
                {
                    float newnum = n / scale;
                    newVal.Add(newnum);
                }
                else
                {
                    newVal.Add(0);
                }
            }
            return newVal;
        }

        #region degrees to radians and radian to degrees
        public float Radians(float degrees)
        {
            return (degrees * (3.14159265358979f / 180.0f)); // myDegree *=  3.141592 / 180 // degrees to radians
        }

        public float Degrees(float radians)
        {
            return (radians * (180.0f / 3.14159265358979f));  // myRadian *= 180 / 3.141592 //  radian to degrees
        }
        #endregion degrees to radians and radian to degrees



    }


}
