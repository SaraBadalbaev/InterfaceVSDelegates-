# InterfaceVSDelegates #

## Overview

This project demonstrates a menu system implemented using two different approaches in C#: delegates and interfaces. The goal is to handle user interactions through a hierarchical menu structure where each menu item performs specific actions.

## Features

* **Menu Hierarchy**: Supports nested menus with sub-menu items.
* **Delegates Implementation**: Uses delegates for event-driven actions.
* **Interfaces Implementation**: Utilizes interfaces and command pattern for actions.
* **Commands**: Includes commands for showing the date, time, version, and counting capital letters in a sentence.

## Project Structure

**Menus.Delegates**
* **MainMenu**: Manages a list of sub-menu items and displays the menu.
* **SubMenuItem**: Represents an individual menu item with an event for actions.
* **ClickEventHandler**: Delegate for handling menu item clicks.

**Menus.Interfaces**
* **MainMenu**: Manages a list of sub-menu items and displays the menu.
* **MenuItem**: Represents an individual menu item and supports attaching listeners.
* **IListener**: Interface for handling menu actions.
* **Command Classes**: Implement the IListener interface to perform specific actions:
* **CountCapitalsCommand**: Counts and displays the number of uppercase letters in a sentence.
* **ShowDateCommand**: Displays the current date.
* **ShowTimeCommand**: Displays the current time.
* **ShowVersionCommand**: Displays the application version.

## Test Classes
* **MenusDelegates**: Demonstrates the delegate-based menu system.
* **MenusInterfaces**: Demonstrates the interface-based menu system.
* **Program**: Entry point to test both menu systems.
