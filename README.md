# .NET Assignment 1

Assignment 1 of the .NET Course of Noroff. An RPG-based class-system in C#. 

## Description
A mini RPG project, mainly focused on the basics of OOP in C#. There are several classes for charactertypes, itemtypes, character-attributes and custom exceptions. 

## Usage
```
git clone
// Downloads the git repo to your machine
// Open the .sln file, then open a console and type:
dotnet run
```
## Project Structure
The classes are structured as follows:
- Attributes
  - PrimaryAttribute: A class for the primary attributes a character can have, including Strength, Dexterity and Intelligence
- Characters
  - Character: The abstract base class for all the charactertypes
    - Mage: One of the character types, with mainly high Intelligence
    - Ranger: One of the character types with mainly high Dexterity 
    - Rogue: One of the character types with mainly high Dexterity and Strength
    - Warrior: One of the character types with mainly high Strength
- InvalidWeaponException
  - InvalidWeaponException: A custom exception to throw when a character cannot equip a weapon in the current state
- Items
  - Item: The abstract base class for all the item types
    - Armour: An item type for all the armour types a character can wear
    - Equipment: An item type for all the equipment types a character can equip
    - Weapon: An item type for all the weapon types a character can equip

## Authors and acknowledgment
Project coded by Fenna Ransijn, classes, items and attributes based on the game Diablo 2.
Project logo from [www.freepik.com](https://www.freepik.com/author/svetlanapaneva)  
