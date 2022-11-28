#define trigPin 9 // attach pin D9 Arduino to pin trig of HC-SR04
#define echoPin 8 //attach pin D8 Arduino to pin echo of HC-SR04



long t;
int distance;

void setup() 
{
 pinMode(trigPin, OUTPUT);
 pinMode(echoPin, INPUT);
 Serial.begin(9600);
}

void loop() 
{
  int dist = GetDistance();
  Serial.flush();
  Serial.println(dist);
  delay(100);
}

int GetDistance()
{
  digitalWrite(trigPin, LOW);
  delayMicroseconds(10);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  t=pulseIn(echoPin, HIGH);
  distance = (0.0343*t)/2; //speed of sound in the air d = s*t divided by 2 because 2 waves have travelled double distance
  return distance;

}

