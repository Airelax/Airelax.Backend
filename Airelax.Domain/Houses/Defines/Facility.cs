namespace Airelax.Domain.Houses.Defines
{
    public enum Facility
    {
        // 1xx bath
        Tub = 101, //浴缸
        Bidet = 102, //坐浴盆
        BodyWash = 103,
        CleanProduct = 104,
        Conditioner = 105, //護髮乳
        HairDryer = 106,
        HotWater = 107,
        OutDoorBathSpace = 108, //戶外沐浴空間
        Shampoo = 109,

        // 2xx bathroom and wash
        LifeNecessities = 201,
        Sheet = 202, //床單
        Wardrobe = 203, //衣櫥
        ClothesDryer = 204,
        Clotheshorse = 205, //曬衣架(竿)
        ExtraBedding = 206,
        Hanger = 207, //衣架
        Iron = 208, //熨斗
        MosquitoNet = 209, //蚊帳
        Curtain = 210, // 窗簾
        WashMachine = 211,

        // 3xx entertainment
        Books = 301,
        Ethernet = 302, //網路線
        SportsEquipment = 303, //運動器材
        GameHost = 304, //遊戲主機
        Piano = 305,
        PingPang = 306,
        Billiards = 307, //撞球
        VinylRecordPlayer = 308, //黑膠唱片機
        Audio = 309,
        Television = 310,

        // 4xx Parent-child
        //todo

        // 5xx AirConditioner
        //todo
        AirConditioner = 501, //空調設備
        IndoorFireplace = 504, //室內壁爐

        // 6xx Safety
        CarbonMonoxideAlarm = 601, //一氧化碳警報器
        FireExtinguisher = 602, //滅火器
        FirstAidKit = 603, //急救包
        LockBedroom = 604, //帶鎖的臥室
        SmokeAlarm = 605, //煙霧警報器

        //7xx office
        WorkSpace = 701, //專門工作空間
        Wifi = 702,

        //8xx kitchen
        //todo
        Kitchen = 803,

        //9xx Location
        //todo

        //10xx outdoor
        //todo
        BBQ = 1002, //烤肉區
        FirePit = 1006, //火坑

        OutdoorEatSpace = 1009, //室外用餐區
        Yard = 1012, //庭院

        //11xx Parking and other
        //todo
        FreeBuildingParking = 1103, //建築物內免費停車
        Jacuzzi = 1106, //按摩浴缸
        PaidBuildingParking = 1108, //建築物內有收費停車位
        SwimmingPool = 1109,


        //等


        BasicKitchenware = 1004, //基本廚具
        Tableware = 1006, //餐具
        Heater = 1009,
    }
}