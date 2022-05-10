![ZigZag MenuArt.png](https://github.com/mwb-wiseman/ZigZag/blob/main/GDD%20Images/ZigZag%20MenuArt.png)

# ZigZag Clone

## Introduction

This document outlines the plan for the development of a ZigZag clone. This project is being undertaken for technical learning purposes (C# language, Unity engine), while engaging with the original game's design to create a novel experience.

__Key New Features__

- Aesthetic theme suggests a narrative; provides marketing opportunity and appeal to sci-fi consumer demographics.
- Difficulty settings to provide a customisable experience.

__Key Learning Objectives__

- Character animation
- Procedurally generated level design
- Stored user settings data (e.g. sound volume, high score)
- Build for Android

***

## GAME DESIGN

#### High Concept

ZigZag is a 3D, single-player endless running game in which the player runs left or right to follow the path and collect supplies to accumulate points.

#### Summary Overview

The player controls a spaceman constantly running along a gantry to collect as many supplies as possible before they fall off.

![ZigZag Art 1.png](https://github.com/mwb-wiseman/ZigZag/blob/main/GDD%20Images/ZigZag%20Art%201.png)

Using a single input, the player toggles between running diagonally left and right to follow the path. The player accumulates points by running through items spaced out along the gantry at irregular intervals. The level is procedurally generated so there is no final win condition. When they fall off the gantry the player loses, and they can tap to restart.

__Key Features__

- Simple yet addictive gameplay
- Adjustable difficulty setting
- Procedurally generated level design to provide endless replay-ability

#### Gameplay

__First Minutes__

_Main Menu_

Buttons to start the game, navigate to the Settings menu or close the application. The Settings menu contains separate toggles to enable/disable sound effects and music, as well as volume controls. Starting the game brings up a semi-transparent overlay to choose difficulty – Cakewalk, Spacewalk or Death March (Easy/Normal/Hard).

_In-Game_

The level loads and, after 1 second, the player starts running diagonally right. By tapping the screen (Android) or pressing 'Space' (PC) they toggle the movement direction 90 degrees between diagonally left and right.

The player's current score is displayed at the top of the screen alongside their recorded high-score.

Tapping/clicking the cog icon in the top right of the screen opens a semi-transparent menu which pauses the game and provides 3 buttons to resume the game, open a Settings overlay (same options as Settings menu except difficulty) or navigate to the Main Menu with loss of current level progress.

__Gameflow__

![ZigZag Gameflow.png](https://github.com/mwb-wiseman/ZigZag/blob/main/GDD%20Images/ZigZag%20Gameflow.png)

__Victory Conditions__

Each level is endless and so there is no win condition; the aim is to accumulate as many points as possible before losing. The player loses if they fall off the platform, at which point their score is checked against the recorded high-score and replaces it if higher.

__Number of Players__

Single player.

#### Art

![ZigZag Art 2.png](https://github.com/mwb-wiseman/ZigZag/blob/main/GDD%20Images/ZigZag%20Art%202.png)

![ZigZag Art 3.png](https://github.com/mwb-wiseman/ZigZag/blob/main/GDD%20Images/ZigZag%20Art%203.png)

#### Technical Aspects

Game to be built in Unity for Android.

***

## MARKETING

#### Target Audience

The simplistic design will ensure this game is accessible to a broad audience, and will particularly lend itself to on-the-go entertainment.

Casual gamers – single input gameplay and easier difficulty options set a low bar for entry, with no pre-requisite skill or experience required to be able to enjoy the game.

Competitive gamers – recorded high-scores and higher difficulty settings provides a target to beat.

#### Competitors

Based on the original ZigZag, this clone retains the core gameplay concepts. Providing a loose narrative-led aesthetic will draw in additional players to whom a space/sci-fi aesthetic appeals. Three difficulty settings also enables player to lower the bar at entry, if required, which will help to retain players struggling on the standard difficulty - a feature that is not present in the original game.

A big name in the endless-runner genre is Temple Run. Similarly to the original ZigZag game, this has a fixed difficulty which cannot be altered. Temple Run also features a variety of player inputs to respond to different obstacles, adding to the game's complexity and difficulty. This ZigZag clone should appeal to a more casual demographic, while still offering a challenge on higher difficulties if desired.

***

## DEVELOPMENT

#### Milestone Schedule

1. Set up basic scene – skybox, player character, basic platform, basic camera
2. Player movement and controls; camera movement
3. Character animation
4. Menu (including button functionality and sub-menus)
5. Collectables and score accumulation
6. Restart functionality and multi-scene data for volume Settings and Highscore
7. Procedural level generation
8. Audio; graphic design of menus
9. Play-test/Code review
10. Re-factor based on feedback

#### Resources

1 Junior Developer
Unity (Personal)

#### Schedule

| Time | Objective |
| --- | --- |
| Day 1 | Milestone 1 |
| Day 2 | Milestone 2 |
| Day 3 | Milestone 3 |
| Day 4 | Milestone 4 |
| Day 5 | Milestone 5 |
| Day 6 | Milestone 6 |
| Day 7 | Milestone 7 |
| Day 8 | Milestone 8 |
| Day 9 | Milestone 9 |
| Day 10 | “ |
| Day 11 | Milestone 10 |

