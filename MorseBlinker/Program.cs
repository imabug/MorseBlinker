using System;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace MorseBlinker
{
  public class Program
  {
    private static void blinker(OutputPort p, string a)
    {
      int dit = 100;                    // dit length in milliseconds
      int dah = dit * 3;                // dah length in milliseconds
      int space = dit * 7;              // space length in milliseconds

      foreach (char sym in a)
      {
        switch (sym)
        {
          case '.':
            p.Write(true);
            Thread.Sleep(dit);
            p.Write(false);
            Thread.Sleep(dit);
            break;
          case '-':
            p.Write(true);
            Thread.Sleep(dah);
            p.Write(false);
            Thread.Sleep(dit);
            break;
          case ' ':
            p.Write(false);
            Thread.Sleep(space);
            break;
          default:
            break;
        }
      }
      p.Write(false);
      Thread.Sleep(dit * 3);    // space between characters

    }
    public static void Main()
    {
      Hashtable morse = new Hashtable();

      morse.Add('a', ".-");
      morse.Add('b', "-...");
      morse.Add('c', "-.-.");
      morse.Add('d', "-..");
      morse.Add('e', ".");
      morse.Add('f', "..-.");
      morse.Add('g', "--.");
      morse.Add('h', "....");
      morse.Add('i', "..");
      morse.Add('j', ".---");
      morse.Add('k', "-.-");
      morse.Add('l', ".-..");
      morse.Add('m', "--");
      morse.Add('n', "-.");
      morse.Add('o', "---");
      morse.Add('p', ".--.");
      morse.Add('q', "--.-");
      morse.Add('r', ".-.");
      morse.Add('s', "...");
      morse.Add('t', "-");
      morse.Add('u', "..-");
      morse.Add('v', "...-");
      morse.Add('w', ".--");
      morse.Add('x', "-..-");
      morse.Add('y', "-.--");
      morse.Add('z', "--..");
      morse.Add('0', "-----");
      morse.Add('1', ".----");
      morse.Add('2', "..---");
      morse.Add('3', "...--");
      morse.Add('4', "....-");
      morse.Add('5', ".....");
      morse.Add('6', "-....");
      morse.Add('7', "--...");
      morse.Add('8', "---..");
      morse.Add('9', "----.");
      morse.Add(' ', " ");
      morse.Add('.', "·–·–·–");
      morse.Add(',', "--..--");
      morse.Add('?', "..--..");
      morse.Add('!', "-.-.--");
      morse.Add('/', "-..-.");

      string morseText = "nr4cb";

      OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

      while (true) {
        // go through all the characters in morseText
        foreach (char c in morseText)
        {
          // Get the morse code sequence for this character
          // string morseLetter = (string)morse[c.ToLower()];

          blinker(led, (string)morse[c.ToLower()]);

        }
        // Delay 1s before repeating the text
        led.Write(false);
        Thread.Sleep(1000);
      }
    }
  }
}
