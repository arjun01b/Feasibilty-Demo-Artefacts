using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ultrasonic : MonoBehaviour
{


    static string comPort = "COM6"; //Port number on which board is set
    SerialPort serial = new SerialPort(comPort, 9600); // BaudRate serial board is transferring 9600 bits per second

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("MoveSensor", 0.0f, 0.0f);
        serial.Open(); //Opens a new serial port connection
    }

    // Update is called once per frame
    void Update()
    {
       // MoveSensor();
        //Debug.Log("message");//MoveSensor function is called

        InvokeRepeating("MoveSensor", 0.0f, 0.0f);
    }

    void MoveSensor()
    {
        Vector3 pos = transform.position; //Sends position of object in the editor for scriptable

        if(serial.IsOpen) //Gets a value indicating the open or closed status of the SerialPort object
        {
            try
            {
                float data = int.Parse(serial.ReadLine()); //Reads value in the input buffer and returns string
                data = Mathf.Clamp(data, 5, 80); //Clamps the obejct in te specified values
                data = ((((data - 5) / 25) * 9) + 3); 
                transform.position = new Vector3(0, (int)data, 0);
            }
            catch(System.Exception)
            {
                Debug.Log("Exception");
            }

        }
    }
}
