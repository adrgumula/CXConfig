﻿namespace CXConfig;

using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using CXConfig.View;
using CXConfig.Methods;

public partial class MainPage : ContentPage
{
	private int count = 0;
	private readonly int sliderIncrement = 5;

	protected ObservableCollection<BottleItem> BottleItems { get; set; }
	public List<string> ComboBoxItems { get; set; }


	public MainPage()
	{
		InitializeComponent();
		UpdateTheListview();
		BottleItems = new ObservableCollection<BottleItem>();

		ComboBoxItems = new List<string> { "Option 1", "Option 2", "Option 3", "Option 4" };

		BindingContext = this;

		// Add gesture to toggle dropdown visibility
		var tapGesture = new TapGestureRecognizer();
		tapGesture.Tapped += (s, e) =>
		{
			ComboBoxListView.IsVisible = !ComboBoxListView.IsVisible;
		};
		ComboBoxFrame.GestureRecognizers.Add(tapGesture);

		// Handle item selection
		ComboBoxListView.ItemSelected += (s, e) =>
		{
			if (e.SelectedItem != null)
			{
				ComboBoxLabel.Text = e.SelectedItem.ToString();
				SelectedLabel.Text = $"Selected: {e.SelectedItem}";
				ComboBoxListView.IsVisible = false;
			}
		};
	}

	private string GetCXPatchedBottlesFolder(){
		var homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#if DEBUG
		//var parts = homeDirectory.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
		//var localFolderName = Path.Combine(@"/",parts[0], parts[1], "CXPBottles");
		var localFolderName = Path.Combine(@"/", homeDirectory, Common.Names.CXPatcherBottleFolderName);
#else
		var localFolderName = Path.Combine(@"/", homeDirectory, Common.Names.CXPatcherBottleFolderName);
#endif
		return localFolderName;
	}
	private void UpdateTheListview()
	{
		// @"c:\", "p*", SearchOption.TopDirectoryOnly

		//homeDirectory = new NSFileManager().GetUrls(NSSearchPathDirectory.DesktopDirectory, NSSearchPathDomain.User)[0].Path;
		var cxpatchedBottlesFolder = GetCXPatchedBottlesFolder();

		//MessageBox.ShowCallback("Info", $"FolderName: '{cxpatchedBottlesFolder}'");
		//Console.WriteLine($"Processing: '{cxpatchedBottlesFolder}'");
		try
		{
			var foldersFullPath = Directory.GetDirectories(cxpatchedBottlesFolder);

			if (foldersFullPath is not null)
			{
				BottleItems.Clear();
				foreach (var folder in foldersFullPath)
				{
					var parts = folder.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
					var bottleConfigFileFullPath = Path.Combine(folder, Common.Files.CXBottleConfig);
					var bottleDictionary = Common.BottlesConfigFileProcessor.PhaseFile(bottleConfigFileFullPath);
                    // var localFolderName = System.IO.Path.Combine(parts[0], parts[1]);

                    // //var lastDirectoryName = Path.GetFileName(folder.TrimEnd(Path.DirectorySeparatorChar));

                    //list.Add(parts.Last());
                    BottleItems.Add(
						new BottleItem(
                        	parts.Last(),
                        	folder,
							string.Empty,
							"Description",
							string.Empty,
							bottleDictionary
						)
					);
				}
			}

		}
		catch (Exception ex)
		{

            MessageBox.ShowCallback(
				"Permission needed", 
				"To access the user folder, this application requires Full Disk Access permissions. Please enable Full Disk Access for this application in your system’s settings to proceed.", 
				val => { 
					if(val) 
						Device.BeginInvokeOnMainThread(UpdateTheListview);
				},
				"Repeat", 
				"Cancel");


			Debug.WriteLine($"Exception: {ex.ToString()} - {ex.InnerException?.ToString()}");
			// for (var i = 1; i < 25; ++i)
			// 	list.Add($"CXPatcher bottle {i}");
		}


		listOfCXBottles.ItemsSource = BottleItems;
	}

	private void Refresh(){
		// SemanticScreenReader.Announce(CounterBtn.Text);
		// SemanticScreenReader.Announce(CounterBtn2.Text);
	}
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1){
			//CounterBtn2.Text = $"Clicked {count} time";
		}
		else{
			//CounterBtn2.Text = $"Clicked {count} times";
		}
		Refresh();
	}

	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e){
		var sliderCorrectValue = (int)(e.NewValue / sliderIncrement) * sliderIncrement;
		//CounterBtn2.Text = sliderCorrectValue.ToString();
		//Refresh();
	}

	private void OnStepperValueChanged(object sender, ValueChangedEventArgs e){
		//CounterBtn2.Text = e.NewValue.ToString();
		//Refresh();
	}
}

