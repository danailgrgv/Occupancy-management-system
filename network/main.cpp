#include "painlessMesh.h"

#define   MESH_PREFIX     "whateverYouLike"
#define   MESH_PASSWORD   "somethingSneaky"
#define   MESH_PORT       5555
int value=0;

Scheduler userScheduler; // to control your personal task
painlessMesh  mesh;

// User stub
void idle() ; // Prototype so PlatformIO doesn't complain

Task taskSendMessage( TASK_SECOND * 1 , TASK_FOREVER, &idle );

int onGateReceive()
{
  // read I2C
  uint8_t msg = 0;
  if(Serial.available() > 0)
  {
    Serial.read(msg);
  }
  return msg;
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
void helpMeMessage(uint32_t dest)
{
  DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=2;
  msg["data"]=1;
   String str;
  serializeJson(msg, str);
  mesh.sendSingle(dest,str);
}
// Broadcast queue state 0 for none 1 for existing queue
void sendQueue(int state)
{
  DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=3;
  msg["data"]=state;
   String str;
  serializeJson(msg, str);
  mesh.sendBroadcast(str);
}
// Broadcast the Nr of people in
void reCheckData()
{
  DynamicJsonDocument jsonBuffer(1024);
  JsonObject msg = jsonBuffer.to<JsonObject>();
  msg["type"]=4;
  msg["data"]=1;
   String str;
  serializeJson(msg, str);
  mesh.sendBroadcast(str);
}
void idle()
{
  int handle = onGateReceive();
  switch(handle)
  {
    case 1:
    {
      incrementMeshMessage();
      value ++;
      break;
    }
    case 2:
    {
      decrementMeshMessage();
      value--;
      break;
    }
    case 3:
    {
      Serial.println("Help");
      break;
    }
    case 4:
    {
      Serial.println("Queue");
      sendQueue(1);
      break;
    }
    case 5:
    {
      Serial.println("No Queue");
      sendQueue(0);
      break;
    }
    default:
    {
      break;
    }
  }
}
// Needed for painless library
void receivedCallback( uint32_t from, String &msg )
{
  Serial.printf("startHere: Received from %u msg=%s\n", from, msg.c_str());
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, msg);
  int type=doc["type"];
  int data=doc["data"];
  switch(type)
  {
    case 1:
    {
      value = value + data;
      Serial.print("Value: ");
      Serial.print(value);
      Serial.println();
      break;
    }
    case 2:
    {
      Serial.println("Help");
      break;
    }
    case 3:
    {
      if(data)
      {
        Serial.print("Queue on gate ");
        Serial.println(from);
      }
      else
      {
        Serial.print("No queue on gate ");
        Serial.println(from);
      }
      break;
    }
    default:
    {
      Serial.println("Wrong type");
      break;
    }
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
