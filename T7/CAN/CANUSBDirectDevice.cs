﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using T7.CAN;
using Microsoft.Win32;
//using System.Diagnostics;

namespace T7.KWP
{

    /// <summary>
    /// CANUSBDirectDevice is an implementation of ICANDevice for the Lawicel CANUSB device
    /// (www.canusb.com) using the direct serial port approach
    /// 
    /// All incomming messages are published to registered ICANListeners.
    /// </summary>
    class CANUSBDirectDevice : ICANDevice, IDisposable
    {
        // ReceiveState m_rxstate;
        SerialPort m_port = new SerialPort();
        //static uint m_deviceHandle = 0;
        Thread m_readThread;
        Object m_synchObject = new Object();
        bool m_endThread = false;
        private bool m_DoLogging = false;
        private string m_startuppath = @"C:\Program files\Dilemma\T7Suite";
        private int m_baudrate = 115200 ; // test
        private string m_portnumber = "COM1";
        //private bool m_frameAvailable = false;

        private string m_forcedComport = string.Empty;

        public override string ForcedComport
        {
            get
            {
                return m_forcedComport;
            }
            set
            {
                m_forcedComport = value;
            }
        }

        public void setPortNumber(string portnumber)
        {
            Portnumber = portnumber;
        }

        public override float GetADCValue(uint channel)
        {
            return 0F;
        }

        // not supported by lawicel
        public override float GetThermoValue()
        {
            return 0F;
        }

        public override void Flush()
        {
            
        }

        public string Portnumber
        {
            get { return m_portnumber; }
            set
            {
                m_portnumber = value;
                if (m_port.IsOpen)
                {
                    m_port.Close();
                    m_port.PortName = m_portnumber;
                    m_port.Open();
                }
                else
                {
                    m_port.PortName = m_portnumber;
                }
            }
        }

        public int Baudrate
        {
            get { return m_baudrate; }
            set
            {
                m_baudrate = value;
                if (m_port.IsOpen)
                {
                    m_port.Close();
                    m_port.BaudRate = m_baudrate;
                    m_port.Open();
                }
                else
                {
                    m_port.BaudRate = m_baudrate;
                }
            }
        }


        public string Startuppath
        {
            get { return m_startuppath; }
            set { m_startuppath = value; }
        }
        public bool DoLogging
        {
            get { return m_DoLogging; }
            set { m_DoLogging = value; }
        }
        /// <summary>
        /// Constructor for CANUSBDirectDevice.
        /// </summary>
        public CANUSBDirectDevice()
        {
            m_port.ErrorReceived += new SerialErrorReceivedEventHandler(m_port_ErrorReceived);
            m_port.PinChanged += new SerialPinChangedEventHandler(m_port_PinChanged);
            
            m_port.DataReceived += new SerialDataReceivedEventHandler(m_port_DataReceived);
            m_port.WriteTimeout = 100;
            m_port.ReadTimeout = 100;
            m_port.NewLine = "\r";

            Portnumber = FindDevicePortName();

            //m_port.ReceivedBytesThreshold = 1;
            /*            m_readThread = new Thread(readMessages);
                        try
                        {
                            m_readThread.Priority = ThreadPriority.Normal; // realtime enough
                        }
                        catch (Exception E)
                        {
                            Console.WriteLine(E.Message);
                        }*/
        }

