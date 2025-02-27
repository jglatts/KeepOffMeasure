# Theory of Operation: KeepOffMeasure System

## Overview

The KeepOffMeasure system is a vision-based measurement tool designed to analyze and determine keep-off distances in an industrial setting. Utilizing OpenCV for image processing and a connected camera for real-time video capture, the system allows for precise calibration and measurement of critical distances on workpieces.

## System Components

**Camera**: Captures live feed of the workpiece under inspection.

**User Interface (UI)**: Provides interaction through buttons and input fields for calibration, live feed control, and measurement initiation.

**Image Processing Module**: Processes camera frames to detect contours and measure distances using OpenCV.

**Calibration Module**: Enables pixel-per-inch calibration to ensure accurate distance measurements.

**Measurement Module**: Computes the keep-off distance by analyzing detected contours of the wire and core.

## Operation Workflow

1. Initialization

Upon startup, the system initializes the camera and UI elements. The application attempts to open a video stream from the specified camera index. If the camera is successfully detected, the user is notified; otherwise, an error message is displayed.

2. Live Feed Activation

Pressing the "Start Live Feed" button initiates real-time image capture. The captured frames are continuously displayed in the UI, allowing users to monitor the object under measurement.

3. Calibration Process

To ensure accurate measurements, the system provides a pixel-per-inch calibration function. The user selects a reference distance on the image, and the system computes the corresponding pixel density. This value is stored and used for all subsequent measurements.

4. Edge Detection & Contour Analysis

The system utilizes OpenCV’s Canny edge detection algorithm to process grayscale images and extract relevant contours. The detected contours are analyzed to identify critical features:

Wire Edge Detection: Determines the termination point of a wire by evaluating hierarchical contour data.

Core Edge Detection: Identifies the core boundary by analyzing the lowest detected y-coordinate.

5. Keep-Off Measurement

Once the wire and core edges are detected, the system calculates the keep-off distance. This measurement is derived by computing the difference in y-coordinates between the detected edges. The result is displayed to the user, ensuring precise verification of compliance with specified tolerances.

6. Manual Measurement Mode

Users can manually measure distances by clicking on specific points in the image. The system supports both x-axis and y-axis measurements, allowing operators to verify distances interactively.

## Error Handling

**Camera Errors**: If the camera fails to initialize, the user receives an error message with troubleshooting details.

**Calibration Errors**: If calibration data is missing, the system prompts the user to complete the calibration before proceeding with measurements.

**Contour Detection Issues**: If contours are not detected correctly, users are advised to adjust threshold values to improve image processing accuracy.

# Conclusion

The KeepOffMeasure system provides a reliable and efficient method for measuring keep-off distances in industrial applications. Through real-time video capture, calibration, and automated contour detection, the system enhances precision and streamlines the measurement process for quality control and compliance verification