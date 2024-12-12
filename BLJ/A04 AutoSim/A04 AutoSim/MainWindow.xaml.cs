using System;
using System.Windows;
using System.Windows.Threading;

namespace CarSimulator
{
    public partial class MainWindow : Window
    {
        private Car currentCar;
        private DispatcherTimer speedTimer;
        private bool isAccelerating;
        private bool isBraking;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCar();
            SetupTimer();
        }

        private void InitializeCar()
        {
            CarSelector.SelectedIndex = 0;
            UpdateCar();
            CarSelector.SelectionChanged += (s, e) => UpdateCar();
        }

        private void UpdateCar()
        {
            string carModel = CarSelector.SelectedItem?.ToString();
            switch (carModel)
            {
                case "Porsche":
                    currentCar = new Car("Porsche", 250);
                    break;
                case "Ferrari":
                    currentCar = new Car("Ferrari", 370);
                    break;
                case "Opel":
                    currentCar = new Car("Opel", 90);
                    break;
                default:
                    currentCar = new Car("Porsche", 250);
                    break;
            }
            UpdateDisplay();
        }

        private void SetupTimer()
        {
            speedTimer = new DispatcherTimer();
            speedTimer.Interval = TimeSpan.FromMilliseconds(100);
            speedTimer.Tick += SpeedTimer_Tick;
            speedTimer.Start();
        }

        private void SpeedTimer_Tick(object sender, EventArgs e)
        {
            if (isAccelerating)
            {
                currentCar.GiveGas();
            }
            else if (isBraking)
            {
                currentCar.Brake();
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            SpeedDisplay.Text = ((int)currentCar.CurrentSpeed).ToString();
            GearDisplay.Text = currentCar.CurrentGear.ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!currentCar.IsEngineRunning)
                currentCar.StartEngine();
            else
                currentCar.StopEngine();
        }

        private void HornButton_Click(object sender, RoutedEventArgs e)
        {
            currentCar.Horn();
        }

        private void FuelButton_Click(object sender, RoutedEventArgs e)
        {
            currentCar.Refuel();
        }

        private void GasButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isAccelerating = true;
        }

        private void GasButton_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isAccelerating = false;
        }

        private void BrakeButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isBraking = true;
        }

        private void BrakeButton_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isBraking = false;
        }
    }

    public class Car
    {
        public string Brand { get; private set; }
        public int HorsePower { get; private set; }
        public double CurrentSpeed { get; private set; }
        public int CurrentGear { get; private set; }
        public bool IsEngineRunning { get; private set; }
        public double FuelLevel { get; private set; }

        private const double MaxFuel = 100.0;
        private const double AccelerationFactor = 0.5;
        private const double BrakingFactor = 1.0;
        private const double FuelConsumptionFactor = 0.01;

        public Car(string brand, int horsePower)
        {
            Brand = brand;
            HorsePower = horsePower;
            CurrentSpeed = 0;
            CurrentGear = 1;
            IsEngineRunning = false;
            FuelLevel = MaxFuel;
        }

        public void StartEngine()
        {
            if (FuelLevel > 0)
            {
                IsEngineRunning = true;
            }
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
            CurrentSpeed = 0;
            CurrentGear = 1;
        }

        public void GiveGas()
        {
            if (!IsEngineRunning || FuelLevel <= 0)
                return;

            double acceleration = (HorsePower / 100.0) * AccelerationFactor;
            CurrentSpeed += acceleration;
            ConsumeFuel();
            UpdateGear();
        }

        public void Brake()
        {
            CurrentSpeed = Math.Max(0, CurrentSpeed - BrakingFactor);
            UpdateGear();
        }

        public void Horn()
        {
            // In a real application, this would play a sound
            MessageBox.Show("Huup Huup!");
        }

        public void Refuel()
        {
            if (!IsEngineRunning)
            {
                FuelLevel = MaxFuel;
            }
        }

        private void ConsumeFuel()
        {
            double consumption = (CurrentSpeed / 100.0) * FuelConsumptionFactor * (HorsePower / 100.0);
            FuelLevel = Math.Max(0, FuelLevel - consumption);

            if (FuelLevel <= 0)
            {
                StopEngine();
            }
        }

        private void UpdateGear()
        {
            if (CurrentSpeed <= 10) CurrentGear = 1;
            else if (CurrentSpeed <= 20) CurrentGear = 2;
            else if (CurrentSpeed <= 40) CurrentGear = 3;
            else if (CurrentSpeed <= 70) CurrentGear = 4;
            else if (CurrentSpeed <= 100) CurrentGear = 5;
            else CurrentGear = 6;
        }
    }
}