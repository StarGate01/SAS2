void(*resetFunc) (void) = 0;
bool waitsForSYN;
byte command[3];
byte commandPosition;

void setup()
{
	for (int i = 0; i < 14; i++) pinMode(i, INPUT);
	waitsForSYN = true;
	Serial.begin(9600);
}

void loop()
{
	if (Serial.available() > 0)
	{
		byte data = Serial.read();
		if (waitsForSYN)
		{
			if (data == 0x42)
			{
				waitsForSYN = false;
				commandPosition = 0;
				Serial.write(0x13);
			}
		}
		else
		{
			if (commandPosition <= 2)
			{
				command[commandPosition] = data;
				commandPosition++;
			}
		}
	}
	else if (commandPosition > 2)
	{
		switch (command[0])
		{
			case 0x00:
				byte dataOut[14];
				for (int i = 0; i < 8; i++) if (digitalRead(i) == HIGH) dataOut[0] |= 1 << i;
				for (int i = 0; i < 6; i++) if (digitalRead(i + 8) == HIGH) dataOut[1] |= 1 << i;
				for (int i = 0; i < 6; i++)
				{
					int value = analogRead(i);
					dataOut[2 + (i * 2)] = highByte(value);
					dataOut[3 + (i * 2)] = lowByte(value);
				}
				Serial.write(dataOut, 14);
				break;
			case 0x01:
				pinMode(command[1], (command[2] == 0x00) ? INPUT : OUTPUT);
				break;
			case 0x02:
				digitalWrite(command[1], (command[2] == 0x00) ? LOW : HIGH);
				break;
			case 0x03:
				analogWrite(command[1], command[2]);
				break;
			case 0x04:
				Serial.write(0x66);
				Serial.flush();
				resetFunc();
				break;
		}
		waitsForSYN = true;
		Serial.write(0x66);
	}
	Serial.flush();
}
