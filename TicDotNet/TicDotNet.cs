
using System;
using System.Threading;
using LibUsbDotNet;
using LibUsbDotNet.Main;

// Copyright 2019 Jose Ignacio Garcia de Cortazar

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

// Class for the Pololu Tic stepper drivers.


class tic {


    #region CONSTANTS

    const int TIC_PRODUCT_T825 = 1;
    const int TIC_PRODUCT_T834 = 2;
    const int TIC_PRODUCT_T500 = 3;
    const int TIC_PRODUCT_N825 = 4;
    const int TIC_PRODUCT_T249 = 5;
    const int TIC_PRODUCT_36V4 = 6;
    const int USB_REQUEST_GET_DESCRIPTOR = 6;
    const int USB_DESCRIPTOR_TYPE_STRING = 3;
    const int TIC_VENDOR_ID = 8187;
    const int TIC_FIRMWARE_MODIFICATION_STRING_INDEX = 4;

    const int TIC_RESPONSE_DEENERGIZE = 0;
    const int TIC_RESPONSE_HALT_AND_HOLD = 1;
    const int TIC_RESPONSE_DECEL_TO_HOLD = 2;
    const int TIC_RESPONSE_GO_TO_POSITION = 3;
    const int TIC_PIN_NUM_SCL = 0;
    const int TIC_PIN_NUM_SDA = 1;
    const int TIC_PIN_NUM_TX = 2;
    const int TIC_PIN_NUM_RX = 3;
    const int TIC_PIN_NUM_RC = 4;
    const int TIC_PLANNING_MODE_OFF = 0;
    const int TIC_PLANNING_MODE_TARGET_POSITION = 1;
    const int TIC_PLANNING_MODE_TARGET_VELOCITY = 2;
    const int TIC_RESET_POWER_UP = 0;
    const int TIC_RESET_BROWNOUT = 1;
    const int TIC_RESET_RESET_LINE = 2;
    const int TIC_RESET_WATCHDOG = 4;
    const int TIC_RESET_SOFTWARE = 8;
    const int TIC_RESET_STACK_OVERFLOW = 16;
    const int TIC_RESET_STACK_UNDERFLOW = 32;
    const int TIC_PIN_STATE_HIGH_IMPEDANCE = 0;
    const int TIC_PIN_STATE_PULLED_UP = 1;
    const int TIC_PIN_STATE_OUTPUT_LOW = 2;
    const int TIC_PIN_STATE_OUTPUT_HIGH = 3;
    const int TIC_MIN_ALLOWED_BAUD_RATE = 200;
    const int TIC_MAX_ALLOWED_BAUD_RATE = 115385;
    const int TIC_DEFAULT_COMMAND_TIMEOUT = 1000;
    const int TIC_MAX_ALLOWED_COMMAND_TIMEOUT = 60000;
    const int TIC_MAX_ALLOWED_CURRENT = 3968;
    const int TIC_MAX_ALLOWED_CURRENT_T825 = 3968;
    const int TIC_MAX_ALLOWED_CURRENT_T834 = 3456;
    const int TIC_MAX_ALLOWED_CURRENT_T500 = 3093;
    const int TIC_MAX_ALLOWED_CURRENT_T249 = 4480;
    const int TIC_MAX_ALLOWED_CURRENT_CODE_T500 = 32;
    const int TIC_CURRENT_LIMIT_UNITS_MA = 32;
    const int TIC_CURRENT_LIMIT_UNITS_MA_T249 = 40;
    const int TIC_MIN_ALLOWED_ACCEL = 100;
    const long TIC_MAX_ALLOWED_ACCEL = 2147483647L;
    const int TIC_MAX_ALLOWED_SPEED = 500000000;
    const long TIC_MAX_ALLOWED_ENCODER_PRESCALER = 2147483647L;
    const long TIC_MAX_ALLOWED_ENCODER_POSTSCALER = 2147483647L;
    const int TIC_SPEED_UNITS_PER_HZ = 10000;
    const int TIC_ACCEL_UNITS_PER_HZ2 = 100;
    const int TIC_CONTROL_MODE_SERIAL = 0;
    const int TIC_CONTROL_MODE_STEP_DIR = 1;
    const int TIC_CONTROL_MODE_RC_POSITION = 2;
    const int TIC_CONTROL_MODE_RC_SPEED = 3;
    const int TIC_CONTROL_MODE_ANALOG_POSITION = 4;
    const int TIC_CONTROL_MODE_ANALOG_SPEED = 5;
    const int TIC_CONTROL_MODE_ENCODER_POSITION = 6;
    const int TIC_CONTROL_MODE_ENCODER_SPEED = 7;
    const int TIC_SCALING_DEGREE_LINEAR = 0;
    const int TIC_SCALING_DEGREE_QUADRATIC = 1;
    const int TIC_SCALING_DEGREE_CUBIC = 2;
    const int TIC_STEP_MODE_FULL = 0;
    const int TIC_STEP_MODE_HALF = 1;
    const int TIC_STEP_MODE_MICROSTEP1 = 0;
    const int TIC_STEP_MODE_MICROSTEP2 = 1;
    const int TIC_STEP_MODE_MICROSTEP4 = 2;
    const int TIC_STEP_MODE_MICROSTEP8 = 3;
    const int TIC_STEP_MODE_MICROSTEP16 = 4;
    const int TIC_STEP_MODE_MICROSTEP32 = 5;
    const int TIC_STEP_MODE_MICROSTEP2_100P = 6;
    const int TIC_DECAY_MODE_MIXED = 0;
    const int TIC_DECAY_MODE_SLOW = 1;
    const int TIC_DECAY_MODE_FAST = 2;
    const int TIC_DECAY_MODE_MODE3 = 3;
    const int TIC_DECAY_MODE_MODE4 = 4;
    const int TIC_DECAY_MODE_T825_MIXED = 0;
    const int TIC_DECAY_MODE_T825_SLOW = 1;
    const int TIC_DECAY_MODE_T825_FAST = 2;
    const int TIC_DECAY_MODE_T834_MIXED50 = 0;
    const int TIC_DECAY_MODE_T834_SLOW = 1;
    const int TIC_DECAY_MODE_T834_FAST = 2;
    const int TIC_DECAY_MODE_T834_MIXED25 = 3;
    const int TIC_DECAY_MODE_T834_MIXED75 = 4;
    const int TIC_DECAY_MODE_T500_AUTO = 0;
    const int TIC_DECAY_MODE_T249_MIXED = 0;
    const int TIC_AGC_MODE_OFF = 0;
    const int TIC_AGC_MODE_ON = 1;
    const int TIC_AGC_MODE_ACTIVE_OFF = 2;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_45 = 0;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_50 = 1;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_55 = 2;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_60 = 3;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_65 = 4;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_70 = 5;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_75 = 6;
    const int TIC_AGC_BOTTOM_CURRENT_LIMIT_80 = 7;
    const int TIC_AGC_CURRENT_BOOST_STEPS_5 = 0;
    const int TIC_AGC_CURRENT_BOOST_STEPS_7 = 1;
    const int TIC_AGC_CURRENT_BOOST_STEPS_9 = 2;
    const int TIC_AGC_CURRENT_BOOST_STEPS_11 = 3;
    const int TIC_AGC_FREQUENCY_LIMIT_OFF = 0;
    const int TIC_AGC_FREQUENCY_LIMIT_225 = 1;
    const int TIC_AGC_FREQUENCY_LIMIT_450 = 2;
    const int TIC_AGC_FREQUENCY_LIMIT_675 = 3;
    const int TIC_AGC_OPTION_MODE = 0;
    const int TIC_AGC_OPTION_BOTTOM_CURRENT_LIMIT = 1;
    const int TIC_AGC_OPTION_CURRENT_BOOST_STEPS = 2;
    const int TIC_AGC_OPTION_FREQUENCY_LIMIT = 3;
    const int TIC_MOTOR_DRIVER_ERROR_NONE = 0;
    const int TIC_MOTOR_DRIVER_ERROR_OVERCURRENT = 1;
    const int TIC_MOTOR_DRIVER_ERROR_OVERTEMPERATURE = 2;
    const int TIC_PIN_PULLUP = 7;
    const int TIC_PIN_ANALOG = 6;
    const int TIC_PIN_FUNC_POSN = 0;
    const int TIC_PIN_FUNC_MASK = 15;
    const int TIC_PIN_FUNC_DEFAULT = 0;
    const int TIC_PIN_FUNC_USER_IO = 1;
    const int TIC_PIN_FUNC_USER_INPUT = 2;
    const int TIC_PIN_FUNC_POT_POWER = 3;
    const int TIC_PIN_FUNC_SERIAL = 4;
    const int TIC_PIN_FUNC_RC = 5;
    const int TIC_PIN_FUNC_ENCODER = 6;
    const int TIC_PIN_FUNC_LIMIT_SWITCH_FORWARD = 8;
    const int TIC_PIN_FUNC_LIMIT_SWITCH_REVERSE = 9;
    const int TIC_PIN_FUNC_KILL_SWITCH = 7;
    const int TIC_CMD_SET_TARGET_POSITION = 224;
    const int TIC_CMD_SET_TARGET_VELOCITY = 227;
    const int TIC_CMD_HALT_AND_SET_POSITION = 236;
    const int TIC_CMD_HALT_AND_HOLD = 137;
    const int TIC_CMD_GO_HOME = 0x97;
    const int TIC_CMD_RESET_COMMAND_TIMEOUT = 140;
    const int TIC_CMD_DEENERGIZE = 134;
    const int TIC_CMD_ENERGIZE = 133;
    const int TIC_CMD_EXIT_SAFE_START = 131;
    const int TIC_CMD_ENTER_SAFE_START = 143;
    const int TIC_CMD_RESET = 176;
    const int TIC_CMD_CLEAR_DRIVER_ERROR = 138;
    const int TIC_CMD_SET_MAX_SPEED = 230;
    const int TIC_CMD_SET_STARTING_SPEED = 229;
    const int TIC_CMD_SET_MAX_ACCEL = 234;
    const int TIC_CMD_SET_MAX_DECEL = 233;
    const int TIC_CMD_SET_STEP_MODE = 148;
    const int TIC_CMD_SET_CURRENT_LIMIT = 145;
    const int TIC_CMD_SET_DECAY_MODE = 146;
    const int TIC_CMD_SET_AGC_OPTION = 0x98;
    const int TIC_CMD_GET_VARIABLE = 161;
    const int TIC_CMD_GET_VARIABLE_AND_CLEAR_ERRORS_OCCURRED = 162;
    const int TIC_CMD_GET_SETTING = 168;
    const int TIC_CMD_SET_SETTING = 19;
    const int TIC_CMD_REINITIALIZE = 16;
    const int TIC_CMD_START_BOOTLOADER = 255;
    const int TIC_CMD_GET_DEBUG_DATA = 32;
    const int TIC_VAR_OPERATION_STATE = 0;
    const int TIC_VAR_MISC_FLAGS1 = 1;
    const int TIC_VAR_ERROR_STATUS = 2;
    const int TIC_VAR_ERRORS_OCCURRED = 4;
    const int TIC_VAR_PLANNING_MODE = 9;
    const int TIC_VAR_TARGET_POSITION = 10;
    const int TIC_VAR_TARGET_VELOCITY = 14;
    const int TIC_VAR_STARTING_SPEED = 18;
    const int TIC_VAR_MAX_SPEED = 22;
    const int TIC_VAR_MAX_DECEL = 26;
    const int TIC_VAR_MAX_ACCEL = 30;
    const int TIC_VAR_CURRENT_POSITION = 34;
    const int TIC_VAR_CURRENT_VELOCITY = 38;
    const int TIC_VAR_ACTING_TARGET_POSITION = 42;
    const int TIC_VAR_TIME_SINCE_LAST_STEP = 46;
    const int TIC_VAR_DEVICE_RESET = 50;
    const int TIC_VAR_VIN_VOLTAGE = 51;
    const int TIC_VAR_UP_TIME = 53;
    const int TIC_VAR_ENCODER_POSITION = 57;
    const int TIC_VAR_RC_PULSE_WIDTH = 61;
    const int TIC_VAR_ANALOG_READING_SCL = 63;
    const int TIC_VAR_ANALOG_READING_SDA = 65;
    const int TIC_VAR_ANALOG_READING_TX = 67;
    const int TIC_VAR_ANALOG_READING_RX = 69;
    const int TIC_VAR_DIGITAL_READINGS = 71;
    const int TIC_VAR_PIN_STATES = 72;
    const int TIC_VAR_STEP_MODE = 73;
    const int TIC_VAR_CURRENT_LIMIT = 74;
    const int TIC_VAR_DECAY_MODE = 75;
    const int TIC_VAR_INPUT_STATE = 76;
    const int TIC_VAR_INPUT_AFTER_AVERAGING = 77;
    const int TIC_VAR_INPUT_AFTER_HYSTERESIS = 79;
    const int TIC_VAR_INPUT_AFTER_SCALING = 81;
    const int TIC_VAR_LAST_MOTOR_DRIVER_ERROR = 0x55;
    const int TIC_VAR_AGC_MODE = 0x56;
    const int TIC_VAR_AGC_BOTTOM_CURRENT_LIMIT = 0x57;
    const int TIC_VAR_AGC_CURRENT_BOOST_STEPS = 0x58;
    const int TIC_VAR_AGC_FREQUENCY_LIMIT = 0x59;
    const int TIC_VARIABLES_SIZE = 0x5A;
    const int TIC_SETTING_NOT_INITIALIZED = 0;
    const int TIC_SETTING_CONTROL_MODE = 1;
    const int TIC_SETTING_OPTIONS_BYTE1 = 2;
    const int TIC_SETTING_DISABLE_SAFE_START = 3;
    const int TIC_SETTING_IGNORE_ERR_LINE_HIGH = 4;
    const int TIC_SETTING_SERIAL_BAUD_RATE_GENERATOR = 5;
    const int TIC_SETTING_SERIAL_DEVICE_NUMBER_LOW = 7;
    const int TIC_SETTING_AUTO_CLEAR_DRIVER_ERROR = 8;
    const int TIC_SETTING_COMMAND_TIMEOUT = 9;
    const int TIC_SETTING_SERIAL_OPTIONS_BYTE = 11;
    const int TIC_SETTING_LOW_VIN_TIMEOUT = 12;
    const int TIC_SETTING_LOW_VIN_SHUTOFF_VOLTAGE = 14;
    const int TIC_SETTING_LOW_VIN_STARTUP_VOLTAGE = 16;
    const int TIC_SETTING_HIGH_VIN_SHUTOFF_VOLTAGE = 18;
    const int TIC_SETTING_VIN_CALIBRATION = 20;
    const int TIC_SETTING_RC_MAX_PULSE_PERIOD = 22;
    const int TIC_SETTING_RC_BAD_SIGNAL_TIMEOUT = 24;
    const int TIC_SETTING_RC_CONSECUTIVE_GOOD_PULSES = 26;
    const int TIC_SETTING_INVERT_MOTOR_DIRECTION = 27;
    const int TIC_SETTING_INPUT_ERROR_MIN = 28;
    const int TIC_SETTING_INPUT_ERROR_MAX = 30;
    const int TIC_SETTING_INPUT_SCALING_DEGREE = 32;
    const int TIC_SETTING_INPUT_INVERT = 33;
    const int TIC_SETTING_INPUT_MIN = 34;
    const int TIC_SETTING_INPUT_NEUTRAL_MIN = 36;
    const int TIC_SETTING_INPUT_NEUTRAL_MAX = 38;
    const int TIC_SETTING_INPUT_MAX = 40;
    const int TIC_SETTING_OUTPUT_MIN = 42;
    const int TIC_SETTING_INPUT_AVERAGING_ENABLED = 46;
    const int TIC_SETTING_INPUT_HYSTERESIS = 47;
    const int TIC_SETTING_CURRENT_LIMIT_DURING_ERROR = 49;
    const int TIC_SETTING_OUTPUT_MAX = 50;
    const int TIC_SETTING_SWITCH_POLARITY_MAP = 54;
    const int TIC_SETTING_ENCODER_POSTSCALER = 55;
    const int TIC_SETTING_SCL_CONFIG = 59;
    const int TIC_SETTING_SDA_CONFIG = 60;
    const int TIC_SETTING_TX_CONFIG = 61;
    const int TIC_SETTING_RX_CONFIG = 62;
    const int TIC_SETTING_RC_CONFIG = 63;
    const int TIC_SETTING_CURRENT_LIMIT = 64;
    const int TIC_SETTING_STEP_MODE = 65;
    const int TIC_SETTING_DECAY_MODE = 66;
    const int TIC_SETTING_STARTING_SPEED = 67;
    const int TIC_SETTING_MAX_SPEED = 71;
    const int TIC_SETTING_MAX_DECEL = 75;
    const int TIC_SETTING_MAX_ACCEL = 79;
    const int TIC_SETTING_SOFT_ERROR_RESPONSE = 83;
    const int TIC_SETTING_SOFT_ERROR_POSITION = 84;
    const int TIC_SETTING_ENCODER_PRESCALER = 88;
    const int TIC_SETTING_ENCODER_UNLIMITED = 92;
    const int TIC_SETTING_KILL_SWITCH_MAP = 93;
    const int TIC_SETTING_SERIAL_RESPONSE_DELAY = 94;
    const int TIC_SETTING_LIMIT_SWITCH_FORWARD_MAP = 0x5F;
    const int TIC_SETTING_LIMIT_SWITCH_REVERSE_MAP = 0x60;
    const int TIC_SETTING_HOMING_SPEED_TOWARDS = 0x61;
    const int TIC_SETTING_HOMING_SPEED_AWAY = 0x65;
    const int TIC_SETTING_SERIAL_DEVICE_NUMBER_HIGH = 0x69;
    const int TIC_SETTING_SERIAL_ALT_DEVICE_NUMBER = 0x6A;
    const int TIC_SETTING_AGC_MODE = 0x6C;
    const int TIC_SETTING_AGC_BOTTOM_CURRENT_LIMIT = 0x6D;
    const int TIC_SETTING_AGC_CURRENT_BOOST_STEPS = 0x6E;
    const int TIC_SETTING_AGC_FREQUENCY_LIMIT = 0x6F;
    const int TIC_SETTINGS_SIZE = 0x70;
    const int TIC_SERIAL_OPTIONS_BYTE_CRC_FOR_COMMANDS = 0;
    const int TIC_SERIAL_OPTIONS_BYTE_CRC_FOR_RESPONSES = 1;
    const int TIC_SERIAL_OPTIONS_BYTE_7BIT_RESPONSES = 2;
    const int TIC_SERIAL_OPTIONS_BYTE_14BIT_DEVICE_NUMBER = 3;
    const int TIC_OPTIONS_BYTE1_NEVER_SLEEP = 0;
    const int TIC_OPTIONS_BYTE1_AUTO_HOMING = 1;
    const int TIC_OPTIONS_BYTE1_AUTO_HOMING_FORWARD = 2;
    const int TIC_BAUD_RATE_GENERATOR_FACTOR = 12000000;
    const int TIC_MAX_USB_RESPONSE_SIZE = 128;
    const int TIC_INPUT_NULL = 65535;
    const int TIC_CONTROL_PIN_COUNT = 5;


