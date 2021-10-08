using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace TeleprompterConsole
{
    class TeleprompterConfig
    {

        private object LockHandle { get; } = new object();

        public int DelayInMilliseconds { get; private set; } = 200;

        public bool Done { get; set; } = false;

        //public void UpdateDelay(int increment)
        //{

        //    int newDelay = Max(DelayInMilliseconds + increment, 1);

        //    // Task 1 - Minimum and maximum reading speeds
        //    if (newDelay > 100 && newDelay < 400)
        //    {

        //        lock (LockHandle)
        //        {
        //            DelayInMilliseconds = newDelay;
        //        }

        //    }

        //}

        // Task 3 - Preset reading speeds accessed by pressing 1-5 
        public void UpdateDelay(int newDelay)
        {

            lock (LockHandle)
            {
                DelayInMilliseconds = newDelay;
            }

        }

    }
}
