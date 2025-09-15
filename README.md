Mini-Adventure (C# Console)

A small, menu-driven C# console RPG where you name your hero, pick a class (Warrior/Mage), fight random enemies, manage health/mana, collect gold & loot, taunt to reduce enemy hit chance, rest at bonfires, and upgrade stats in a shop.

Extended description

Built to practice core C# fundamentals:

Classes/objects (Adventurer, Enemies, GameMechanics)

Control flow (loops, branching, switch, ternary)

Collections (List<string> inventory) & basic counting logic

Randomization (Random.Next / NextDouble)

Input validation & simple exception handling

Separation of concerns across files

Features

Two classes: Warrior (more HP) or Mage (more damage & mana)

Turn-based combat: Attack, Heal (mana), Taunt, or Run

Taunt system: each taunt lowers enemy hit chance by 20% (stacking up to 5)

Bonfire rest: restore mana and heal (costs 15 gold)

Shop: spend 80 gold to raise Damage +50 and MaxHealth +50 (full heal)

Progression: gold/loot per kill, enemy scaling by defeats

Inventory: shows unique items with counts (e.g., 2x - Bread)



Gameplay loop

Name your adventurer → choose class (W/M).

Use the menu:

(1) Adventure → spawn random enemy (Giant Rat, Goblin, Skeleton, Bandit) with scaling damage; fight in a loop.

(2) Rest at Bonfire → heal HP (up to +60 or full) & refill mana, costs 15 gold.

(3) Check Status → show stats & defeats.

(4) Inventory → grouped list of loot with counts.

(5) Shop → spend 80 gold to increase Damage +50 and MaxHealth +50 (fully heals).

(6) Quit.

Combat choices:

Attack: reduces enemy HP by your Damage.

Heal: costs 15 mana, restores +40 HP (or to full if close).

Taunt: raises taunt counter (max 5). Each stack –20% to enemy hit chance.

Run: end the battle (no rewards).

