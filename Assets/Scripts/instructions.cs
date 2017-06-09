using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class instructions : MonoBehaviour {

	public Button button;
	public InputField input;
	public GameObject spt;
	public Text txt;

	public float speed = 10f;
	public float jump_speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Copy () {
		System.IO.File.WriteAllText ("Assets/Data/commandes.txt", input.text);
	}

	void move_fw () {
		Vector3 move = new Vector3(1, 0, 0);
		Vector3 endPosition = spt.transform.position + move;
		spt.transform.position = Vector3.MoveTowards(spt.transform.position, endPosition, speed);
	}

	void move_bw () {
        Vector3 move = new Vector3(-1, 0, 0);
        Vector3 endPosition = spt.transform.position + move;
        spt.transform.position = Vector3.MoveTowards(spt.transform.position, endPosition, speed);
    }

	void jump () {
		spt.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jump_speed);
	}

    void say (string text) {
        txt.text = text;
    }

	void Search (string s, string p) {
		string line;
		StreamReader reader = new StreamReader ("Assets/Data/all.txt");
		if (s [0] == '\n')
			s = s.Substring (1, s.Length - 1);

		while (!reader.EndOfStream) {
            line = reader.ReadLine ();
			if (s [0] == line [0]) {
				string[] commands = line.Split ('|');
				if (s == commands [0]) {
                    if (s == "parle")
                        say(p);
                    else
                    {
                        if (p == "")
                            p = "1";
                        for (int i = 0; i <= Int32.Parse(p); i++)
                            Invoke(commands[1], 0);
                    }
                    return;
				}
			}
		}
	}

	public void Analyze () {
		char ch;
		string command = "";
		string parameter = "";
		StreamReader reader = new StreamReader ("Assets/Data/commandes.txt");

		do {
			ch = (char)reader.Read ();

			if(ch == '(') {
				ch = (char)reader.Read();
				while(ch != ')') {
					parameter += ch;
					ch = (char)reader.Read();
				}
				ch = (char)reader.Read();
			}

			if(ch == ';') {
				Search(command, parameter);
				command = "";
				parameter = "";
				ch = (char)reader.Read();				
			}

			command += ch;
		} while(!reader.EndOfStream);

		reader.Close ();
		reader.Dispose ();
	}
}
