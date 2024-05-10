using Godot;
using System;
using System.Collections.Generic;

public partial class TexListener : TextureRect
{
	private string ss;
	private string aperture;
	private string iso;

	private string prevImageName;

	private Dictionary<string, Texture2D> _loadedTextures = new Dictionary<string, Texture2D>();
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
		string s = GetImagePath();
		if (prevImageName == s)
		{
			return;
		}

		if (_loadedTextures.TryGetValue(s, out var texture))
		{
			Texture = texture;
		}
		else
		{
			GD.Print("Load Image: " + s);
			if (ResourceLoader.Exists(s))
			{
				_loadedTextures[s] = GD.Load<Texture2D>(s);
				Texture = _loadedTextures[s];
			}
			else
			{
				//:(
			}
		}

		prevImageName = s;
		this.QueueRedraw();
	}

	private string GetImagePath()
	{
		return $"res://images/s{ss}_a{aperture}_iso{iso}.jpg";
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
