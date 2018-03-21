using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreFeedback : MonoBehaviour {


    private GradientColorKey cg1 = new GradientColorKey(new Color(0, 255, 12),0);   // GREEN-ish
    private GradientAlphaKey ca1 = new GradientAlphaKey(1, 0);
    private GradientColorKey cg2 = new GradientColorKey(new Color(0, 255, 171),1);
    private GradientAlphaKey ca2 = new GradientAlphaKey(1, 1);

    private GradientColorKey icg1 = new GradientColorKey(new Color(255, 0, 0),0); // RED
    private GradientAlphaKey ica1 = new GradientAlphaKey(1, 0);
    private GradientColorKey icg2 = new GradientColorKey(new Color(77, 0, 0),1);
    private GradientAlphaKey ica2 = new GradientAlphaKey(1, 1);


    public ParticleSystem.MinMaxGradient cGradient;

    public ParticleSystem.MinMaxGradient icGradient;


    private ParticleSystem ps;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();

        GradientColorKey[] colorKeys = new GradientColorKey[]{ cg1, cg2 };
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]{ ca1, ca2 };
        Gradient g = new Gradient();
        g.SetKeys(colorKeys, alphaKeys);
        cGradient = new ParticleSystem.MinMaxGradient(g);

        GradientColorKey[] colorKeys2 = new GradientColorKey[] { icg1, icg2 };
        GradientAlphaKey[] alphaKeys2 = new GradientAlphaKey[] { ica1, ica2 };
        Gradient g2 = new Gradient();
        g2.SetKeys(colorKeys2, alphaKeys2);
        icGradient = new ParticleSystem.MinMaxGradient(g2);


    }


    public void correct()
    {
        ParticleSystem.MainModule main = gameObject.GetComponent<ParticleSystem>().main;
        main.startColor = cGradient;
        ps.Clear();
        ps.Play();


    }



    public void incorrect()
    {
        ParticleSystem.MainModule main = gameObject.GetComponent<ParticleSystem>().main;
        main.startColor = icGradient;
        ps.Clear();
        ps.Play();
    }


}
