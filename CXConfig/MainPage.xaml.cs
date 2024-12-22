namespace CXConfig;

using System.Linq;
using System.IO;
using System.Diagnostics;

public partial class MainPage : ContentPage
{
	private int count = 0;
	private readonly int sliderIncrement = 5;

	public MainPage()
	{
		InitializeComponent();
		UpdateTheListview();
	}

	private string GetCXPatchedBottlesFolder(){
		var homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#if DEBUG
		//var parts = homeDirectory.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
		//var localFolderName = Path.Combine(@"/",parts[0], parts[1], "CXPBottles");
		var localFolderName = Path.Combine(@"/", homeDirectory, "CXPBottles");
#else
		var localFolderName = Path.Combine(@"/", homeDirectory, "CXPBottles");
#endif
		return localFolderName;
	}
	private void UpdateTheListview()
	{
		var list = new List<string>();

		// @"c:\", "p*", SearchOption.TopDirectoryOnly

		//homeDirectory = new NSFileManager().GetUrls(NSSearchPathDirectory.DesktopDirectory, NSSearchPathDomain.User)[0].Path;
		var cxpatchedBottlesFolder = GetCXPatchedBottlesFolder();

		try
		{
			var foldersFullPath = Directory.GetDirectories(cxpatchedBottlesFolder);
			if (foldersFullPath is not null)
			{
				foreach (var folder in foldersFullPath)
				{

					// var parts = folder.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
					// var localFolderName = System.IO.Path.Combine(parts[0], parts[1]);

					// //var lastDirectoryName = Path.GetFileName(folder.TrimEnd(Path.DirectorySeparatorChar));

					list.Add(folder);
				}
			}

		}
		catch (Exception ex)
		{

			CXConfig.Method.MessageBox.ShowCallback(
				"Pemition needed", 
				"In order to access the user folder you have to give full disk access this applicaiton", 
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


		listOfCXBottles.ItemsSource = list;
	}

	private void Refresh(){
		// SemanticScreenReader.Announce(CounterBtn.Text);
		// SemanticScreenReader.Announce(CounterBtn2.Text);
	}
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1){
			CounterBtn2.Text = $"Clicked {count} time";
		}
		else{
			CounterBtn2.Text = $"Clicked {count} times";
		}
		Refresh();
	}

	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e){
		var sliderCorrectValue = (int)(e.NewValue / sliderIncrement) * sliderIncrement;
		CounterBtn2.Text = sliderCorrectValue.ToString();
		//Refresh();
	}

	private void OnStepperValueChanged(object sender, ValueChangedEventArgs e){
		CounterBtn2.Text = e.NewValue.ToString();
		//Refresh();
	}
}

