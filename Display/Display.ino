byte buttons[] = {2, 3, 4, 5, 6}; // pin numbers of the buttons that we'll use
int GatePeople[5];
#define NUMBUTTONS sizeof(buttons)
int buttonState[NUMBUTTONS];
int lastButtonState[NUMBUTTONS];
boolean buttonIsPressed[NUMBUTTONS];
long lastDebounceTime = 0; //the last time the output pin was toggled
long debounceDelay = 50; //the debounce time; increase if the output flickers

int gateNum = 1;
char GateMess = 'I';
char GateStatus = 'O';
int OtherGate = 2;

void setup()
{
  Serial.begin(115200);

  for (int i = 0; i < (NUMBUTTONS - 1); i++)
  {
    pinMode(i, INPUT);
    lastButtonState[i] = LOW;
    buttonIsPressed[i] = false;
  }
}

void loop()
{
  check_buttons();
  action();
}

void check_buttons()
{
  for (int currentButton = 0; currentButton < NUMBUTTONS; currentButton++)
  {
    int reading = digitalRead(buttons[currentButton]);

    if (reading != lastButtonState[currentButton])
    {
      lastDebounceTime = millis();
    }

    if ((millis() - lastDebounceTime) > debounceDelay)
    {
      if (reading != buttonState[currentButton])
      {
        buttonState[currentButton] = reading;
        if (buttonState[currentButton] == HIGH)
        {
          buttonIsPressed[currentButton] = true;
        }
      }
    }
    lastButtonState[currentButton] = reading;
  }
}

void action()
{
  for (int currentButton = 0; currentButton < NUMBUTTONS; currentButton++)
  {
    if (buttonIsPressed[currentButton])
    {
      //      Serial.print("button "); Serial.println(buttons[currentButton]);
      if (buttons[currentButton] == 2)      //INCREMENT
      {
        Serial.print(GateMess);
        Serial.print("#");
        Serial.print(gateNum);
        Serial.print("#");
        Serial.print(GateStatus);
        Serial.print("#");
        Serial.println(OtherGate);
        gateNum++;
      }
      else if (buttons[currentButton] == 3)   //DECREMENT
      {
        Serial.print(GateMess);
        Serial.print("#");
        Serial.print(gateNum);
        Serial.print("#");
        Serial.print(GateStatus);
        Serial.print("#");
        Serial.println(OtherGate);
        gateNum--;
      }
      else if (buttons[currentButton] == 4)     //QUEUE
      {
       OtherGate++;
      }
      else if (buttons[currentButton] == 5)     //HELP
      {
        OtherGate--;
        if(OtherGate < 0)
        {
          OtherGate = 0;
        }
      }
      else if (buttons[currentButton] == 6)     //CHANGE GATE NUMBER + TOILET
      {
        if (GateStatus == 'O')
        {
          GateStatus = 'C';
        }
        else
        {
          GateStatus = 'O';
        }
      }
      buttonIsPressed[currentButton] = false;
    }
  }
}