    public enum PRODUCT_ID
    {
        T825 = 179,
        T834 = 181,
        T500 = 189,
        N825 = 0x00C3,
        T249 = 0x00C9,
        T36V4 = 0x00CB,
    }
    public enum ERRORS
    {
        INTENTIONALLY_DEENERGIZED = 0,
        MOTOR_DRIVER_ERROR = 1,
        LOW_VIN = 2,
        KILL_SWITCH = 3,
        REQUIRED_INPUT_INVALID = 4,
        SERIAL_ERROR = 5,
        COMMAND_TIMEOUT = 6,
        SAFE_START_VIOLATION = 7,
        ERR_LINE_HIGH = 8,
        SERIAL_FRAMING = 16,
        SERIAL_RX_OVERRUN = 17,
        SERIAL_FORMAT = 18,
        SERIAL_CRC = 19,
        ENCODER_SKIP = 20,
    }

    public enum OPERATION_STATE
    {
        RESET = 0,
        DEENERGIZED = 2,
        SOFT_ERROR = 4,
        WAITING_FOR_ERR_LINE = 6,
        STARTING_UP = 8,
        NORMAL = 10,
    }

    public enum INPUT_STATE
    {
        NOT_READY = 0,
        INVALID = 1,
        HALT = 2,
        POSITION = 3,
        VELOCITY = 4,
    }
    public enum MISC_FLAGS1
    {
        ENERGIZED = 0,
        POSITION_UNCERTAIN = 1,
        FORWARD_LIMIT_ACTIVE = 2,
        REVERSE_LIMIT_ACTIVE = 3,
        HOMING_ACTIVE = 4,
    }

