using UIKit;

namespace CXConfig.Method;

public static class MessageBox{
    public static void Show(string title, string content, string accept = "Yes", string cancel = "No"){
			Task.Run(async () =>
			{
				await Task.Delay(2000);
				App.AlertSvc.ShowConfirmation(
					title, 
                    $"Message: {content}", 
					(
						result => {
							//App.AlertSvc.ShowAlert("Result", $"{result}");
						}
					),
					accept,
					cancel
				);
			});
    }
}