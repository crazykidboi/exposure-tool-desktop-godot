using Godot;
using System;

public partial class slider : HSlider
{
	[Signal]
	public delegate void OnValueChangedEventHandler(string newValue);
	[Export]
	public string[] values;
	public override void _Ready()
	{
		this.MinValue = 0;
		this.MaxValue = values.Length - 1; 
		
		base._Ready();
	}

	public override void _GuiInput(InputEvent @event)
	{
		EmitSignal(SignalName.OnValueChanged, values[(int)this.Value]);
		
		base._GuiInput(@event);
	}
}
