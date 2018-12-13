using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadQuests : MonoBehaviour
{

    public List<Savedbeats> savedlist = new List<Savedbeats>();

    public float _Skyboxblendfactor = 0.01f;

    public float _negativeSkyboxblendfactor = 1f;

    public float _Skyboxblendspeed = 0.05f;

    public Material skybox;

    string path = "Assets/Resources/logtext.txt";

    // Use this for initialization
    void Start()
    {
    }


  void Update()

    {

        string[] lines = File.ReadAllLines("Assets/Resources/logtext.txt");
        Debug.Log(lines.Length);

        for (int i = 1; i < lines.Length; i++)


        {
            string[] row = lines[i].Split(new char[] { ',' });

            if (row[0] != "0")

            {
                Savedbeats h = new Savedbeats();

                int.TryParse(row[0], out h.bpm);

                savedlist.Add(h);
            }

        }

        var heartrate = savedlist[savedlist.Count - 1].bpm;
        var previousrate = savedlist[savedlist.Count - 2].bpm;


        if (heartrate > previousrate)

        {
            //RenderSettings.skybox = skybox;
            Debug.Log("yay");

            _Skyboxblendfactor += (_Skyboxblendspeed * Time.deltaTime);
            //_Skyboxblendfactor = 1;

            RenderSettings.skybox.SetFloat("_Blend", _Skyboxblendfactor);

            if (_Skyboxblendfactor > 1)
            {
                _Skyboxblendfactor = 1;
            }

        }



        else if (heartrate <= previousrate)

        {
            Debug.Log("nay");
            _negativeSkyboxblendfactor -= (_Skyboxblendspeed * Time.deltaTime);            //_Skyboxblendfactor = 1;

            RenderSettings.skybox.SetFloat("_Blend", (_negativeSkyboxblendfactor));

            if (_Skyboxblendfactor < 0)
            {
                _Skyboxblendfactor = 0;
            }

        }


    }
}

	
        //for (int i = 0; i < savedlist.Count - 1; ++i)

        //foreach (Savedbeats h in savedlist)

        //(h.bpm > 0 && h.bpm < 65)
        //Debug.Log(savedlist[savedlist.Count - 1].bpm);
        //var heartrate = savedlist[savedlist.Count - 1].bpm;


    /*


    // Update is called once per frame
    void Update()
    {
        Arrangelist();
        Checkrate();
        Checksource();
    }

    static void Main()

    {
        //string[] lines = File.ReadAllLines("C:\\Users\\michellemboya\\Desktop\\logtext.txt");
        //Debug.Log(lines.Length);

    }

    void Arrangelist()

    {

        //AssetDatabase.ImportAsset(path);
        TextAsset logtext = Resources.Load<TextAsset>("logtext");

        string[] data = logtext.text.Split('\n');

        //Debug.Log(data.Length);



        for (int i = 1; i < data.Length; i++)


        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[0] != "0")

            {
                Savedbeats h = new Savedbeats();

                int.TryParse(row[0], out h.bpm);

                savedlist.Add(h);
            }


        }
    }

    void Checkrate()
    {

        var heartrate = savedlist[savedlist.Count - 1].bpm;
        var previousrate = savedlist[savedlist.Count - 2].bpm;


        if (heartrate > previousrate)

        {
            //RenderSettings.skybox = skybox;
            Debug.Log("yay");

            _Skyboxblendfactor += (_Skyboxblendspeed * Time.deltaTime);
            //_Skyboxblendfactor = 1;

            RenderSettings.skybox.SetFloat("_Blend", _Skyboxblendfactor);

            if (_Skyboxblendfactor > 1)
            {
                _Skyboxblendfactor = 1;
            }

        }



        else if (heartrate <= previousrate)

        {
            Debug.Log("nay");
            _negativeSkyboxblendfactor -= (_Skyboxblendspeed * Time.deltaTime);            //_Skyboxblendfactor = 1;

            RenderSettings.skybox.SetFloat("_Blend", (_negativeSkyboxblendfactor));

            if (_Skyboxblendfactor < 0)
            {
                _Skyboxblendfactor = 0;
            }

        }


    }

    public void Checksource()
    {

    }
    */




