# Timeline

```
- Jesting Jetpacker: Febuary 2021 - March 2021

- Ball Hop: April 2021

- Quasar Quest: 2024 July - August 2024
```

## Jesting Jetpacker

### Overview of game

![Jesting Jetpacker Showcase](Jesting%20Jetpacker%20Scripts/showcase%20image/jesting%20jetpacker%20showcase.png)

[Watch the trailer](https://www.youtube.com/watch?v=1H9mcVTjLgU&t=48s)

In jesting jetpacker you dodge balloons flying towards you at a faster rate, when you hit a balloon the game ends. You can bounce them off you by collecting powerups which give you a forcefield for 3 seconds (the timer will be displayed). Your score is constantly increasing as shown at the top of the screen, you can pause if neccessary. When your score exceeds 2000 rockets will start to spawn in as well. At the end of the game your coins earnt are calculated based on your score and shown to you. You can then buy a revive for a small sum or click to return to the main menu. On the main menu you have several options. You can see current missions (such as get a score over 4000 with a certain upgrade equipped), missions are random and infintely generated based on your progress in the game. You can also open the shop menu or equip menu, where you can choose to buy different skins for your character and upgrades such as an intern which collects powerups for you, starting off with a headstart, getting double coins each time, etc. 

### What I learnt/My Journey

Jesting Jetpacker was my first big Unity game, I first started learning Unity C# in December of 2020 by reading the documentation and thinking of functionality (eg making a script triggered by a button) and finding forum posts explaining it. Within my first weekend I coded a basic game where you could move from wall to wall as the walls scrolled past forever, dodge shruikens, and get a high score, you could choose different skins and it had several scenes but that was it. I then straight away made a small infintely procedurally generated platformer (infinite jump), where you would jump to collect coins, and traverse terrain, this taught me about how to do procedural generation with OOP, timing with C# and many vital Unity skills, and how to manage scenes effectively for menus. I then made a 3D game where you would control a plane that I modelled, collect stars, and dodge cubes, teaching me about 3D modelling, and how to get Unity working in 3D. I then converted all these games to mobile, which was a challenge to get it to get UI to fit for different screen sizes, convert touchscreen into vectors etc. 

This was then when I started Jesting Jetpacker, it was my most ambitious project yet. It used the ideas from infinite jump of infintely generating obstacles by instiantiating gameobjects with different attributes, I worked out how to incorporate permenant storage so data such as coins, missions, skins, tools etc could be stored in between sessions, I learnt about accessing APIs as I briefly added adverts to it. Overall I learnt a lot about Unity/C#

## Ball Hop

### Overview of game

![Jesting Jetpacker Showcase](Ball%20Hop%20Scripts/showcase_images/ball%20hop%20showcase.png)

[Watch the trailer](https://www.youtube.com/watch?v=E_doF_Gnd5k&t=12s)

In Ball Hop you control a ball, moving it side to side to jump over different cars and trucks that generate forever, if you fall off you lose. You can collect oil tanks for an extra added score. Each second you car you jump over you get added score. You can switch skins by swiping accross on the menu and you can see your stats

## What I learnt

I learnt about 3D modelling more, as I made the cars and trucks in blender. I learnt about mechanics to get the ball to bounce correctly, I also learnt how to manipulate touchscreen input data to work out when someone is swiping accross the screen for example. 

## Quasar Quest 

### Overview of game 

Quasar Quest was my A Level Computer Science project (I made it completely unaided), it was largely inspired by Jesting Jetpacker which I had made a few years prior. However as this was to be examined I had to document the whole process following the specification, with the documentation being over 300 pages long, and add clear comments throughout, I also had to focus on my studies throughout slowing progress significantly.

In Quasar Quest you control a spaceship and dodge asteroids coming at you. The score increased each second you are alive. The asteroids scroll at a logarithmic rate towards you and generate following logarithmic decay. This is as I had read research from MIT suggesting humans naturally view the world logarithmically, and not linearly. When certain scores are exceeded new obstacles generate such as blackholes which move at different speeds as well as asteroids. Stars scroll past in the background. The player can pause the game if neccessary. Upon death the players coins are calculated based upon their score and they are told how many they earnt. They are informed of their current balance and they can choose to buy a revive or return to the main menu. There is also some random splash text upon death eg "Good Job!" or "New Highscore!" (if they got a new highscore). On the main menu they can view their missions which are infintely generated and based upon their current progress in the game to keep it contiously engaging. It also has a ship rotating displaying their current equipped skin. You can navigate to the shop or equip menu to buy and equip different skins for your ship and upgrades such as a chance at a free revive each time, double coins, etc. 
