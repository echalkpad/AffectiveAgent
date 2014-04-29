#define LED 9 // the pin for the LED
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
 for(i = 0 ; i <= 15; i+=1)
  {
    analogWrite(LED, i);
    delay(5);
  }
 pinMode(LED, OUTPUT); 
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
    digitalWrite(LED11,HIGH);
  }
  digitalWrite(LED11,LOW);
}
void State1(){
  while(!Serial.available()){
  
    digitalWrite(LED10,HIGH); 
  } 
  digitalWrite(LED10,LOW); 
} 
void State2(){
  while(!Serial.available()){
  digitalWrite(LED, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(1000);               // wait for a second
  digitalWrite(LED, LOW);    // turn the LED off by making the voltage LOW
  delay(1000); 
  }  
  digitalWrite(LED, LOW);
} 
void State3(){
  
   
  while(!Serial.available()){
  float val = (exp(sin(millis()/2000.0*PI)) - 0.36787944)*108.0;
  analogWrite(LED11, val); 

  }
    analogWrite(LED11, LOW); 
  
} 
void State4(){
  
  
  
} 
void State5(){
  
  
  
}
void State6(){
  
  
  
} 
    
    
 
 
