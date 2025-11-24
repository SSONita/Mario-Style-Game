# 🎮 2D Mario-Style Platformer (Unity)

## 📌 Project Overview
This project is a 2D side-scrolling platformer inspired by classic Mario games.  
Players can run, jump, collect coins, defeat enemies, and progress through multiple levels. 

## 🧩 Core Features

### 👤 Player
- Rigidbody2D + BoxCollider2D
- Animator (Idle, Run, Jump, Fall)
- PlayerController script (movement, jumping, gravity, sprite flip)

### 🪨 Ground / Platforms
- Tilemap Renderer + BoxCollider2D
- Optional Platform Effector 2D (one-way platforms)

### 👾 Enemies (Goomba-style)
- Patrol AI
- Defeated when jumped on
- Damages player on collision

### 💰 Coins / Collectibles
- Trigger collider
- Collectible script (score increment, destroy on collect)

### ⚡ Power-Ups
- Speed boost, extra life, temporary invincibility
- Rigidbody2D + BoxCollider2D
- PowerUp script

## 🛠 Essential Components
| Component       | Purpose                        |
|-----------------|--------------------------------|
| Rigidbody2D     | Physics & gravity              |
| Collider2D      | Collision detection            |
| Animator        | Controls animations            |
| Tilemap         | Grid-based level design        |
| Camera Follow   | Keeps camera centered on player|


## 🚀 Development Phases
1. **Setup** – Create Unity project, folder structure, import assets  
2. **Player Movement** – Implement controls, physics, animations  
3. **Level Design** – Build tilemaps, platforms, obstacles  
4. **Enemies & Items** – Add patrol AI, collectibles, power-ups  
5. **Camera & UI** – Smooth follow camera, score & lives UI  
6. **Game Flow** – Checkpoints, respawn, level completion  
7. **Polish** – Audio, particle effects, transitions  

# 🧑‍💻 Game Manager System
- **GameManager** – Score, lives, restart logic  
- **AudioManager** – Music & sound effects  
- **LevelManager** – Scene transitions & level progression  

## 🎮 Gameplay
- **Objective:** Reach the end of each level while collecting coins and avoiding hazards.  
- **Controls:**  
  - Move Left: `A / ←`  
  - Move Right: `D / →`  
  - Jump: `Spacebar`  
  - Attack/Special (optional): `J`  

- **Rules:**  
  - Player starts with 3 lives  
  - Falling or enemy collision reduces lives  
  - Score increases via coins, defeating enemies, fast completion  


## 🏆 Win / Lose Conditions
- **Win:** Reach the final goal, defeat boss, or achieve target score  
- **Lose:** Lives reach 0 or timer runs out  

## Enjoy!!!!