        void m_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //Console.WriteLine("data received");
            /*try
            {
                lock (m_synchObject)
                {
                    if (m_endThread)
                    {
                        m_endThread = false;
                        return;
                    }
                }

                // read the status?
                string line = string.Empty;
                //m_port.Write("\r");
                //m_port.Write("A\r"); // poll for all pending CAN messages
                // Console.WriteLine("Polled for frames");
                //Thread.Sleep(0);
                bool endofFrames = false;
                while (!endofFrames)
                {
                    if (m_port.IsOpen)
                    {
                        try
                        {
                            line = m_port.ReadLine();
                            if (line.Length > 0)
                            {
                                if (line[0] == '\x07' || line[0] == '\r' || line[0] == 'A')
                                {
                                    //Console.WriteLine("End of messages");
                                    endofFrames = true;
                                }
                                else
                                {
                                    //t00C8C6003E0000000000
                                    //Console.WriteLine("line: " + line + " len: " + line.Length.ToString());
                                    if (line.Length == 25)
                                    {
                                        r_canMsg = new LAWICEL.CANMsg();
                                        canMessage = new CANMessage();
                                        // three bytes identifier
                                        r_canMsg.id = (uint)Convert.ToInt32(line.Substring(1, 3), 16);
                                        r_canMsg.len = (byte)Convert.ToInt32(line.Substring(4, 1), 16);
                                        ulong data = 0;
                                        // add all the bytes
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(5, 2), 16);
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(7, 2), 16) << 1 * 8;
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(9, 2), 16) << 2 * 8;
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(11, 2), 16) << 3 * 8;
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(13, 2), 16) << 4 * 8;
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(15, 2), 16) << 5 * 8;
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(17, 2), 16) << 6 * 8;
                                        data |= (ulong)(byte)Convert.ToInt32(line.Substring(19, 2), 16) << 7 * 8;
                                        r_canMsg.data = data;
                                        canMessage.setID(r_canMsg.id);
                                        canMessage.setLength(r_canMsg.len);
                                        // canMessage.setTimeStamp(r_canMsg.timestamp);
                                        canMessage.setFlags(r_canMsg.flags);
                                        canMessage.setData(r_canMsg.data);
                                        if (m_DoLogging)
                                        {
                                            DumpCanMsg(r_canMsg, false, false);
                                        }
                                        lock (m_listeners)
                                        {
                                            foreach (ICANListener listener in m_listeners)
                                            {
                                                listener.handleMessage(canMessage);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception E)
                        {
                            Console.WriteLine("Failed to read frames from CANbus: " + E.Message);
                        }
                    }
                    //Thread.Sleep(0);

                }

            }
            catch (Exception E)
            {

            }
             */
            /*if (e.EventType == SerialData.Chars)
            {
                int bytesavailable = m_port.BytesToRead;
                for (int i = 0; i < bytesavailable; i++)
                {
                    byte rxbyte = (byte)m_port.ReadByte();
                    switch (m_rxstate)
                    {

                    }
                }
                //m_frameAvailable = true;
            }*/
        }

