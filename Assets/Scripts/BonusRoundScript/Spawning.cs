using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    //Foods
    public GameObject[] Food;
    //Garbage
    public GameObject[] Garbage;
    //Spawn
    public GameObject[] spawnPoint;


    //Holder
    int FGSpawn;
    int FoodHolder;
    int GarbageHolder;
    int spawnPointHolder;
    int SpawnListNo = 0;
    
    // FoodVariable
    float Speed = 3;
    float sp = 1;
    
    void Start()
    {
        Spawned();
        //GameObject spawn = Instantiate(Food[0],spawnPoint[1].transform);
        //spawn.GetComponent<Falling>().speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawned()
    {
        if(SpawnListNo < 60)
        {
            if(SpawnListNo == 19)
            {
                Speed = 6;
                sp = 0.75f;
            }
            if (SpawnListNo == 39)
            {
                Speed = 9;
                sp = 0.5f;
            }
        //SpawnList(SpawnListNo);
        SpawningFG();
        Invoke("SpawnType", sp);
        }
    }



    //Spawn List
    void SpawnList(int sln)
    {
        //1 Food = 0 Bacon = 0 LocM = 1
        if(sln == 0)
        {
            FGSpawn = 0;
            FoodHolder = 0;
            spawnPointHolder = 1;
        }
        //2 Food = 0 Meat = 2 LocM = 1
        if (sln == 1)
        {
            FGSpawn = 0;
            FoodHolder = 2;
            spawnPointHolder = 1;
        }
        //3 Food = 0 Beef = 1 LocL = 0
        if (sln == 2)
        {
            FGSpawn = 0;
            FoodHolder = 1;
            spawnPointHolder = 0;
        }
        //4 Food = 0 Sausage = 3 LocL = 0
        if (sln == 3)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //5 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 4)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //6 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 5)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //7 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 6)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //8 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 7)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //9 Food = 0 Sausage = 3 LocR = 2
        if (sln == 8)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 2;
        }
        //10 Food = 0 Sausage = 3 LocL = 0
        if (sln == 9)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //1 Food = 0 Bacon = 0 LocM = 1
        if (sln == 10)
        {
            FGSpawn = 0;
            FoodHolder = 0;
            spawnPointHolder = 1;
        }
        //2 Food = 0 Meat = 2 LocM = 1
        if (sln == 11)
        {
            FGSpawn = 0;
            FoodHolder = 2;
            spawnPointHolder = 1;
        }
        //3 Food = 0 Beef = 1 LocL = 0
        if (sln == 12)
        {
            FGSpawn = 0;
            FoodHolder = 1;
            spawnPointHolder = 0;
        }
        //4 Food = 0 Sausage = 3 LocL = 0
        if (sln == 13)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //5 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 14)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //6 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 15)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //7 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 16)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //8 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 17)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //9 Food = 0 Sausage = 3 LocR = 2
        if (sln == 18)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 2;
        }
        //10 Food = 0 Sausage = 3 LocL = 0
        if (sln == 19)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //1 Food = 0 Bacon = 0 LocM = 1
        if (sln == 20)
        {
            FGSpawn = 0;
            FoodHolder = 0;
            spawnPointHolder = 1;
        }
        //2 Food = 0 Meat = 2 LocM = 1
        if (sln == 21)
        {
            FGSpawn = 0;
            FoodHolder = 2;
            spawnPointHolder = 1;
        }
        //3 Food = 0 Beef = 1 LocL = 0
        if (sln == 22)
        {
            FGSpawn = 0;
            FoodHolder = 1;
            spawnPointHolder = 0;
        }
        //4 Food = 0 Sausage = 3 LocL = 0
        if (sln == 23)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //5 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 24)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //6 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 25)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //7 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 26)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //8 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 27)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //9 Food = 0 Sausage = 3 LocR = 2
        if (sln == 28)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 2;
        }
        //10 Food = 0 Sausage = 3 LocL = 0
        if (sln == 29)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //1 Food = 0 Bacon = 0 LocM = 1
        if (sln == 30)
        {
            FGSpawn = 0;
            FoodHolder = 0;
            spawnPointHolder = 1;
        }
        //2 Food = 0 Meat = 2 LocM = 1
        if (sln == 31)
        {
            FGSpawn = 0;
            FoodHolder = 2;
            spawnPointHolder = 1;
        }
        //3 Food = 0 Beef = 1 LocL = 0
        if (sln == 32)
        {
            FGSpawn = 0;
            FoodHolder = 1;
            spawnPointHolder = 0;
        }
        //4 Food = 0 Sausage = 3 LocL = 0
        if (sln == 33)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //5 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 34)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //6 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 35)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //7 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 36)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //8 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 37)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //9 Food = 0 Sausage = 3 LocR = 2
        if (sln == 38)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 2;
        }
        //10 Food = 0 Sausage = 3 LocL = 0
        if (sln == 39)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //1 Food = 0 Bacon = 0 LocM = 1
        if (sln == 40)
        {
            FGSpawn = 0;
            FoodHolder = 0;
            spawnPointHolder = 1;
        }
        //2 Food = 0 Meat = 2 LocM = 1
        if (sln == 41)
        {
            FGSpawn = 0;
            FoodHolder = 2;
            spawnPointHolder = 1;
        }
        //3 Food = 0 Beef = 1 LocL = 0
        if (sln == 42)
        {
            FGSpawn = 0;
            FoodHolder = 1;
            spawnPointHolder = 0;
        }
        //4 Food = 0 Sausage = 3 LocL = 0
        if (sln == 43)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //5 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 44)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //6 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 45)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //7 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 46)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //8 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 47)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //9 Food = 0 Sausage = 3 LocR = 2
        if (sln == 48)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 2;
        }
        //10 Food = 0 Sausage = 3 LocL = 0
        if (sln == 49)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //1 Food = 0 Bacon = 0 LocM = 1
        if (sln == 50)
        {
            FGSpawn = 0;
            FoodHolder = 0;
            spawnPointHolder = 1;
        }
        //2 Food = 0 Meat = 2 LocM = 1
        if (sln == 51)
        {
            FGSpawn = 0;
            FoodHolder = 2;
            spawnPointHolder = 1;
        }
        //3 Food = 0 Beef = 1 LocL = 0
        if (sln == 52)
        {
            FGSpawn = 0;
            FoodHolder = 1;
            spawnPointHolder = 0;
        }
        //4 Food = 0 Sausage = 3 LocL = 0
        if (sln == 53)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
        //5 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 54)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //6 Garabage = 1 FishBone = 1 LocM = 1
        if (sln == 55)
        {
            FGSpawn = 1;
            GarbageHolder = 1;
            spawnPointHolder = 1;
        }
        //7 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 56)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //8 Garabage = 1 Bone = 0 LocR = 2
        if (sln == 57)
        {
            FGSpawn = 1;
            GarbageHolder = 0;
            spawnPointHolder = 2;
        }
        //9 Food = 0 Sausage = 3 LocR = 2
        if (sln == 58)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 2;
        }
        //10 Food = 0 Sausage = 3 LocL = 0
        if (sln == 59)
        {
            FGSpawn = 0;
            FoodHolder = 3;
            spawnPointHolder = 0;
        }
    }

    void SpawningFG()
    {
        
        FGSpawn = Random.Range(0,2);
        FoodHolder = Random.Range(0, 4);
        GarbageHolder = Random.Range(0, 2);
        spawnPointHolder = Random.Range(0, 3);
        
    }
    //Spawn Type
    //0 - Food
    //1 - Garbage
    void SpawnType()
    {
        //Food
        if(FGSpawn == 0)
        {
            GameObject spawn = Instantiate(Food[FoodHolder], spawnPoint[spawnPointHolder].transform);
            spawn.GetComponent<Falling>().speed = Speed;
        }
        //Garbage
        if(FGSpawn == 1)
        {
            GameObject spawn = Instantiate(Garbage[GarbageHolder], spawnPoint[spawnPointHolder].transform);
            spawn.GetComponent<Falling>().speed = Speed;
        }
        SpawnListNo++;
        Spawned();
    }
}
