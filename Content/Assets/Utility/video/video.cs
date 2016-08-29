﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[RequireComponent(typeof(Material))]
[RequireComponent(typeof(AudioSource))]
public class video : MonoBehaviour {

    public MovieTexture movie;
    public string sc; 
    AudioSource audio;


    

    // Use this for initialization
    void Start ()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;

        movie.Play();
        audio.Play();
	}

    void Update() {

        //if (Input.GetKeyDown(KeyCode.Space) && (movie.isPlaying)) movie.Pause();
        //else if (Input.GetKeyDown(KeyCode.Space) && (!movie.isPlaying)) movie.Play();

        if (!movie.isPlaying) { Application.LoadLevel(sc); }

    }

    void OnMouseDown()
    {
        Application.LoadLevel(sc);
    }




}
