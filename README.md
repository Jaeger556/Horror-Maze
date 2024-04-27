# Horror Maze

This project is a video game for my capstone class. Its gameplay consists of exploring a maze while being tracked by a bloodthirsty monster. The player's objective is to locate three objects that are linked to the creature's soul. Once the player has collected all three objects the monster is defeated. Although, the monster is an experienced hunter and will track the player efficiently. If the player doesn't find the objects to defeat the monster quickly enough they will surely meet their demise.

## Controls

<p>Walk: WASD <br>
Run: Left-Shift <br>
Jump: Spacebar <br>
Flashlight: Left-Click

## Tutorial

1. Survive: Flee the monster while trying to locate and collect teddy bears needed to defeat it.

2. Flashlight: Use your flashlight to navigate the pitch black maze while keeping an eye out for the monster.

3. Monster: You aren't the first victim of this beast. It seems to always have an idea of where its victims are. But, it is known to become impatient when it loses sight of its prey.

4. Victory: Find and collect the three tedddy bears within the maze. Once the third is collected the monster will crumble in defeat.

5. Die: Don't underestimate the expertise of the creature. It can swiftly cut its victims down and will do so in only three swipes of its elongated spike arm.

6. Good Luck.

### Installing

Download the files and locate the executable within the build folder!

## Built With

* [Unity]

## Use-Case Diagram

![Capstone Use-Case drawio](https://github.com/Jaeger556/Horror-Maze/assets/46098988/d8abf203-a942-49af-8808-7eaba23052f1)


## Class Diagram

![Capstone Class Diagram drawio(3)](https://github.com/Jaeger556/Horror-Maze/assets/46098988/b7cbd286-38df-422c-aca5-da583790fd05)

### Class Relationships

**EnemyAI - Pickup:**
EnemyAI script utilizes static variable bearCount to disable the monster's pathfinding when the player game object is destroyed from taking enough damage. 

**HUDController - Pickup:**
HUDController script uses the static bearCount variable to enable a bear icon each time bearCount increases, up to three.

**AttributeManager - Healthbar:**
AttributeManager script accesses Healthbar's UpdateHealthBar function to adjust the player's healthbar according to the damage dealt.

**AttributeManager - DamageEffectPP**
AttributeManager script accesses DamageEffectPP's damageCoroutine to play the damage flash effect once the DealDamage function is called within AttributeManager

## Authors

* **Blaze Shofner**

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

### Unity Assets that made this game possible!
* Monster Scavenger by Max Antonov [Asset Store Page](https://assetstore.unity.com/packages/3d/characters/monster-scavenger-191323)
* Maze Generator by Styanton [Asset Store Page](https://assetstore.unity.com/packages/tools/modeling/maze-generator-38689)
* Low Poly Dungeons Lite by JustCreate [Asset Store Page](https://assetstore.unity.com/packages/3d/environments/dungeons/low-poly-dungeons-lite-177937)
* Lowpoly Dungeon Assets by Kunniki [Asset Store Page](https://assetstore.unity.com/packages/3d/environments/dungeons/lowpoly-dungeon-assets-117330)
* FMOD for Unity by FMOD [Asset Store Page](https://assetstore.unity.com/packages/tools/audio/fmod-for-unity-161631)
* Modular First Person Controller by JeCase [Asset Store Page](https://assetstore.unity.com/packages/3d/characters/modular-first-person-controller-189884)
* Free Christmas Presents / Low Poly by BRAiNBOX [Asset Store Page](https://assetstore.unity.com/packages/3d/props/free-christmas-presents-low-poly-24356)