        void m_port_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            Console.WriteLine("pin changed");
        }

        void m_port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine("port error");
        }

        /// <summary>
        /// Destructor for CANUSBDirectDevice.
        /// </summary>
        ~CANUSBDirectDevice()
        {
            lock (m_synchObject)
            {
                m_endThread = true;
            }
            close();
        }

        public enum FlushFlags : byte
        {
            FLUSH_WAIT = 0,
            FLUSH_DONTWAIT = 1,
            FLUSH_EMPTY_INQUEUE = 2
        }

        public void Delete()
        {

        }

        public void Dispose()
        {

        }

        public int GetNumberOfAdapters()
        {
            return 1;
        }

        public void EnableLogging(string path2log)
        {
            m_DoLogging = true;
            m_startuppath = path2log;
        }

        public void DisableLogging()
        {
            m_DoLogging = false;
        }

        public void clearReceiveBuffer()
        {
            if (m_port.IsOpen)
            {
                m_port.DiscardInBuffer();
            }
        }

        public void clearTransmitBuffer()
        {
            if (m_port.IsOpen)
            {
                m_port.DiscardOutBuffer();
            }
        }


        private LAWICEL.CANMsg r_canMsg = new LAWICEL.CANMsg();
        private CANMessage canMessage = new CANMessage();
        
        private string[] SplitContentBy(char seperator, string content)
        {
            char[] sep = new char[1];
            sep.SetValue(seperator, 0);
            return content.Split(sep);
        }
        // int thrdcnt = 0;
        /// <summary>
        /// readMessages is the "run" method of this class. It reads all incomming messages
        /// and publishes them to registered ICANListeners.
        /// </summary>
        public void readMessages()
        {
            m_DoLogging = true;
            //int readResult = 0;

            while (true)
            {
                lock (m_synchObject)
                {
                    if (m_endThread)
                    {
                        m_endThread = false;
                        return;
                    }
                }
                if (m_port.IsOpen)
                {
                    // read the status?
                    //string line = string.Empty;
                    //m_port.Write("\r");
                    //m_port.Write("A\r"); // poll for all pending CAN messages
                   // Console.WriteLine("Polled for frames");
                    //Thread.Sleep(0);
                    bool endofFrames = false;
                    while (!endofFrames)
                    {
                        if (!m_port.IsOpen) endofFrames = true;
                        else
                        {
                            try
                            {
                                //line = m_port.ReadLine();
                                string allline = m_port.ReadExisting();
                                if (allline.Length > 0)
                                {
                                    //Console.WriteLine("allline: " + allline + " len: " + allline.Length.ToString());
                                    // split by \r
                                    string[] lines = SplitContentBy('\r', allline);
                                    foreach (string line in lines)
                                    {
                                        if (line.Length > 0)
                                        {
                                            //Console.WriteLine("line: " + line + " len: " + line.Length.ToString());
                                            if (line[0] == '\x07' || line[0] == '\r' || line[0] == 'A')
                                            {
                                                //Console.WriteLine("End of messages");
                                                endofFrames = true;
                                            }
                                            else
                                            {
                                                //t00C8C6003E0000000000

                                                if (line.Length == 21)
                                                {
                                                    r_canMsg = new LAWICEL.CANMsg();
                                                    canMessage = new CANMessage();
                                                    // three bytes identifier
                                                    r_canMsg.id = (uint)Convert.ToInt32(line.Substring(1, 3), 16);
                                                    r_canMsg.len = (byte)Convert.ToInt32(line.Substring(4, 1), 16);
                                                    ulong data = 0;
                                                    // add all the bytes
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(5, 2), 16);
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(7, 2), 16) << 1 * 8;
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(9, 2), 16) << 2 * 8;
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(11, 2), 16) << 3 * 8;
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(13, 2), 16) << 4 * 8;
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(15, 2), 16) << 5 * 8;
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(17, 2), 16) << 6 * 8;
                                                    data |= (ulong)(byte)Convert.ToInt32(line.Substring(19, 2), 16) << 7 * 8;
                                                    r_canMsg.data = data;
                                                    canMessage.setID(r_canMsg.id);
                                                    canMessage.setLength(r_canMsg.len);
                                                    // canMessage.setTimeStamp(r_canMsg.timestamp);
                                                    canMessage.setFlags(r_canMsg.flags);
                                                    canMessage.setData(r_canMsg.data);
                                                    /*if (m_DoLogging)
                                                    {
                                                        DumpCanMsg(r_canMsg, false, false);
                                                    }*/
                                                    if (r_canMsg.id == 0x238 || r_canMsg.id == 0x220 || r_canMsg.id == 0x240 || r_canMsg.id == 0x258)
                                                    {
                                                        Console.WriteLine("RX: " + r_canMsg.id.ToString("X4") + " " + r_canMsg.data.ToString("X16"));
                                                    }
                                                    lock (m_listeners)
                                                    {
                                                        foreach (ICANListener listener in m_listeners)
                                                        {
                                                            listener.handleMessage(canMessage);
                                                        }
                                                    }

                                                    /*if (this.MessageContainsInformationForRealtime(canMessage.getID()))
                                                    {
                                                        // TODO
                                                        //CastInformationEvent(canMessage);
                                                        
                                                    }*/
                                                }
                                                else
                                                {
                                                    if(line == "z") Console.WriteLine("Frame sent ok");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception E)
                            {
                                Console.WriteLine("Failed to read frames from CANbus: " + E.Message);
                            }
                        }
                        Thread.Sleep(1);

                    }
                }
                Thread.Sleep(1);
            }
        }

        private string GetCharString(int value)
        {
            char c = Convert.ToChar(value);
            string charstr = c.ToString();
            if (c == 0x0d) charstr = "<CR>";
            else if (c == 0x0a) charstr = "<LF>";
            else if (c == 0x00) charstr = "<NULL>";
            else if (c == 0x01) charstr = "<SOH>";
            else if (c == 0x02) charstr = "<STX>";
            else if (c == 0x03) charstr = "<ETX>";
            else if (c == 0x04) charstr = "<EOT>";
            else if (c == 0x05) charstr = "<ENQ>";
            else if (c == 0x06) charstr = "<ACK>";
            else if (c == 0x07) charstr = "<BEL>";
            else if (c == 0x08) charstr = "<BS>";
            else if (c == 0x09) charstr = "<TAB>";
            else if (c == 0x0B) charstr = "<VT>";
            else if (c == 0x0C) charstr = "<FF>";
            else if (c == 0x0E) charstr = "<SO>";
            else if (c == 0x0F) charstr = "<SI>";
            else if (c == 0x10) charstr = "<DLE>";
            else if (c == 0x11) charstr = "<DC1>";
            else if (c == 0x12) charstr = "<DC2>";
            else if (c == 0x13) charstr = "<DC3>";
            else if (c == 0x14) charstr = "<DC4>";
            else if (c == 0x15) charstr = "<NACK>";
            else if (c == 0x16) charstr = "<SYN>";
            else if (c == 0x17) charstr = "<ETB>";
            else if (c == 0x18) charstr = "<CAN>";
            else if (c == 0x19) charstr = "<EM>";
            else if (c == 0x1A) charstr = "<SUB>";
            else if (c == 0x1B) charstr = "<ESC>";
            else if (c == 0x1C) charstr = "<FS>";
            else if (c == 0x1D) charstr = "<GS>";
            else if (c == 0x1E) charstr = "<RS>";
            else if (c == 0x1F) charstr = "<US>";
            else if (c == 0x7F) charstr = "<DEL>";
            return charstr;
        }

        private void DumpCanMsg(LAWICEL.CANMsg r_canMsg, bool IsTransmit, bool isFromWaiting)
        {
            DateTime dt = DateTime.Now;
            try
            {
                string _extra = string.Empty;
                if(isFromWaiting) _extra = " WAIT";
                using (StreamWriter sw = new StreamWriter(Path.Combine(m_startuppath, dt.Year.ToString("D4") + dt.Month.ToString("D2") + dt.Day.ToString("D2") + "-CanTrace.log"), true))
                {
                    if (IsTransmit)
                    {
                        // get the byte transmitted
                        int transmitvalue = (int)(r_canMsg.data & 0x000000000000FF00);
                        transmitvalue /= 256;
                        
                        sw.WriteLine(dt.ToString("dd/MM/yyyy HH:mm:ss:fff") + _extra + " TX: id=" + r_canMsg.id.ToString("D2") + " len= " + r_canMsg.len.ToString("X8") + " data=" + r_canMsg.data.ToString("X16") + " " + r_canMsg.flags.ToString("X2") + " character = " + GetCharString(transmitvalue) + "\t ts: " + r_canMsg.timestamp.ToString("X16") + " flags: " + r_canMsg.flags.ToString("X2"));
                    }
                    else
                    {
                        // get the byte received
                        int receivevalue = (int)(r_canMsg.data & 0x0000000000FF0000);
                        receivevalue /= (256 * 256);
                        sw.WriteLine(dt.ToString("dd/MM/yyyy HH:mm:ss:fff") + _extra + " RX: id=" + r_canMsg.id.ToString("D2") + " len= " + r_canMsg.len.ToString("X8") + " data=" + r_canMsg.data.ToString("X16") + " " + r_canMsg.flags.ToString("X2") + " character = " + GetCharString(receivevalue) + "\t ts: " + r_canMsg.timestamp.ToString("X16") + " flags: " + r_canMsg.flags.ToString("X2"));
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine("Failed to write to logfile: " + E.Message);
            }
        }

        private string FindDevicePortName()
        {
            string retval = "COM1";
            RegistryKey TempKey = null;
            TempKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Enum");


            using (RegistryKey Settings = TempKey.OpenSubKey("FTDIBUS"))
            {
                if (Settings != null)
                {
                    string[] keys = Settings.GetSubKeyNames();
                    foreach (string key in keys)
                    {
                        Console.WriteLine(key);
                        RegistryKey deviceSettings = TempKey.OpenSubKey(@"FTDIBUS\" + key + @"\0000");
                        if (deviceSettings != null)
                        {
                            string[] vals = deviceSettings.GetValueNames();
                            foreach (string a in vals)
                            {
                                try
                                {
                                    //Console.WriteLine(a + " = " + deviceSettings.GetValue(a).ToString());
                                    if (a == "DeviceDesc" && deviceSettings.GetValue(a).ToString() == "Lawicel CANUSB")
                                    {
                                        RegistryKey lawicelSettings = TempKey.OpenSubKey(@"FTDIBUS\" + key + @"\0000\Device Parameters");
                                        if (lawicelSettings != null)
                                        {
                                            string[] lawicelvals = lawicelSettings.GetValueNames();
                                            foreach (string lawicelsetting in lawicelvals)
                                            {
                                                if (lawicelsetting == "PortName") retval = lawicelSettings.GetValue(lawicelsetting).ToString();
                                            }
                                        }
                                    }
                                    if (a == "DeviceDesc" && deviceSettings.GetValue(a).ToString() == "USB2-F-7x01 CAN-Plus Serial Port")
                                    {
                                        RegistryKey lawicelSettings = TempKey.OpenSubKey(@"FTDIBUS\" + key + @"\0000\Device Parameters");
                                        if (lawicelSettings != null)
                                        {
                                            string[] lawicelvals = lawicelSettings.GetValueNames();
                                            foreach (string lawicelsetting in lawicelvals)
                                            {
                                                if (lawicelsetting == "PortName") retval = lawicelSettings.GetValue(lawicelsetting).ToString();
                                            }
                                        }
                                    }
                                    //USB2-F-7x01 CAN-Plus Serial Port
                                }
                                catch (Exception E)
                                {
                                    Console.WriteLine(E.Message);
                                }
                            }
                        }
                    }
                }
            }
            return retval;
        }

        /// <summary>
        /// The open method tries to connect to both busses to see if one of them is connected and
        /// active. The first strategy is to listen for any CAN message. If this fails there is a
        /// check to see if the application is started after an interrupted flash session. This is
        /// done by sending a message to set address and length (only for P-bus).
        /// </summary>
        /// <returns>OpenResult.OK is returned on success. Otherwise OpenResult.OpenError is
        /// returned.</returns>
        override public OpenResult open()
        {
            Console.WriteLine("Opening port: " + m_portnumber + " in CANUSBDirect");
            if (m_port.IsOpen)
            {
                Console.WriteLine("Port was open, closing first");
                //m_port.Write("\r");
                m_port.Write("C\r");
                Thread.Sleep(100);
                m_port.Close();
            }

            m_port.BaudRate = m_baudrate;
            m_port.PortName = m_portnumber;
            m_port.Handshake = Handshake.None;
            Console.WriteLine("Opening comport");
            try
            {
                m_port.Open();
                if (m_port.IsOpen)
                {
                    try
                    {
                        Console.WriteLine("Setting CAN bitrate");
                        //m_port.Write("\r");
                        m_port.Write("m7FF\r");        
                        Thread.Sleep(100);
                        m_port.Write("M000\r");        
                        Thread.Sleep(100);

                        Thread.Sleep(1);
                        m_port.Write("S6\r");        // set CAN baudrate to 500kb/s
                        // now open the CAN channel
                        Thread.Sleep(100);
                        byte rxb = (byte)m_port.ReadByte();
                        if (rxb == 0x07) // error
                        {
                            Console.WriteLine("Failed to set CAN bitrate to 500 Kb/s");
                        }
                        else if(rxb == 0x0D) // OK
                        {
                            Console.WriteLine("CAN bitrate set to 500 Kb/s");
                        }
                        Console.WriteLine("Opening CAN channel");

                        //m_port.Write("\r");
                        Thread.Sleep(1);
                        m_port.Write("O\r");
                        Thread.Sleep(1000); // 2 seconds
                        if ((byte)m_port.ReadByte() == 0x07) // error
                        {
                            Console.WriteLine("Failed to open CAN channel");
                            return OpenResult.OpenError;
                        }
                        
                        //need to check is channel opened!!! 
                        Console.WriteLine("Creating new reader thread");
                        m_readThread = new Thread(readMessages);
                        try
                        {
                            m_readThread.Priority = ThreadPriority.Normal; // realtime enough
                        }
                        catch (Exception E)
                        {
                            Console.WriteLine(E.Message);
                        }
                        if (m_readThread.ThreadState == ThreadState.Unstarted)
                            m_readThread.Start();

                        m_port.Write("E\r"); // echo on / clear data, should be done just after opening the can channel
                        Thread.Sleep(100);
                        //m_port.Write("V\r"); // request version info
                        //Thread.Sleep(100);
                        /*if ((byte)m_port.ReadByte() == 0x07) // error
                        {
                            Console.WriteLine("Failed to open set echo on");
                            return OpenResult.OpenError;
                        }*/
                        //Console.WriteLine("Line after ECHO: " + m_port.ReadLine());
                        return OpenResult.OK;
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine("Failed to set canbaudrate: " + E.Message);

                    }
                    try
                    {
                        m_port.Close();
                    }
                    catch (Exception cE)
                    {
                        Console.WriteLine("Failed to close comport: " + cE.Message);
                    }
                    return OpenResult.OpenError;
                }
            }
            catch (Exception oE)
            {
                Console.WriteLine("Failed to open comport: " + oE.Message);
            }
            return OpenResult.OpenError;
        }

        /// <summary>
        /// The close method closes the CANUSBDirect device.
        /// </summary>
        /// <returns>CloseResult.OK on success, otherwise CloseResult.CloseError.</returns>
        override public CloseResult close()
        {

            Console.WriteLine("Close called in CANUSBDirectDevice");
            if (m_readThread != null)
            {
                if (m_readThread.ThreadState != ThreadState.Stopped && m_readThread.ThreadState != ThreadState.StopRequested)
                {
                    lock (m_synchObject)
                    {
                        m_endThread = true;
                    }
                    // m_readThread.Abort();
                }
            }
            Console.WriteLine("Thread ended");
            if (m_port.IsOpen)
            {
                //Console.WriteLine("Thread Closing port (1)");
                //m_port.Write("\r");
                m_port.Write("C\r");
                Thread.Sleep(100);
                //Console.WriteLine("Thread Closing port (2)");
                m_port.Close();
                //Console.WriteLine("Thread Closing port (3)");
                return CloseResult.OK;
            }
            return CloseResult.CloseError;
        }

        /// <summary>
        /// isOpen checks if the device is open.
        /// </summary>
        /// <returns>true if the device is open, otherwise false.</returns>
        override public bool isOpen()
        {
            return m_port.IsOpen;
        }


        /// <summary>
        /// sendMessage send a CANMessage.
        /// </summary>
        /// <param name="a_message">A CANMessage.</param>
        /// <returns>true on success, othewise false.</returns>
        override public bool sendMessage(CANMessage a_message)
        {

            LAWICEL.CANMsg msg = new LAWICEL.CANMsg();
            msg.id = a_message.getID();
            msg.len = a_message.getLength();
            msg.flags = a_message.getFlags();
            msg.data = a_message.getData();
            if (m_DoLogging)
            {
                DumpCanMsg(msg, true, false);
            }
            if (m_port.IsOpen)
            {
                //m_port.Write("\r");
                string txstring = "t";
                txstring += msg.id.ToString("X3");
                txstring += "8"; // always 8 bytes to transmit
                for (int t = 0; t < 8; t++)
                {
                    byte b = (byte)(((msg.data >> t * 8) & 0x0000000000000000FF));
                    txstring += b.ToString("X2");
                }
                txstring += "\r";
                m_port.Write(txstring);
                Thread.Sleep(5);
                Console.WriteLine("Send: " + txstring);
                return true;
            }
            return false;
        }

        public override uint waitForMessage(uint a_canID, uint timeout, out CANMessage r_canMsg)
        {
            r_canMsg = new CANMessage();
            return 0;
        }

    }



}