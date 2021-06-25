// Node 1
#include "painlessMesh.h"
#include "gateServo.h"
#include "gateDetector.h"
//#include "co2Sensor.h"


// WiFi Credentials
#define   MESH_PREFIX     "AccordingToYou"
#define   MESH_PASSWORD   "somethingSecret"
#define   MESH_PORT       5555

//Pin Declaration

//CO2Sensor sens = CO2Sensor(MQ_PIN, LED);
Gate gate = Gate(PWM_FREQ, PWM_CH,PWM_RES, SERVO);
MovDetector D1 = MovDetector(TRIG_1, ECHO_1, LED_1);
MovDetector D2 = MovDetector(TRIG_2, ECHO_2, LED_2);

int dist1, dist2, occCounter;
unsigned long prevMill;
int help = 0;
int flag;

const int BTN_RIGHT = 4;
int btnR_Prev = HIGH; //btn Right previous pos

unsigned long btnR_last_debounce_time = 0;
const int DEBOUNCE_DELAY = 50;
int btnR_State = HIGH;

Scheduler userScheduler; 
painlessMesh  mesh;
void sendMessage() ; 
Task taskSendMessage( TASK_SECOND * 1 , TASK_FOREVER, &sendMessage );
void sendMessage()
{
  Serial.println();
  Serial.println("Start Sending....");
  
  // Serializing in JSON Format
  DynamicJsonDocument doc(1024);
  doc["occCounter"] = occCounter;
  doc["HELP"] = help;
  String msg ;
  serializeJson(doc, msg);
  
  mesh.sendBroadcast( msg );
  Serial.println("Message from Node1");
  Serial.println(msg);
  taskSendMessage.setInterval((TASK_SECOND * 1, TASK_SECOND * 10));
}
// Needed for painless library
void receivedCallback( uint32_t from, String &msg ) {
  Serial.println();
  Serial.print("Message = ");Serial.println(msg);
  String json;
  DynamicJsonDocument doc(1024);
  json = msg.c_str();
  DeserializationError error = deserializeJson(doc, json);
  if (error)
  {
    Serial.print("deserializeJson() failed: ");
    Serial.println(error.c_str());
  }

//  LState = doc["Button"]; 
//  digitalWrite(LED, LState);
}
void newConnectionCallback(uint32_t nodeId) {
  Serial.printf("--> startHere: New Connection, nodeId = %u\n", nodeId);
}
void changedConnectionCallback() {
  Serial.printf("Changed connections\n");
}
void nodeTimeAdjustedCallback(int32_t offset) {
  Serial.printf("Adjusted time %u. Offset = %d\n", mesh.getNodeTime(), offset);
}
void setup() {
  Serial.begin(115200);
  
  mesh.setDebugMsgTypes( ERROR | STARTUP );  
  mesh.init( MESH_PREFIX, MESH_PASSWORD, &userScheduler, MESH_PORT );
  mesh.onReceive(&receivedCallback);
  mesh.onNewConnection(&newConnectionCallback);
  mesh.onChangedConnections(&changedConnectionCallback);
  mesh.onNodeTimeAdjusted(&nodeTimeAdjustedCallback);
  userScheduler.addTask( taskSendMessage );
  taskSendMessage.enable();

  pinMode(BTN_RIGHT, INPUT_PULLUP);
}
void loop() {
  mesh.update();
  
     dist1 = D1.measureDist();
   dist2 = D2.measureDist();
  
  occupCounter(dist1, dist2);

   int val = btnRIsPressed();
   if(!flag){
     if(val == 1){
      help = 1;
      flag = 1;
      Serial.println("HELP");
     }
   }
   else
   {
    if(flag){
      if(val == 1)
      {
        help = 0;
        flag = 0;
        Serial.println("NO HELP");
      }
    }
   }
}


int occupCounter(int dist1, int dist2){

      if((dist1 > 0 && dist1 <= 10) && !(dist2 > 0 && dist2 <=10))
  {
    gate.openGate();
    digitalWrite(LED_1, HIGH);
     if(millis() - prevMill > 5000)

 {
    prevMill = millis();
    occCounter++;
//    Serial.print("G1#");
//    Serial.println(occCounter);
    
//    digitalWrite(LED_1, LOW);
    
    
    return occCounter;
//    delay(5000);
 }


  }
  else if(!(dist1 > 0 && dist1 <= 10) && (dist2 > 0 && dist2 <= 10)){
    gate.openGate();
    digitalWrite(LED_2, HIGH);
     if(millis() - prevMill > 5000)

 {
   prevMill = millis();
    occCounter--;
//    Serial.print("G1#");
//    Serial.println(occCounter);
//    digitalWrite(LED_2, LOW);
    return occCounter;
//    delay(5000);
 }
  }
  else
  {
    gate.closeGate();
    digitalWrite(LED_1, LOW);
    digitalWrite(LED_2, LOW);
  }
}

int btnRIsPressed() //Function for debouncing Right button
{
  int stateR = 0;
  int btn_read_R = digitalRead(BTN_RIGHT);

  if (btn_read_R != btnR_Prev)
  {
    btnR_last_debounce_time = millis();
  }
  if (millis() > (btnR_last_debounce_time + DEBOUNCE_DELAY))
  {
    if (btn_read_R != btnR_State)
    {
      btnR_State = btn_read_R;
      if (btnR_State == LOW)
      {
        stateR = 1;
      }
    }
  }
  btnR_Prev = btn_read_R;
  return stateR;
}
