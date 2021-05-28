
// Demonstrates use of the WireSlave library for ESP32.
// Sends data as an I2C/TWI slave device; data is packed using WirePacker.
// In order to the slave send the data, an empty packet must
// be received first. This is internally done by the WireSlaveRequest class.
// The data is sent using WirePacker, also done internally by WireSlave.
// Refer to the "master_reader" example for use with this

#include <Arduino.h>
#include <Wire.h>
#include <WireSlave.h>


#define SDA_PIN 21
#define SCL_PIN 22
#define I2C_SLAVE_ADDR 0x04

void receiveEvent(int howMany);
void requestEvent();

void setup()
{
    Serial.begin(115200);

    bool res = WireSlave.begin(SDA_PIN, SCL_PIN, I2C_SLAVE_ADDR);
    if (!res) {
        Serial.println("I2C slave init failed");
        while(1) delay(100);
    }

    WireSlave.onRequest(requestEvent);
    WireSlave.onReceive(receiveEvent);
    Serial.printf("Slave joined I2C bus with addr %d!\n", I2C_SLAVE_ADDR);
}

void loop()
{
    // the slave response time is directly related to how often
    // this update() method is called, so avoid using long delays
    // inside loop(), and be careful with time-consuming tasks
    WireSlave.update();

    // let I2C and other ESP32 peripherals interrupts work
    delay(1);
}

// function that executes whenever a complete and valid packet
// is received from master
// this function is registered as an event, see setup()
void receiveEvent(int howMany)
{
    while (WireSlave.available()) // loop through all
    {
        char c = WireSlave.read();  // receive byte as a character
        Serial.print(c);            // print the character
    }
    Serial.println();          // print line
}


void requestEvent()
{
    WireSlave.write("From the ESP!");
}