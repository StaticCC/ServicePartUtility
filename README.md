# Parts Tracking System

This WinForm C# .NET project facilitates tracking parts and providing statuses to link the Parts Department and Service Department of a dealership.

It's goal is to provide an accurate shipping Status and ETA directly through Parts Workbench Plus instead of relying on serperate software.

## Introduction

The `GetETAFromPWB` method is a crucial component of this project. It automates the retrieval of Estimated Time of Arrival (ETA) data for parts from PWB+ (a website) using Chrome WebDriver through Selenium automation. It iterates over a list of parts, navigates through login pages, fetches shipment details, and updates the database with the ETA and status of each part.

## Method Overview

### Method Name: `GetETAFromPWB`

### Description

This method retrieves Estimated Time of Arrival (ETA) data for parts from PWB+ using Chrome WebDriver through Selenium automation. It navigates through login pages, fetches shipment details, and updates the database with the ETA and status of each part.

### Parameters

- `worker`: A `BackgroundWorker` object used to report progress to the GUI thread.

### Returns

Void Method (None)

### Steps

1. Clones the list of parts to avoid updating the main part data until complete.
2. Iterates through each part in the cloned list.
3. Sets up a headless Chrome WebDriver with Selenium for automated browsing.
4. Navigates to the login page of `autopartners.net` and logs in with provided credentials.
5. Navigates to the purchase orders page on PWB+ for the current part.
6. Waits for the `controlNumber` element to ensure the page is loaded.
7. Checks if the shipment exists. If not, continues to the next part.
8. Finds and clicks the XMS link to proceed to shipment tracking.
9. Navigates to the shipment tracking URL.
10. Retrieves the status of the shipment and handles different scenarios.
11. Updates the database with the ETA and status of the part.
12. Closes the WebDriver connection for the current part.
13. Reports progress to the GUI thread using the provided `BackgroundWorker`.
14. Closes and quits the current ChromeDriver connection and loops until complete.

### Note

This method relies on specific HTML structure and may require adjustments if the structure of the target websites changes.

## Usage

To use this method, ensure you have the necessary dependencies installed, including Chrome WebDriver and Selenium. Then, integrate the `GetETAFromPWB` method into your project and provide the required parameters.

## Contributions

Contributions to this project are welcome. If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.
