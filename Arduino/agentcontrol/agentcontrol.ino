#define LED9 9 // the pin for the LED
#define LED10 10 // the pin for the LED
#define LED11 11
#include <Servo.h>
#include <math.h>
 
Servo myservo;              
int count =0;
int i =0;
int pos = 0; 
int brightness = 0;    // how bright the LED is
int fadeAmount = 5;    // how many points to fade the LED by


void setup() { // bring the LED up nicely from being off
 
 pinMode(LED9, OUTPUT); 
 pinMode(LED10, OUTPUT); 
 pinMode(LED11, OUTPUT);
 myservo.attach(8);
 Serial.begin(9600);
  
}
void loop()                     
{
  
if(Serial.available())
{
  int c = Serial.read();  
  switch (c){
  case '1':    
      State0();           
      break;
  case '2':    
      State1();           
      break;
  case '3':    
      State2();           
      break;
  case '4':    
      State3();           
      break;
  case '5':    
      State4();           
      break;
  case '6':    
      State5();           
      break;
  case '7':    
      State6();           
      break;    
  case'0':

      for (int thisPin = 9; thisPin < 12; thisPin++) {

        digitalWrite(thisPin, LOW);
      }
    break;
  }
 }
}
void State0(){
  while(!Serial.available()){
    digitalWrite(LED9, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(300);               // wait for a second
    digitalWrite(LED9, LOW);    // turn the LED off by making the voltage LOW
    delay(300);
  }
  digitalWrite(LED9,LOW);
}
void State1(){
  
 while(!Serial.available()){
    digitalWrite(LED9, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(1000);               // wait for a second
    digitalWrite(LED9, LOW);    // turn the LED off by making the voltage LOW
    delay(1000);
  }
  digitalWrite(LED9,LOW);
} 
void State2(){
  while(!Serial.available()){
    digitalWrite(LED9, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(1500);               // wait for a second
    digitalWrite(LED9, LOW);    // turn the LED off by making the voltage LOW
    delay(1500);
  }
  digitalWrite(LED9,LOW);
} 
void State3(){
  while(!Serial.available()){
  float val = (exp(sin(millis()/2000.0*PI)) - 0.36787944)*108.0;
  analogWrite(LED11, val); 
  }
   analogWrite(LED11, LOW); 

  
} 
void State4(){
  
  while(!Serial.available()){
    digitalWrite(LED10, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(200);               // wait for a second
    digitalWrite(LED10, LOW);    // turn the LED off by making the voltage LOW
    delay(200);
    servoState1();
  }
  digitalWrite(LED10,LOW);
  myservo.write(90);
  
} 
void State5(){
   while(!Serial.available()){
     servoState2();
    digitalWrite(LED10, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(100);               // wait for a second
    digitalWrite(LED10, LOW);    // turn the LED off by making the voltage LOW
    delay(100);
  }
  digitalWrite(LED10,LOW);
  myservo.write(90);
  
  
}
void State6(){
  
   while(!Serial.available()){
     servoState3();
    digitalWrite(LED10, HIGH);   // turn the LED on (HIGH is the voltage level)
    delay(30);               // wait for a second
    digitalWrite(LED10, LOW);    // turn the LED off by making the voltage LOW
    delay(25);
  }
  digitalWrite(LED10,LOW);
  myservo.write(90);
  
} 
 // Servo States 3 Intensity  
void servoState1()
{
  for(pos = 0; pos < 180; pos += 1)  // goes from 0 degrees to 180 degrees 
  {                                  // in steps of 1 degree 
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 
  for(pos = 180; pos>=1; pos-=1)     // goes from 180 degrees to 0 degrees 
  {                                
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 

}

void servoState2()
{
  for(pos = 0; pos < 180; pos += 3)  // goes from 0 degrees to 180 degrees 
  {                                  // in steps of 1 degree 
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 
  for(pos = 180; pos>=1; pos-=3)     // goes from 180 degrees to 0 degrees 
  {                                
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 

}
void servoState3()
{
  for(pos = 0; pos < 180; pos += 10)  // goes from 0 degrees to 180 degrees 
  {                                  // in steps of 1 degree 
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 
  for(pos = 180; pos>=1; pos-=10)     // goes from 180 degrees to 0 degrees 
  {                                
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  } 

}
 
 
