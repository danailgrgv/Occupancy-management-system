// Node 1
#include "painlessMesh.h"
#include "co2Sensor.h"
#include "QueueDetector.h"
#include "Algorithm.h" 

// WiFi Credentials
#define   MESH_PREFIX     "AccordingToYou"
#define   MESH_PASSWORD   "somethingSecret"
#define   MESH_PORT       5555

CO2Sensor sens = CO2Sensor(MQ_PIN, LED);
QueueDetector QD = QueueDetector(TRIG,ECHO,LED);  
Algorithm alg = Algorithm(CO2_P, AIR_INFL, MAX_PPM, MAX_OCCUP);

int help = 0;
int flag;

const int BTN_RIGHT = 4;
int btnR_Prev = HIGH; //btn Right previous pos

unsigned long btnR_last_debounce_time = 0;
const int DEBOUNCE_DELAY = 50;
int btnR_State = HIGH;

int qDetected = 0;
unsigned long prevMillis;

int maxOccupancy;

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
  doc["PPM"] = sens.getPPM();
  doc["Q"] = qDetected;
  doc["MO"] = maxOccupancy;
  String msg ;
  serializeJson(doc, msg);
  
  mesh.sendBroadcast( msg );
  Serial.println("G1");
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
  pinMode(BTN_RIGHT, INPUT_PULLUP);
   
  mesh.setDebugMsgTypes( ERROR | STARTUP );  
  mesh.init( MESH_PREFIX, MESH_PASSWORD, &userScheduler, MESH_PORT );
  mesh.onReceive(&receivedCallback);
  mesh.onNewConnection(&newConnectionCallback);
  mesh.onChangedConnections(&changedConnectionCallback);
  mesh.onNodeTimeAdjusted(&nodeTimeAdjustedCallback);
  userScheduler.addTask( taskSendMessage );
  taskSendMessage.enable();

 
}
void loop() {
  mesh.update();
    detectQueue();
    int PPM =sens.getPPM();
    maxOccupancy = alg.getCurMaxOccup(PPM);

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

int btnRIsPressed(void) //Function for debouncing Right button
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

void detectQueue(void){

int  distance = QD.measureDist();
//  QD.printDist(distance);
  
  if(millis() - prevMillis > THRESHOLD){
    prevMillis = millis();

    if(qDetected == 0){
      if(distance <= 100)
      {
        Serial.println("G1#Q");
        qDetected = 1;
        digitalWrite(LED, HIGH);
      }
    }
    else if(qDetected == 1)
    {
            if(distance > 100)
      {
        qDetected = 0;
        Serial.println("G1#N");
        digitalWrite(LED, LOW);
      }
    }
  }
}
