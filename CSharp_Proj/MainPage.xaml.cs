using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CSharp_Proj
{

    public partial class MainPage : ContentPage
    {
        public int intSaldo;
        public int intBetAmount;

        //Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        public int ConvertSaldoToInt()
        {
            intSaldo = Convert.ToInt32(displaySaldo.Text);
            return intSaldo;
        }

        public int ConvertBetAmountToInt()
        {
            intBetAmount = Convert.ToInt32(BetAmount.Text);
            return intBetAmount;
        }
        //Spin function
        async public Task Spin()
        {
            Slot Slot = new Slot();
            string[][] SlotImages = Slot.GetSlotImages();

            value0.Source = null;
            value1.Source = null;
            value2.Source = null;
            value3.Source = null;
            value4.Source = null;

            value5.Source = null;
            value6.Source = null;
            value7.Source = null;
            value8.Source = null;
            value9.Source = null;

            value10.Source = null;
            value11.Source = null;
            value12.Source = null;
            value13.Source = null;
            value14.Source = null;

            value15.Source = null;
            value16.Source = null;
            value17.Source = null;
            value18.Source = null;
            value19.Source = null;

            value20.Source = null;
            value21.Source = null;
            value22.Source = null;
            value23.Source = null;
            value24.Source = null;

            await Task.Delay(500);

            value0.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[0][0]}");
            value1.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[0][1]}");
            value2.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[0][2]}");
            value3.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[0][3]}");
            value4.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[0][4]}");

            await Task.Delay(500);

            value5.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[1][0]}");
            value6.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[1][1]}");
            value7.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[1][2]}");
            value8.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[1][3]}");
            value9.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[1][4]}");

            await Task.Delay(500);

            value10.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[2][0]}");
            value11.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[2][1]}");
            value12.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[2][2]}");
            value13.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[2][3]}");
            value14.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[2][4]}");

            await Task.Delay(500);

            value15.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[3][0]}");
            value16.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[3][1]}");
            value17.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[3][2]}");
            value18.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[3][3]}");
            value19.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[3][4]}");

            await Task.Delay(500);

            value20.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[4][0]}");
            value21.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[4][1]}");
            value22.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[4][2]}");
            value23.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[4][3]}");
            value24.Source = ImageSource.FromResource($"CSharp_Proj.images.{SlotImages[4][4]}");
            

            //Makes math calculation on spin results
            Slot.CalculateWin(intBetAmount);
            //Displays as text
            lastRound.Text = Slot.CalculateWin(intBetAmount).ToString();

            //Adds win to saldo
            intSaldo += Slot.CalculateWin(intBetAmount);

            if(autoSpin.IsEnabled == true)
            {
                await Task.Delay(1000);
            }

            return;
        }

        async void Bet_Clicked(System.Object sender, System.EventArgs e)
        {
            //If Saldo is bigger than bet and saldo is 1 or bigger
            if (ConvertSaldoToInt() >= ConvertBetAmountToInt() && ConvertSaldoToInt() >= 1)
            {
                //Make the spin once
                do
                {
                    //Deactivate Bet button to not run multiple times and mess up delay
                    bet.IsEnabled = false;
                    await Spin();

                    intSaldo -= intBetAmount;
                    displaySaldo.Text = Convert.ToString(intSaldo);

                    //Activate Bet button
                    bet.IsEnabled = true;
                }
                //While switch is toggled on and saldo is bigger or equal to amount, keep spinning
                while (autoSpin.IsToggled == true && intSaldo >= intBetAmount);

                if(intSaldo < intBetAmount)
                {
                    Console.WriteLine("Saldo insufficient");
                    autoSpin.IsToggled = false;
                }
            }
            else
            {
                Console.WriteLine("Saldo insufficient");
            }
        }


        //On click, add 1000 to saldo
        void Add_Clicked(System.Object sender, System.EventArgs e)
        {
            int saldoInt = Convert.ToInt32(displaySaldo.Text);
            saldoInt += 1000;
            displaySaldo.Text = Convert.ToString(saldoInt);
        }

        //Makes so that slider converts to whole number
        void slider_DragCompleted(System.Object sender, System.EventArgs e)
        {
            slider.Value = Math.Ceiling(slider.Value);
            Convert.ToInt32(slider.Value);
            if(slider.Value == 0)
            {
                slider.Value = 1;
            }
        }

    }
}
