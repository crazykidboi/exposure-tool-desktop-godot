using Godot;
using System;

public partial class TexListener : TextureRect
{
	private string ss;
	private string aperture;
	private string iso;

	private string prevImageName;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void UpdateImage()
	{
		string s = GetImageName();
		if (prevImageName == s)
		{
			return;
		}

		prevImageName = s;
		GD.Print("Load Image: "+s);
	}

	private string GetImageName()
	{
		return $"{ss}_{aperture}_{iso}.jpg";
	}
	private void _on_ss_on_value_changed(string newValue)
	{
		ss = newValue;
		UpdateImage();
	}
	private void _on_iso_on_value_changed(string newValue)
	{
		// Replace with function body.
		iso = newValue;
		UpdateImage();
	}


	private void _on_aperture_on_value_changed(string newValue)
	{
		// Replace with function body.
		aperture = newValue;
		UpdateImage();
	}
}
