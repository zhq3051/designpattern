using System;
using System.Text;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Simple remote control test
            //Light light = new Light();
            //Command lightOn = new LightOnCommand(light);

            //SimpleRemoteControl remote = new SimpleRemoteControl();
            //remote.SetCommand(lightOn);
            //remote.ButtonPressed();

            //GarageDoor door = new GarageDoor();
            //GaraDoorOpenCommand garageOpen = new GaraDoorOpenCommand(door);
            //remote.SetCommand(garageOpen);
            //remote.ButtonPressed(); 
            #endregion

            #region remote control
            //Light kitchenLight = new Light("kichen");
            //Light bedroomLight = new Light("bedroom");
            //Stereo parlorStereo = new Stereo("parlor");
            //Stereo washRommStereo = new Stereo("washroom");
            //GarageDoor garageDoor = new GarageDoor(string.Empty);

            //LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            //LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);
            //StereoOnWithCDCommand parlorStereoOn = new StereoOnWithCDCommand(parlorStereo);
            //StereoOffCommand parloStereoOff = new StereoOffCommand(parlorStereo);
            //GaraDoorOpenCommand garageDoorOpen = new GaraDoorOpenCommand(garageDoor);
            //GaraDoorCloseCommand garageDoorClose = new GaraDoorCloseCommand(garageDoor);

            //RemoteControl remoteControl = new RemoteControl();
            //remoteControl.SetCommand(0, kitchenLightOn, kitchenLightOff);
            //remoteControl.SetCommand(1, parlorStereoOn, parloStereoOff);
            //remoteControl.SetCommand(2, garageDoorOpen, garageDoorClose);

            //remoteControl.OnButtonWasPushed(2);
            //remoteControl.OffButtonWasPushed(2);
            //remoteControl.OnButtonWasPushed(1);
            //remoteControl.OnButtonWasPushed(0);
            //remoteControl.OffButtonWasPushed(0);
            //remoteControl.OffButtonWasPushed(1);

            //remoteControl.OnButtonWasPushed(3);
            //remoteControl.OffButtonWasPushed(4);

            #endregion

            #region remote control with undo
            //Light livintRoomLight = new Light("livingroom");
            //LightOnCommand livingRoomOn = new LightOnCommand(livintRoomLight);
            //LightOffCommand livingRommOff = new LightOffCommand(livintRoomLight);
            //RemoteControlWithUndo remoteUndo = new RemoteControlWithUndo();
            //remoteUndo.SetCommand(0, livingRoomOn, livingRommOff);
            //remoteUndo.OnButtonWasPushed(0);
            //remoteUndo.OffButtonWasPushed(0);
            //Console.WriteLine(remoteUndo.ToString());
            //remoteUndo.UndoButtonWasPushed();
            //remoteUndo.OffButtonWasPushed(0);
            //remoteUndo.OnButtonWasPushed(0);
            //Console.WriteLine(remoteUndo.ToString());
            //remoteUndo.UndoButtonWasPushed();

            #endregion

            Console.Read();
        }
    }

    #region Receiver
    public abstract class Entity
    {
        public string location;
        public Entity(string location)
        {
            this.location = location;
        }
    }

    public class Light : Entity
    {
        public Light(string location) : base(location)
        {
        }

        public string Name
        {
            get; set;
        }

        public void On()
        {
            Console.WriteLine(this.location + " lights on");
        }

        public void Off()
        {
            Console.WriteLine(this.location + " lights off");
        }
    }

    public class Stereo : Entity
    {
        public string location = string.Empty;

        public Stereo(string location): base(location)
        {
            this.location = location;
        }
        public void On()
        {
            Console.WriteLine(this.location + " Stereo on");
        }

        public void Off()
        {
            Console.WriteLine( this.location + " Stereo off");
        }

        public void SetCD()
        {
            Console.WriteLine(this.location + " Stereo set cd");
        }

        public void SetRadio()
        {
            Console.WriteLine(this.location + " Stereo set radio");
        }

        public void SetDvd()
        {
            Console.WriteLine(this.location + " Stereo set dvd");
        }

        public void SetVolume(int volumne)
        {
            Console.WriteLine(this.location + " Stero set volume to: " + volumne);
        }
    }

    public class GarageDoor :Entity
    {
        public GarageDoor(string location) : base(location)
        {
        }

        public void Open()
        {
            Console.WriteLine("Garage door open");
        }

        public void Close()
        {
            Console.WriteLine("Garage door close");
        }
    }

    public class CeilingFan : Entity
    {
        Speed speed;
        public CeilingFan(string location) : base(location)
        {
        }

        public void High()
        {
            speed = Speed.High;
        }

        public void Medium()
        {
            speed = Speed.Medium;
        }

        public void Low()
        {
            speed = Speed.Low;
        }

        public void Off()
        {
            speed = Speed.Off;
        }

        public Speed GetSpeed()
        {
            return this.speed;
        }
    }

    public enum Speed
    {
        Off = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }

    #endregion

    #region Command
    public interface Command
    {
        void Execute();

        void Undo();    
    }

    public class LightOnCommand : Command
    {
        Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.On();
        }

        public void Undo()
        {
            light.Off();
        }
    }

    public class LightOffCommand : Command
    {
        Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.Off();
        }

        public void Undo()
        {
            light.On();
        }
    }

    public class GaraDoorOpenCommand : Command
    {
        GarageDoor garageDoor;
        public GaraDoorOpenCommand(GarageDoor door)
        {
            garageDoor = door;
        }

        public void Execute()
        {
            garageDoor.Open();
        }

        public void Undo()
        {
            garageDoor.Close();
        }
    }

    public class GaraDoorCloseCommand : Command
    {
        GarageDoor garageDoor;
        public GaraDoorCloseCommand(GarageDoor door)
        {
            garageDoor = door;
        }

        public void Execute()
        {
            garageDoor.Close();
        }

        public void Undo()
        {
            garageDoor.Open();
        }
    }

    public class StereoOnWithCDCommand : Command
    {
        private Stereo stereo;
        public StereoOnWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void Execute()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }

        public void Undo()
        {
            stereo.Off();
        }
    }

    public class StereoOffCommand : Command
    {
        private Stereo stereo;
        public StereoOffCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void Execute()
        {
            stereo.Off();
        }

        public void Undo()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }
    }

    public class CeilingFanHighSpeedCommand : Command
    {
        CeilingFan fan;
        Speed prevSpeed;

        public CeilingFanHighSpeedCommand(CeilingFan ceilingFan)
        {
            fan = ceilingFan;
        }
        public void Execute()
        {
            prevSpeed = fan.GetSpeed();
            fan.High();
        }

        public void Undo()
        {
            switch (prevSpeed) {
                case Speed.High:
                    fan.High();
                    break;
                case Speed.Low:
                    fan.Low();
                    break;
                case Speed.Medium:
                    fan.Medium();
                    break;
                case Speed.Off:
                    fan.Off();
                    break;
                default:
                    fan.Off();
                    break;
            }

        }
    }

    public class NoCommand : Command
    {
        public void Execute()
        {
            Console.WriteLine("NoCommand executed");
        }

        public void Undo()
        {
            Console.WriteLine("NoCommand undo");
        }
    }
    #endregion

    #region Invoker
    public class SimpleRemoteControl
    {
        Command slot;

        public void SetCommand(Command command)
        {
            slot = command;
        }

        public void ButtonPressed()
        {
            slot.Execute();
        }
    }

    public class RemoteControl
    {
        Command[] onCommands;
        Command[] offCommands;

        public RemoteControl()
        {
            onCommands = new Command[7];
            offCommands = new Command[7];

            Command noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(string.Empty);
            builder.AppendLine("===============Remote Control======================");
            for (int i = 0; i < onCommands.Length; i++)
            {
                builder.AppendFormat("Slot {0}- On[{1}] / Off[{2}]{3}", i, onCommands[i].GetType().Name, offCommands[i].GetType().Name, Environment.NewLine);
            }

            return builder.ToString();
        }
    }

    public class RemoteControlWithUndo
    {
        Command[] onCommands;
        Command[] offCommands;
        Command undoCommand;

        public RemoteControlWithUndo()
        {
            onCommands = new Command[7];
            offCommands = new Command[7];

            Command noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }

            undoCommand = noCommand;
        }

        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();

            undoCommand = onCommands[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }

        public void UndoButtonWasPushed()
        {
            undoCommand.Undo();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(string.Empty);
            builder.AppendLine("===============Remote Control======================");
            for (int i = 0; i < onCommands.Length; i++)
            {
                builder.AppendFormat("Slot {0}- On[{1}] / Off[{2}]{3}", i, onCommands[i].GetType().Name, offCommands[i].GetType().Name, Environment.NewLine);
            }
            builder.AppendFormat("[undo] command: {0}{1}", undoCommand.GetType().Name, Environment.NewLine);
            return builder.ToString();
        }
    }
    #endregion
}