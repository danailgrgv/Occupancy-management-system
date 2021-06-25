// Node 3

#include "painlessMesh.h"

// WiFi Credentials
#define   MESH_PREFIX     "AccordingToYou"
#define   MESH_PASSWORD   "somethingSecret"
#define   MESH_PORT       5555 // default number and should be an integer


// As we want to read both the messages
int help, ppm, maxOccup, q, occCtr;


// Scheduler is used to synchronize the connection bw other nodes
Scheduler userScheduler; 
painlessMesh  mesh;


// Deserialize the message
void receivedCallback( uint32_t from, String &msg ) {

  Serial.println("Message from system");
  Serial.println("Message ="); Serial.println(msg);
  String json = msg.c_str();;
  DynamicJsonDocument doc(1024);
  DeserializationError error = deserializeJson(doc, json);
  if (error)
  {
    Serial.print("deserializeJson() failed: ");
    Serial.println(error.c_str());
  }

  help = doc["HELP"];

  if(help == 1)
  {
    Serial.print("G1#");
//    Serial.print(from);
//    Serial.print("#");
    Serial.println("HELP");
  }
  
  ppm = doc["PPM"];
  maxOccup = doc["MO"];
  q = doc["Q"];
  occCtr = doc["occCounter"];

  if(occCtr != 0)
  {
  Serial.print("G1#");
  Serial.println(occCtr);
  }
  if(ppm != 0){
    Serial.print("C#");
      Serial.println(ppm);
  }
  if(maxOccup != 0){
    Serial.print("MAX#");
    Serial.println(maxOccup);
  }

  if(q == 1){
    Serial.println("G1#Q");
  }else{
    Serial.println("G1#N");
  }
//  Serial.print("PPM: ");
//  Serial.println(PPM);

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
 
}

void loop() {
  
  mesh.update();
}
