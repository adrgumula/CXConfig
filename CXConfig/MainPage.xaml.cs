namespace CXConfig;
using System.Linq;
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
		var parts = homeDirectory.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
		var localFolderName = System.IO.Path.Combine(@"/",parts[0], parts[1], "CXPBottles");
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
			var foldersFullPath = System.IO.Directory.GetDirectories(cxpatchedBottlesFolder);
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
		catch (System.Exception ex)
		{
			for (var i = 1; i < 25; ++i)
				list.Add($"CXPatcher bottle {i}");
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

