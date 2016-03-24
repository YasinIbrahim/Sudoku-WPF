//
//  
// 
// 
// 
// 
//
// 
// 

using System;
using System.Timers;
using SudokuWPF.Properties;
using SudokuWPF.ViewModel.CustomEventArgs;

namespace SudokuWPF.ViewModel
{
    internal class GameTimer
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the GameTimer class.
        /// </summary>
        internal GameTimer()
        {
            ElapsedTime = _initialValue; // Initialize the elapsed time value
        }

        #endregion

        #region . Properties: Public Read-only .

        /// <summary>
        ///     Gets the elapsed time.
        /// </summary>
        internal string ElapsedTime { get; private set; }

        #endregion

        #region . Event Handlers .

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ComputeElapsedTime(); // Compute elapsed time
            RaiseEvent(ElapsedTime); // Raise an event with the elapsed time
        }

        #endregion

        #region . Variables, Constants, And other Declarations .

        #region . Constants .

        private readonly string _initialValue = "00:00:00";
        private readonly string _timeFormat = "hh\\:mm\\:ss";
        private readonly int _interval = 1000;

        #endregion

        #region . Variables .

        private DateTime _startTime;
        private Timer _timer;

        #endregion

        #region . Other Declarations .

        internal event EventHandler<GameTimerEventArgs> GameTimerEvent;

        #endregion

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Start the timer.
        /// </summary>
        internal void StartTimer()
        {
            _startTime = DateTime.Now; // Save the start time to now
            if (_timer == null) // Is the timer variable null?
                _timer = new Timer(_interval);
                    // Yes, then instantiate a new timer instance and initialize the interval to 1 second
            _timer.Elapsed += _timer_Elapsed; // Set the timer event handler
            _timer.AutoReset = true; // Set the autoreset property to true
            _timer.Enabled = true; // Start the timer
            RaiseEvent(_initialValue); // Raise the event
        }

        /// <summary>
        ///     Stop the timer.
        /// </summary>
        internal void StopTimer()
        {
            try
            {
                if ((_timer != null) && _timer.Enabled) // Is the timer running?
                {
                    _timer.Enabled = false; // Stop it
                    ComputeElapsedTime(); // Compute the elapsed time
                    RaiseEvent(""); // Raise an event
                }
            }
            catch (Exception)
            {
                // TODO: What to do here?
            }
            finally
            {
                _timer = null; // Set the timer variable to null
            }
        }

        /// <summary>
        ///     Pause the timer.
        /// </summary>
        internal void PauseTimer()
        {
            if ((_timer != null) && _timer.Enabled) // Is the timer running?
                _timer.Enabled = false; // Stop it
        }

        /// <summary>
        ///     Resume the timer.
        /// </summary>
        internal void ResumeTimer()
        {
            if (_timer != null) // Is the timer variable null?
            {
                LoadPreviousTime(); // No, then load the previously saved time
                _timer.Enabled = true; // Start the timer
            }
        }

        /// <summary>
        ///     Load the previously saved time.
        /// </summary>
        internal void LoadPreviousTime()
        {
            var diff = Settings.Default.ElapsedTime; // Load the previously saved time
            _startTime = DateTime.Now - diff; // Compute the difference
        }

        /// <summary>
        ///     Reset the timer.
        /// </summary>
        internal void ResetTimer()
        {
            if (_timer != null) // Is the timer variable null?
            {
                _timer.Enabled = false; // No, stop the timer
                _startTime = DateTime.Now; // Reset the start time to now
                _timer.Enabled = true; // Start the timer again
                RaiseEvent(_initialValue); // Raise an event
            }
        }

        #endregion

        #region . Methods: Private .

        private void ComputeElapsedTime()
        {
            try
            {
                var diff = DateTime.Now - _startTime; // Compute the difference between the start time and now.
                Settings.Default.ElapsedTime = diff; // Save it to the application configuration
                ElapsedTime = diff.ToString(_timeFormat); // Save the elapsed time
            }
            catch (Exception)
            {
                ElapsedTime = _initialValue; // Error, initialize the elapsed time
            }
        }

        protected virtual void RaiseEvent(string value)
        {
            var handler = GameTimerEvent;
            if (handler != null)
            {
                var e = new GameTimerEventArgs(value);
                handler(this, e);
            }
        }

        #endregion

        #endregion
    }
}