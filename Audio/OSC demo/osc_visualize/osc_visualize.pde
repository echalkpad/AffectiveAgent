import oscP5.*;
import netP5.*;
  
OscP5 oscP5;

boolean speakers[] = new boolean[2];

void setup() {
  size(400,400);
  frameRate(25);
  noStroke();
  smooth();

  oscP5 = new OscP5(this, 7400);
  oscP5.plug(this, "speaker1", "/speaker1");
  oscP5.plug(this, "speaker2", "/speaker2");
}


void draw() {
  background(128);  
  
  for(int i = 0; i < speakers.length; i++) {
    if (speakers[1]) {
      fill(0, 255, 0);  
    } else {
      fill (255, 0, 0);
    }

    ellipse(((width/2) * i) + width/4, height/2, width/2, height/2);    
  }
}

public void speaker1(int value) {
  speakers[0] = (value == 1);
}

public void speaker2(int value) {
  speakers[1] = (value == 1);
}
 
