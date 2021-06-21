byte buttons[] = {2, 3, 4, 5, 6}; // pin numbers of the buttons that we'll use
int GatePeople[5];
#define NUMBUTTONS sizeof(buttons)
int buttonState[NUMBUTTONS];
int lastButtonState[NUMBUTTONS];
boolean buttonIsPressed[NUMBUTTONS];
long lastDebounceTime = 0; //the last time the output pin was toggled
long debounceDelay = 50; //the debounce time; increase if the output flickers

int gateNum = 1;
bool isToilet = false;
char GateStat = 'G';
char GateQueue = 'Q';
int GateCount[] = {0, 0, 0, 0, 0};
int ToiletCount[] = {0, 0, 0, 0, 0};

bool 

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
        if(GateStat == 'G')
        {
          GateCount[gateNum - 1]++;
          Serial.print(GateStat);
          Serial.print(gateNum);
          Serial.print("#");
          Serial.println(GateCount[gateNum - 1]);
        }
        else
        {
          ToiletCount[gateNum - 1]++;
          Serial.print(GateStat);
          Serial.print(gateNum);
          Serial.print("#");
          Serial.println(ToiletCount[gateNum - 1]);
        }
      }
      else if (buttons[currentButton] == 3)   //DECREMENT
      {

        if(GateStat == 'G')
        {
          GateCount[gateNum - 1]--;
          if (GateCount[gateNum - 1] < 0)
          {
            GateCount[gateNum - 1] = 0;
          }

          Serial.print(GateStat);
          Serial.print(gateNum);
          Serial.print("#");
          Serial.println(GateCount[gateNum - 1]);
        }
        else
        {
          ToiletCount[gateNum - 1]--;
          if (ToiletCount[gateNum - 1] < 0)
          {
            ToiletCount[gateNum - 1] = 0;
          }

          Serial.print(GateStat);
          Serial.print(gateNum);
          Serial.print("#");
          Serial.println(ToiletCount[gateNum - 1]);
        }
      }
      else if (buttons[currentButton] == 4)     //QUEUE
      {
        Serial.print(GateStat);
        Serial.print(gateNum);
        Serial.print("#");
        if (GateQueue == 'Q')
        {
          GateQueue = 'N';
        }
        else
        {
          GateQueue = 'Q';
        }
        Serial.println(GateQueue);
      }
      else if (buttons[currentButton] == 5)     //HELP
      {
        if(GateStat == 'G')
        {
          Serial.print(GateStat);
          Serial.print(gateNum);
          Serial.print("#");
          Serial.println("HELP");
        }
      }
      else if (buttons[currentButton] == 6)     //CHANGE GATE NUMBER + TOILET
      {
        gateNum++;
        if (gateNum > 5)
        {
          gateNum = 1;
          isToilet = !isToilet;
        }

        if (isToilet)
        {
          GateStat = 'T';
        }
        else
        {
          GateStat = 'G';
        }
      }
      buttonIsPressed[currentButton] = false;
    }
  }
}
