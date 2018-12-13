using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class starbeat : MonoBehaviour {


    public List<Starsaver> starlist = new List<Starsaver>();
    public ParticleSystem stary;
    public ParticleSystem lowstary;


    // Use this for initialization
    void Start()
    {
    }


    void Update()

    {

        string[] liner = File.ReadAllLines("Assets/Resources/starheart.txt");
        Debug.Log(liner.Length);

        for (int i = 1; i < liner.Length; i++)


        {
            string[] row = liner[i].Split(new char[] { ',' });

            if (row[1] != "0")

            {
                Starsaver s = new Starsaver();

                int.TryParse(row[0], out s.hrate);

                starlist.Add(s);
            }

        }

        var lastrate = starlist[starlist.Count - 1].hrate;
        var secondrate = starlist[starlist.Count - 2].hrate;


        if (lastrate >= secondrate)

        {
            Debug.Log("oy");
            stary.Play();

           
            }

            else if (lastrate < secondrate)

        {
            Debug.Log("oy");

            lowstary.Play();

        }


    }
}
