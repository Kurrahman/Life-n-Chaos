# Life n' Chaos
## Deskripsi
Life n' Chaos adalah permainan platformer sederhana dengan menggunakan assets dari https://pixel-frog.itch.io/kings-and-pigs.
Game ini dimainkan dengan menggerakkan pemain bersenjatakan sebuah Warhammer bertujuan untuk bertahan dari serbuan pasukan BABI.
Game ini berbasis Wave Enemy dengan endless level, di setiap level ke-N akan terdapat 4xN buah musuh yang akan spawn di 4 buah tempat yang berbeda.

Game ini dimainkan dengan menggunakan :
- Arrows Button untuk menggerakan pemain, 
- Tombol Z untuk melompat, 
- Dan tombol X untuk menyerang.
Akan terdapat 3 buah musuh berbeda yang dapat muncul secara acak di permainan ini, Babi Normal, Babi Kotak, dan Babi Bom yang masing-masing memiliki karakteristik masing-masing.

## Cara Kerja
### Movement Player
Pemain digerakkan dengan memberikan kecepatan horizontal ketika tombol kanan atau kiri ditekan dan memberikan gaya pada rigidBody2D ketika tombol loncat ditekan

Ketika tombol serang ditekan, pemain akan memainkan animasi menyerang dan pada frame terakhir akan men-trigger fungsi untuk melakukan damage

### Spawn Enemy
Enemy dijadikan sebuah prefab, dan pada lapangan permainan disediakan 4 buah spawn point berbentuk pintu. untuk setiap wave pintu akan terbuka dan spawner tersebut akan menginstansiasi enemy baru dengan merandom diantara 3 buah musuh yang tersedia di setiap spawn.

### Wave Management
Untuk setiap 1 menit permainan, akan terhitung sebagai wave baru tanpa peduli apakah pemain telah menyelesaikan wave sebelumnya, dan untuk setiap counter wave, setiap pintu akan men-spawn enemy sebanyak wave saat itu dan ketika seluruh enemy untuk wave tersebut selesai di-spawn pintu akan tertutup kembali.

### Enemy AI
Untuk AI Enemy terbagi menjadi 2 :
- ChaseAndHit
-- Chase and hit cukup sederhana, musuh mendekati pemain dengan memanfaatkan pathfinding dari A* Pathfinder dan ketika musuh sudah cukup dekat, musuh akan mencoba memukul pemain
- ChaseAndThrow
-- Chase and throw pada dasarnya melakukan hal yang sama, perbedaannya adalah musuh dengan AI ini akan berhenti mengejar ketika jaraknya cukup jauh, dan ketika berhenti akan melempar barang yang dibawa ke arah pemain.
  
### Health & Point
Nyawa pemain disimbolkan dengan 3 buah hati yang berada di pojok kiri atas layar, untuk setiap kali pemain terkena damage hati yang paling kanan akan menjadi hati kecil terlebih dahulu kemudian akan menghilang (Nyawa di awal adalah 6 dan seluruh bentuk damage akan dianggap 1 dengan jeda invulnerable bagi pemain).

Untuk setiap jenis enemy diberi nilai yang berbeda:
- Normal Pig -- 1
- Box Pig -- 3
- Bomb Pig -- 5

### Audio
Audio dimainkan dengan AudioSource dengan multiplier AudioSettings untuk mengatur kenyaringan audio

## Library Luar
Selain menggunakan library bawaan Unity, saya menggunakan A* Pathfinder yang disediakan https://arongranberg.com/astar/
library ini saya gunakan sebagai dasar dari Pathfinding Babi di permainan ini.

## Screenshot
### Main Menu
![image](https://user-images.githubusercontent.com/38101533/78910132-acc96780-7aae-11ea-844e-bce582e1153d.png)

### Settings
![image](https://user-images.githubusercontent.com/38101533/78910269-e4381400-7aae-11ea-96cb-9e3f405dc21b.png)

### ScoreBoard
![image](https://user-images.githubusercontent.com/38101533/78910315-f619b700-7aae-11ea-914c-2b5ee4b293e0.png)

### Main Game
![1](https://user-images.githubusercontent.com/38101533/78909461-c0280300-7aad-11ea-818a-bc2580353a4c.png)

### Game Over
![image](https://user-images.githubusercontent.com/38101533/78910215-cd91bd00-7aae-11ea-8baa-8648958441d0.png)
