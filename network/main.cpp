#include "painlessMesh.h"

#define   MESH_PREFIX     "whateverYouLike"
#define   MESH_PASSWORD   "somethingSneaky"
#define   MESH_PORT       5555
#define BUTTON  0
#define BUTTONI  22
int value=0;
unsigned long lastdebouncetime = 0;
int reading;
int lastbuttonstate = 0;
int debouncetime = 50;
int buttonstate;
unsigned long lastdebouncetime1 = 0;
int reading1;
int lastbuttonstate1 = 0;
int buttonstate1;
Scheduler userScheduler; // to control your personal task
painlessMesh  mesh;

// User stub
void idle() ; // Prototype so PlatformIO doesn't complain

Task taskSendMessage( TASK_SECOND * 1 , TASK_FOREVER, &idle );
int read_Button ()
{
  int buttonState = digitalRead(BUTTON);
  if(buttonState != lastbuttonstate)
  {
    lastdebouncetime = millis();
  }
  if(millis() - lastdebouncetime > debouncetime)
  {
    if (buttonState != reading)
    {
      reading = buttonState;
      if(buttonState == LOW)
      {
        return 1;
      }
      else 
      {
        return 0;
      }
    }
  }
  lastbuttonstate = buttonState;
}
int read_ButtonI ()
{
  int buttonState1 = digitalRead(BUTTONI);
  if(buttonState1 != lastbuttonstate1)
  {
    lastdebouncetime1 = millis();
  }
  if(millis() - lastdebouncetime1 > debouncetime)
  {
    if (buttonState1 != reading1)
    {
      reading1 = buttonState1;
      if(buttonState1 == LOW)
      {
        return 1;
      }
      else 
      {
        return 0;
      }
    }
  }
  lastbuttonstate1 = buttonState1;
}

// Broadcast Message to increment the Nr of people
void incrementMeshMessage() {
  DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=1;
  msg["data"]=1;
    String str;
  serializeJson(msg, str);

  mesh.sendBroadcast(str);
}
// Broadcast Message to decrement the Nr of people

void decrementMeshMessage() {
  DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=1;
  msg["data"]=-1;
   String str;
  serializeJson(msg, str);
  mesh.sendBroadcast(str);
}
// Send message to destination server for help
void helpMeMessage(uint32_t dest){
    DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=2;
  msg["data"]=1;
   String str;
  serializeJson(msg, str);
  mesh.sendSingle(dest,str);
}
// Broadcast queue state 0 for none 1 for existing queue
void sendQueue(int state){
    DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=3;
  msg["data"]=state;
   String str;
  serializeJson(msg, str);
  mesh.sendBroadcast(str);
}
// Broadcast the Nr of people in
void reCheckData(){
  DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=4;
  msg["data"]=1;
   String str;
  serializeJson(msg, str);
  mesh.sendBroadcast(str);
}
void idle(){
if(read_Button()){
  decrementMeshMessage();
  value--;
}
else if (read_ButtonI()){
  incrementMeshMessage();
  value++;
}
}
// Needed for painless library
void receivedCallback( uint32_t from, String &msg ) {
  Serial.printf("startHere: Received from %u msg=%s\n", from, msg.c_str());
DynamicJsonDocument doc(1024);
deserializeJson(doc, msg);
int type=doc["type"];
int data=doc["data"];
if (type==1)
{
  value=value+data;
  Serial.print("Value: ");
  Serial.print(value);
  Serial.println();
}
else 
{
  Serial.println("Wrong type");
}



}

void newConnectionCallback(uint32_t nodeId) {
    Serial.printf("--> startHere: New Connection, nodeId = %u\n", nodeId);
}

void changedConnectionCallback() {
  Serial.printf("Changed connections\n");
}

void nodeTimeAdjustedCallback(int32_t offset) {
    Serial.printf("Adjusted time %u. Offset = %d\n", mesh.getNodeTime(),offset);
}

void setup() {
  Serial.begin(115200);
  pinMode(BUTTON,INPUT);
  pinMode(BUTTONI,INPUT);

//mesh.setDebugMsgTypes( ERROR | MESH_STATUS | CONNECTION | SYNC | COMMUNICATION | GENERAL | MSG_TYPES | REMOTE ); // all types on
  mesh.setDebugMsgTypes( ERROR | STARTUP );  // set before init() so that you can see startup messages

  mesh.init( MESH_PREFIX, MESH_PASSWORD, &userScheduler, MESH_PORT );
  mesh.onReceive(&receivedCallback);
  mesh.onNewConnection(&newConnectionCallback);
  mesh.onChangedConnections(&changedConnectionCallback);
  mesh.onNodeTimeAdjusted(&nodeTimeAdjustedCallback);

  userScheduler.addTask( taskSendMessage );
  taskSendMessage.enable();
}

void loop() {
  // it will run the user scheduler as well
  mesh.update();
}
