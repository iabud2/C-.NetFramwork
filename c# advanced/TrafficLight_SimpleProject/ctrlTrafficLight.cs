using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TrafficLight_SimpleProject.ctrlTrafficLight.ColorChangedEventArgs;

namespace TrafficLight_SimpleProject
{


    public partial class ctrlTrafficLight : UserControl
    {
        public enum TrafficColors { Red, Green, Orange }
        

        public TrafficColors CurrentColor;
        private TrafficColors _PreviousColor;
        private int _SafetyBuffer = 2;
        private CancellationTokenSource _cts;
        private int _DynamicRedDuration;
        private int _Index = 0;
        private int _NumberOfTraffics = 1;

        private int _GreenDuration = 10;
        private int _OrangeDuration = 3;
        public int GreenTime
        {
            get => _GreenDuration;
            set => _GreenDuration = (value > 0) ? value : 10;
        }

        public int OrangeTime
        {
            get => _OrangeDuration;
            set => _OrangeDuration = (value > 0) ? value : 10;
        }



        public int TrafficIndex
        {
            get => _Index;
            set => _Index = value;
        }

        public int TotalTraffics
        {
            get => _NumberOfTraffics;
            set => _NumberOfTraffics = value;
        }

        public class ColorChangedEventArgs : EventArgs
        {
            public TrafficColors NewColor { get; }
            public TrafficColors OldColor { get; }
            public ColorChangedEventArgs(TrafficColors new_Color, TrafficColors oldColor)
            {
                NewColor = new_Color;
                OldColor = oldColor;
            }
        }

        public event EventHandler<ColorChangedEventArgs> ColorChanged;



        protected virtual void OnColorChanged(ColorChangedEventArgs e)
        {
            ColorChanged?.Invoke(this, e);
        }


        public ctrlTrafficLight()
        {
            InitializeComponent();
        }

        

        public async Task Start()
        {
            this._cts = new CancellationTokenSource();
            await PrepareTraffic();
        }

        private async Task PrepareTraffic ()
        {
            int UnitDuration = _GreenDuration + _OrangeDuration + _SafetyBuffer;
            _DynamicRedDuration = (UnitDuration * this._NumberOfTraffics) - (this._OrangeDuration + this._GreenDuration);


            int InitialDuration;
            if (this._Index == 0)
            {
                CurrentColor = TrafficColors.Green;
                ChangePicture();
                InitialDuration = _GreenDuration;
            }
            else
            {
                CurrentColor = TrafficColors.Red;
                ChangePicture();
                InitialDuration = (_Index) * UnitDuration;                
            }
            await TrafficCycle(_cts.Token, InitialDuration);
        }


        public void Stop()
        {
            _cts?.Cancel();
        }

        private async Task TrafficCycle(CancellationToken token, int InitialDuration)
        {

            int NextDuration = InitialDuration;
            while (!token.IsCancellationRequested)
            {

                try
                {
                    for (int i = NextDuration; i > 0; i--)
                    {
                        lbTimer.Text = i.ToString();
                        await Task.Delay(1000, token);
                    }

                    OnSwitchLight();
                    NextDuration = GetDurationForColor();
                }
                catch (OperationCanceledException)
                {
                    //Exception Here
                }
            }
        }
        
        private void OnSwitchLight()
        {
            switch (CurrentColor)
            {
                case TrafficColors.Red:
                    _PreviousColor = CurrentColor;
                    CurrentColor = TrafficColors.Green;
                    ChangePicture();
                    OnColorChanged(new ColorChangedEventArgs(CurrentColor, _PreviousColor));
                    break;
                case TrafficColors.Green:
                    _PreviousColor = CurrentColor;
                    CurrentColor = TrafficColors.Orange;
                    ChangePicture();
                    OnColorChanged(new ColorChangedEventArgs(CurrentColor, _PreviousColor));
                    break;
                case TrafficColors.Orange:
                    _PreviousColor = CurrentColor;
                    CurrentColor = TrafficColors.Red;
                    ChangePicture();
                    OnColorChanged(new ColorChangedEventArgs(CurrentColor, _PreviousColor));
                    break;
            }
        }

        private void ChangePicture()
        {
            switch(CurrentColor)
            {
                case TrafficColors.Red:
                    pbTrafficLight.Image = Properties.Resources.Red;
                    break;
                case TrafficColors.Orange:
                    pbTrafficLight.Image = Properties.Resources.Orange;
                    break;
                case TrafficColors.Green:
                    pbTrafficLight.Image = Properties.Resources.Green;
                    break;
            }
        }

        private int GetDurationForColor()
        {
            switch (CurrentColor)
                {
                case TrafficColors.Red:
                    pbTrafficLight.Image = Properties.Resources.Red;
                    return _DynamicRedDuration;
                case TrafficColors.Green:
                    pbTrafficLight.Image = Properties.Resources.Green;
                    return GreenTime;
                case TrafficColors.Orange:
                    pbTrafficLight.Image = Properties.Resources.Orange;
                    return OrangeTime;
                }
            return _DynamicRedDuration;
        }

    }
}
