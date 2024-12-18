namespace CXConfig;

public partial class MainPage : ContentPage
{
	private int count = 0;
	private readonly int sliderIncrement = 5;

	public MainPage()
	{
		InitializeComponent();
	}

	private void Refresh(){
		// SemanticScreenReader.Announce(CounterBtn.Text);
		// SemanticScreenReader.Announce(CounterBtn2.Text);
	}
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1){
			CounterBtn.Text = $"Clicked {count} time";
		}
		else{
			CounterBtn.Text = $"Clicked {count} times";
		}
		CounterBtn2.Text = CounterBtn.Text;
		Refresh();
	}

	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e){
		var sliderCorrectValue = (int)(e.NewValue / sliderIncrement) * sliderIncrement;
		CounterBtn2.Text = CounterBtn.Text = sliderCorrectValue.ToString();
		//Refresh();
	}

	private void OnStepperValueChanged(object sender, ValueChangedEventArgs e){
		CounterBtn2.Text = CounterBtn.Text = e.NewValue.ToString();
		//Refresh();
	}
}

