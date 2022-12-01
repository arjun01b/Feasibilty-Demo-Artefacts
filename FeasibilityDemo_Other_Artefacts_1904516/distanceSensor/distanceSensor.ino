#define trigPin 9 //macro for defining trigPin as 9 on the board D9
#define echoPin 8 //macro for defining echoPin as 8 on the board D8



long t;
int distance;

 
//First function to be executed in the program
//Executed only once
void setup()
{
 pinMode(trigPin, OUTPUT); //For triggering the ultrasonic sound pulses
 pinMode(echoPin, INPUT); //Produces a pulse when the reflective pulse is received
 Serial.begin(9600); //For establishing a connecting pin between arduino board and unity
}

void loop() 
{
  int dist = GetDistance(); //Function has to be repeated in the loop to keep updating the distance
  Serial.flush(); //clears the serial data stream and kind of refreshes it and also makes you ready to send the next data
  Serial.println(dist); //for printing the data
  delay(100);
}

int GetDistance() //Function for calculating the distance
{
  digitalWrite(trigPin, LOW); //Since trigPin is set as the output pin, the LOW indicates that it is close to 0V and will not send a signal yet
  delayMicroseconds(2); //After 2 ms, the trigpin will be set to HIGH and send a signal
  digitalWrite(trigPin, HIGH); //trigPin's voltage becomes close to 5V and sends out a signal
  delayMicroseconds(10);
  t=pulseIn(echoPin, HIGH); // pulseIn function returns the duration of the pulse by the echoPin 
  distance = (0.0343*t)/2; //speed of sound in the air d = s*t divided by 2 because 2 waves have travelled double distance
  return distance;

}