    public enum GO_HOME
    {
        REVERSE = 0,
        FORWARD = 1,
    }


    #endregion

    public void init_defaults() {
        version = 0;
        serial = 0;
    }

    public bool open(PRODUCT_ID prod_id = PRODUCT_ID.T825, String serial = "")
    {
        init_defaults();
        try
        {
            UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(TIC_VENDOR_ID, (int)prod_id,serial);

            // Find and open the usb device.
            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);

            // If the device is open and ready
            if (MyUsbDevice == null || (serial!="" && MyUsbDevice.Info.SerialString != serial)) throw new Exception("Device Not Found.");

            // If this is a "whole" usb device (libusb-win32, linux libusb)
            // it will have an IUsbDevice interface. If not (WinUSB) the 
            // variable will be null indicating this is an interface of a 
            // device.
            IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
            if (!ReferenceEquals(wholeUsbDevice, null))
            {
                // This is a "whole" USB device. Before it can be used, 
                // the desired configuration and interface must be selected.

                // Select config #1
                wholeUsbDevice.SetConfiguration(1);
                // Claim interface #0.
                wholeUsbDevice.ClaimInterface(0);
            }
            product_id = prod_id;

            vars = new variables();

            status_vars = new status_variables();


            return true;

        }
        catch (Exception ex)
        {
            MyUsbDevice = null;
            throw new Exception("Device Not Found.",ex);
        }
    }

    public void close()
    {
        init_defaults();

        if (MyUsbDevice != null)
        {
            if (MyUsbDevice.IsOpen)
            {
                // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                // it exposes an IUsbDevice interface. If not (WinUSB) the 
                // 'wholeUsbDevice' variable will be null indicating this is 
                // an interface of a device; it does not require or support 
                // configuration and interface selection.
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // Release interface #0.
                    wholeUsbDevice.ReleaseInterface(0);
                }

                MyUsbDevice.Close();
            }
            MyUsbDevice = null;
            // Free usb resources
            UsbDevice.Exit();
        }
    }

    #region TRANSFERS
    bool transfer(int request_type=0x40,int request=0,int value = 0,int index = 0) {
            if (MyUsbDevice == null) {
                throw new Exception("Device not connected");
            }
            try {
            int transferred;
            UsbSetupPacket setup = new UsbSetupPacket((byte)request_type,(byte) request, value, index, 0);
            return MyUsbDevice.ControlTransfer(ref setup, null, 0, out transferred);
        }
        catch
            {
                return false;
            }
        }




    bool transfer(out byte[] data,int request_type = 0xC0, int request = 0, int value = 0, int index = 0, int data_or_length = 0)
    {
        if (MyUsbDevice == null)
        {
            throw new Exception("Device not connected");
        }
        try
        {
            int transferred;
            data = new byte[data_or_length];
            UsbSetupPacket setup = new UsbSetupPacket((byte)request_type, (byte)request, value, index, data_or_length);
            bool res= MyUsbDevice.ControlTransfer(ref setup, data, data_or_length, out transferred);
            return (res == true && transferred == data_or_length);
        }
        catch
        {
            data = null;
            return false;
        }
    }


    bool transfer_32bit(int request, int data) {
            var value = data & 65535;
            var index = data >> 16 & 65535;
            return transfer(request_type: 0x40 ,request: request, value: value, index: index);
        }

    public bool set_setting_byte(int address, int byte_value) {
            return transfer(request: TIC_CMD_SET_SETTING, value: address, index: byte_value);
        }

    #endregion

    public bool halt_and_hold() {
        return transfer(request: TIC_CMD_HALT_AND_HOLD);
    }

    public bool go_home(GO_HOME direction){
        return transfer(request: TIC_CMD_GO_HOME, value:(int)direction);
    }

    public bool reset_command_timeout() {
        return transfer(request: TIC_CMD_RESET_COMMAND_TIMEOUT);
    }
        
    public bool deenergize() {
        return transfer(request: TIC_CMD_DEENERGIZE);
    }
        
    public bool energize() {
        return transfer(request: TIC_CMD_ENERGIZE);
    }
        
    public bool exit_safe_start() {
        return transfer(request: TIC_CMD_EXIT_SAFE_START);
    }
        
    public bool enter_safe_start() {
        return transfer(request: TIC_CMD_ENTER_SAFE_START);
    }
        
    public bool reset() {
        return transfer(request: TIC_CMD_RESET);
    }
        
    public bool clear_driver_error() {
        return transfer(request: TIC_CMD_CLEAR_DRIVER_ERROR);
    }
        
    public bool reinitialize() {
        return transfer(request: TIC_CMD_REINITIALIZE);
    }
        
    public bool start_bootloader() {
        return transfer(request: TIC_CMD_START_BOOTLOADER);
    }
        
    public bool set_target_position(int position) {
        return transfer_32bit(request: TIC_CMD_SET_TARGET_POSITION, data:position);
    }
        
    public bool set_target_velocity(int velocity) {
        return transfer_32bit(request: TIC_CMD_SET_TARGET_VELOCITY, data: velocity);
    }
        
    public bool halt_and_set_position(int position) {
        return transfer_32bit(request: TIC_CMD_HALT_AND_SET_POSITION, data: position);
    }
        
    public bool set_max_speed(int max_speed) {
        return transfer_32bit(request: TIC_CMD_SET_MAX_SPEED, data: max_speed);
    }
        
    public bool set_starting_speed(int starting_speed) {
        return transfer_32bit(request: TIC_CMD_SET_STARTING_SPEED, data: starting_speed);
    }
        
    public bool set_max_accel(int max_accel) {
        return transfer_32bit(request: TIC_CMD_SET_MAX_ACCEL, data: max_accel);
    }
        
    public bool set_max_decel(int max_decel) {
        return transfer_32bit(request: TIC_CMD_SET_MAX_DECEL, data: max_decel);
    }
        
    public bool set_step_mode(int step_mode) {
        return transfer(request: TIC_CMD_SET_STEP_MODE, value: step_mode);
    }
        
    public bool set_decay_mode(int decay_mode) {
        return transfer(request: TIC_CMD_SET_DECAY_MODE, value: decay_mode);
    }
        
    public bool in_position()
    {
        return (status_vars.operation_state == OPERATION_STATE.NORMAL && vars.current_position == vars.target_position);
    }

    public bool in_home()
    {
        return (status_vars.operation_state == OPERATION_STATE.NORMAL && vars.current_position == 0);
    }

    public void wait_for_device_ready() {
        get_variables();
        while (status_vars.operation_state != OPERATION_STATE. NORMAL) {
            get_variables();
            Thread.Sleep(poll_period);
            reset_command_timeout();
        }
    }

    public void wait_for_move_complete() {
        get_variables();
        while (status_vars.operation_state == OPERATION_STATE.NORMAL && vars.current_position != vars.target_position) {
            if (vars.input_state == INPUT_STATE. HALT  || vars.input_state == INPUT_STATE. INVALID)
                break;
            get_variables();
            Thread.Sleep(poll_period);
        }
    }


    public void wait_for_kill_switch()
    {
        get_variables();
        while (status_vars.operation_state == OPERATION_STATE.NORMAL )
        {
            if (status_vars.operation_state==OPERATION_STATE.SOFT_ERROR && (status_vars.error_status >> (int)ERRORS.KILL_SWITCH &1)==1)
            {
                break;
            }
            get_variables();
            Thread.Sleep(poll_period);
        }
    }


   public bool get_status_variables(bool clear_errors = false) {
        int cmd;
        if (clear_errors) {
            cmd = TIC_CMD_GET_VARIABLE_AND_CLEAR_ERRORS_OCCURRED;
        } else {
            cmd = TIC_CMD_GET_VARIABLE;
        }
        byte[] buffer;
        bool res = transfer(out buffer,request_type: 0xC0, request: cmd, data_or_length: TIC_VARIABLES_SIZE);
        parse_status_variables(buffer);
        return res;
    }
    public string get_error_status()
    {
        string serr = "";
        for (int i = 0; i < 32; i++)
        {
            if (((1 << i) & status_vars.error_status) != 0)
            {
                ERRORS err = (ERRORS)i;
                serr = serr + err.ToString() + " ";
            }
        }
        return serr;
    }

        
    bool parse_status_variables(byte [] buffer)
    {
        status_vars.operation_state = (OPERATION_STATE)buffer[TIC_VAR_OPERATION_STATE];
        status_vars.energized =( buffer[TIC_VAR_MISC_FLAGS1] >> (int)MISC_FLAGS1.ENERGIZED & 1) ==1;
        status_vars.position_uncertain=(buffer[TIC_VAR_MISC_FLAGS1] >> (int) MISC_FLAGS1.POSITION_UNCERTAIN & 1)==1 ;
        status_vars.error_status = BitConverter.ToUInt16(buffer, TIC_VAR_ERROR_STATUS);
        status_vars.string_error_status = get_error_status();
        status_vars.error_occurred = BitConverter.ToUInt32(buffer, TIC_VAR_ERRORS_OCCURRED);
        return false;
    }
        
   public bool get_variables (bool clear_errors = false) {
        byte cmd;
        if (clear_errors) {
            cmd = (byte)TIC_CMD_GET_VARIABLE_AND_CLEAR_ERRORS_OCCURRED;
        } else {
            cmd = (byte)TIC_CMD_GET_VARIABLE;
        }
        byte[] buffer;
        bool res = transfer(out buffer, request_type: 0xC0, request: cmd, data_or_length: TIC_VARIABLES_SIZE);
        parse_status_variables(buffer);

        vars.planning_mode=buffer[TIC_VAR_PLANNING_MODE];
        vars.target_position = BitConverter.ToInt32(buffer, TIC_VAR_TARGET_POSITION);
        vars.target_velocity = BitConverter.ToInt32(buffer, TIC_VAR_TARGET_VELOCITY);
        vars.starting_speed = BitConverter.ToUInt32(buffer, TIC_VAR_STARTING_SPEED);
        vars.max_speed = BitConverter.ToUInt32(buffer, TIC_VAR_MAX_SPEED);
        vars.max_decel = BitConverter.ToUInt32(buffer, TIC_VAR_MAX_DECEL);
        vars.max_accel = BitConverter.ToUInt32(buffer, TIC_VAR_MAX_ACCEL);
        vars.current_position = BitConverter.ToInt32(buffer, TIC_VAR_CURRENT_POSITION);
        vars.current_velocity = BitConverter.ToInt32(buffer, TIC_VAR_CURRENT_VELOCITY);
        vars.acting_target_position = BitConverter.ToInt32(buffer, TIC_VAR_ACTING_TARGET_POSITION);
        vars.time_since_last_step = BitConverter.ToUInt32(buffer, TIC_VAR_TIME_SINCE_LAST_STEP);
        vars.device_reset=buffer[TIC_VAR_DEVICE_RESET];
        vars.vin_voltage = BitConverter.ToUInt16(buffer, TIC_VAR_VIN_VOLTAGE);
        vars.up_time = BitConverter.ToUInt32(buffer, TIC_VAR_UP_TIME);
        vars.encoder_position = BitConverter.ToInt32(buffer, TIC_VAR_ENCODER_POSITION);
        vars.rc_pulse_width = BitConverter.ToUInt16(buffer, TIC_VAR_RC_PULSE_WIDTH);
        vars.analog_readinng_scl = BitConverter.ToUInt16(buffer, TIC_VAR_ANALOG_READING_SCL);
        vars.analog_readinng_sda = BitConverter.ToUInt16(buffer, TIC_VAR_ANALOG_READING_SDA);
        vars.analog_readinng_tx = BitConverter.ToUInt16(buffer, TIC_VAR_ANALOG_READING_TX);
        vars.analog_readinng_rx = BitConverter.ToUInt16(buffer, TIC_VAR_ANALOG_READING_RX);
        vars.digital_readings = buffer[ TIC_VAR_DIGITAL_READINGS];
        vars.pin_states = buffer[TIC_VAR_PIN_STATES];
        vars.step_mode=buffer[TIC_VAR_STEP_MODE];
        vars.current_limit=buffer[TIC_VAR_CURRENT_LIMIT];
        vars.decay_mode=buffer[TIC_VAR_DECAY_MODE];
        vars.input_state=(INPUT_STATE)buffer[TIC_VAR_INPUT_STATE];
        vars.input_after_averaging = BitConverter.ToUInt16(buffer, TIC_VAR_INPUT_AFTER_AVERAGING);
        vars.input_after_hysteresis = BitConverter.ToUInt16(buffer, TIC_VAR_INPUT_AFTER_HYSTERESIS);
        vars.input_after_scaling = BitConverter.ToInt32(buffer, TIC_VAR_INPUT_AFTER_SCALING);
        return res;
    }

    #region NOT_IMPLEMENTED

    /*  
        bool set_current_limit_code(int value) {
            directly send value - check code for correct values
            return transfer(request: TIC_CMD_SET_CURRENT_LIMIT, value: value);
        }
        
        bool get_firmware_mod_array() {
            var buffer = transfer(request_type: usb.util.CTRL_IN | usb.util.CTRL_TYPE_STANDARD | usb.util.CTRL_RECIPIENT_DEVICE, request: USB_REQUEST_GET_DESCRIPTOR, value: USB_DESCRIPTOR_TYPE_STRING << 8 | TIC_FIRMWARE_MODIFICATION_STRING_INDEX, data_or_length: 256, msg: "getting modified firmware version.");
            //Ignore the modification string if it is just a dash.
            if (buffer.Count == 4 && buffer[2] == 45) {
                buffer = null;
            }
            return buffer;
        }
   
        void current_defaults_for_product() {
            if (product_id == TIC_PRODUCT_ID_T500) {
                product = TIC_PRODUCT_T500;
                current_max = TIC_MAX_ALLOWED_CURRENT_T500;
                current_table = TIC03A_RECOMMENDED_CODES;
                current_table_count = TIC03A_CURRENT_TABLE.Count;
            } else if (product_id == TIC_PRODUCT_ID_T834) {
                // Some of the codes at the end of the table are too high; they violate
                // TIC_MAX_ALLOWED_CURRENT_T834.  So just return a count lower than the
                // actual number of items in the table.
                product = TIC_PRODUCT_T834;
                current_max = TIC_MAX_ALLOWED_CURRENT_T834;
                current_table = TIC01A_RECOMMENDED_CODES;
                current_table_count = 60;
            } else if (product_id == TIC_PRODUCT_ID_T825) {
                product = TIC_PRODUCT_T825;
                current_max = TIC_MAX_ALLOWED_CURRENT_T825;
                current_table = TIC01A_RECOMMENDED_CODES;
                current_table_count = TIC01A_RECOMMENDED_CODES.Count;
            } else {
                product = 0;
                current_max = 0;
                current_table = null;
                current_table_count = null;
            }
        }

        int current_limit_code_to_ma(int code) {
            if (product == TIC_PRODUCT_T500) {
                if (code > TIC_MAX_ALLOWED_CURRENT_CODE_T500) {
                    code = TIC_MAX_ALLOWED_CURRENT_CODE_T500;
                }
                return TIC03A_CURRENT_TABLE[code];
            } else {
                var max = current_max / TIC_CURRENT_LIMIT_UNITS_MA;
                if (code > max) {
                    code = max;
                } else if (code > 64) {
                    code = code * 4;
                } else if (code > 32) {
                    code = code * 2;
                }
                return code * TIC_CURRENT_LIMIT_UNITS_MA;
            }
        }

        int current_limit_ma_to_code(object ma) {
            //   // Assumption: The table is an ascending order, so we want to return the last
            //   // one that is less than or equal to the desired current.
            //   // Assumption: 0 is a valid code and a good default to use.
            var code = 0;
            foreach (var i in Enumerable.Range(0, current_table_count - 1 - 0)) {
                //recomended_current_code = self.current_table_recomended_count
                var table_ma = current_limit_code_to_ma(i);
                if (table_ma <= ma) {
                    code = i;
                } else {
                    break;
                }
            }
            return code;
        }

        void code_test() {
            product_id = TIC_PRODUCT_ID_T500;
            current_defaults_for_product();
            var code = current_limit_ma_to_code(1000);
        }

        double compute_ilim(int dac_level) {
            double r_dacout;
            var v_iset = 0.9;
            var v_dac_top = 4.096;
            var r_top = 107000.0;
            var r_bot = 33000.0;
            var r_dac_top = (32 - dac_level) * 5000;
            var r_dac_bot = dac_level * 5000;
            var v_dacout = v_dac_top * r_dac_bot / (r_dac_bot + r_dac_top);
            if (dac_level == 0) {
                r_dacout = 0;
            } else {
                r_dacout = 1 / (1 / r_dac_top + 1 / r_dac_bot);
            }
            var iset_current_sourced = (v_iset - v_dacout) / (r_top + r_dacout) + v_iset / r_bot;
            if (iset_current_sourced < 0) {
                iset_current_sourced = 0;
            }
            iset_current_sourced = iset_current_sourced * 86666;
            return iset_current_sourced;
        }

        void log_ilim() {
            //puts "  0,"
            //31.downto(0) do |dac_level|
            //    puts "  %d," % [(compute_ilim(dac_level) * 1000).round]
            foreach (var dac_level in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - 31) / -1))).Select(x => 31 + x * -1)) {
                compute_ilim(dac_level);
            }
        }

        */
    #endregion

    public class variables
    {
        public byte planning_mode{ get; set; }
        public int target_position{ get; set; }
        public int target_velocity{ get; set; }
        public uint starting_speed{ get; set; }
        public uint max_speed{ get; set; }
        public uint max_decel{ get; set; }
        public uint max_accel{ get; set; }
        public int current_position{ get; set; }
        public int current_velocity{ get; set; }
        public int acting_target_position{ get; set; }
        public uint time_since_last_step{ get; set; }
        public byte device_reset{ get; set; }
        public int vin_voltage{ get; set; }
        public uint up_time{ get; set; }
        public int encoder_position{ get; set; }
        public uint rc_pulse_width{ get; set; }
        public uint analog_readinng_scl{ get; set; }
        public uint analog_readinng_sda{ get; set; }
        public uint analog_readinng_tx{ get; set; }
        public uint analog_readinng_rx{ get; set; }
        public byte digital_readings{ get; set; }
        public byte pin_states{ get; set; }
        public int step_mode{ get; set; }
        public int current_limit{ get; set; }
        public int decay_mode{ get; set; }
        public INPUT_STATE input_state{ get; set; }
        public uint input_after_averaging{ get; set; }
        public uint input_after_hysteresis{ get; set; }
        public int input_after_scaling{ get; set; }
    }


    public class status_variables
    {

        public OPERATION_STATE operation_state { get; set; }
        public uint error_status { get; set; }
        public string string_error_status { get; set; }
        public bool position_uncertain { get; set; }
        public bool energized { get; set; }
        public uint error_occurred { get; set; }
    }

    UsbDevice MyUsbDevice;
    int version { get; set; }
    int serial { get; set; }

    int  poll_period = 10;
    public variables vars { get; set; }
    public status_variables status_vars { get; set; }
    PRODUCT_ID product_id;


}
