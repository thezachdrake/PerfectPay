namespace PerfectPay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

    private void txtBill_Completed(System.Object sender, System.EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
    }

	private void CalculateTotal()
	{
		var totalTip =
			(bill * tip) / 100;

		var tipByPerson = (totalTip / noPersons);

		lblTipByPerson.Text = $"{tipByPerson:C}";

		var subtotal = (bill / noPersons);
        lblSubtotal.Text = $"{subtotal:C}";

		var totalByPerson = (bill + totalTip) / noPersons;
		lblTotal.Text = $"{totalByPerson:C}";
    }

    private void sldTip_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
		CalculateTotal();

	}

    private void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if(sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%", ""));
			sldTip.Value = percentage;
		}	
    }

    private void btnMinus_Clicked(System.Object sender, System.EventArgs e)
    {
		if(noPersons > 1)
		{
			noPersons--;
		}lblNoPerson.Text = noPersons.ToString();
		CalculateTotal();

    }

    private void btnPlus_Clicked(System.Object sender, System.EventArgs e)
    {
		noPersons++;
        lblNoPerson.Text = noPersons.ToString();
        CalculateTotal();
    }
}


