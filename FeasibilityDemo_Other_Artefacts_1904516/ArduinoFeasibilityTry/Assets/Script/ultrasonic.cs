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
        
        serial.Open(); //Opens a new serial port connection
    }

    // Update is called once per frame
    void Update()
    {
        MoveSensor();
        

       // InvokeRepeating("MoveSensor", 0.0f, 0.0f);
    }

    void MoveSensor()
    {
        

        if(serial.IsOpen) //Gets a value indicating the open or closed status of the SerialPort object
        {
           // try
            //{
                float data = int.Parse(serial.ReadLine()); //Reads value in the input buffer and returns string
                data = Mathf.Clamp(data, 0, 50); //Clamps the obejct in the specified values. Taking data variable which has the value from the calculation by the sensor
                transform.position = new Vector3(0, (int)data, 0);
           // }
           // catch(System.Exception)
           // {
               // Debug.Log("Exception");
           // }

        }
    }
}



// data = ((((data - 5) / 25) * 9) + 3); 