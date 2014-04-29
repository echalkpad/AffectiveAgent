#define LED 9 // the pin for the LED
#define LED10 10 // the pin for the LED
#define LED11 11
#include <Servo.h> 
 
Servo myservo;              
int count =0;
int i =0;
int pos = 0; 
int brightness = 0;    // how bright the LED is
int fadeAmount = 5;    // how many points to fade the LED by


void setup() { // bring the LED up nicely from being off
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
  
    digitalWrite(LED11,HIGH);
}
void State1(){
  
 digitalWrite(LED10,HIGH);  
  
} 
void State2(){
  
  digitalWrite(LED, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(1000);               // wait for a second
  digitalWrite(LED, LOW);    // turn the LED off by making the voltage LOW
  delay(1000);   
  
} 
void State3(){
  
  
  
} 
void State4(){
  
  
  
} 
void State5(){
  
  
  
}
void State6(){
  
  
  
} 
    
    
 
 
