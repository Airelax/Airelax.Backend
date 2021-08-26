export default {
    houseCategories: [
        {
            type: 'Apartment',
            chinese: '公寓',
            mapping: 1,
            img: require('@/assets/pic/rent_page/apartment.jpg'),
            houseTypes: [
                {
                    type: 'RentalUnit',
                    chinese: '出租大樓',
                    description: '集合住宅大樓或複合式建築中的出租屋。',
                    mapping: 101,
                },
                {
                    type: 'Condo',
                    chinese: '私有公寓',
                    description: '位於集合住宅大樓或複合式建築的住處，產權歸住戶所有。',
                    mapping: 102,
                },
                {
                    type: 'Loft',
                    chinese: 'Loft空間',
                    description: '開放式的公寓，內牆可能較矮。',
                    mapping: 103,
                },
                {
                    type: 'ServicedApartment',
                    chinese: '服務式公寓',
                    description: '由專業管理公司提供飯店式管理服務的公寓。',
                    mapping: 104,
                },
                {
                    type: 'CasaParticular',
                    chinese: '古巴家庭旅館',
                    description: '古巴家庭旅館內的獨立房間。',
                    mapping: 105,
                },
            ]
        },
        {
            type: 'House',
            chinese: '獨棟房屋',
            mapping: 2,
            img: require('@/assets/pic/rent_page/House.jpg')
        },
        {
            type: 'SecondaryUnit',
            chinese: '附屬建築',
            mapping: 3,
            img: require('@/assets/pic/rent_page/SecondaryUnit.jpg')
        },
        {
            type: 'UniqueSpace',
            chinese: '獨特房源',
            mapping: 4,
            img: require('@/assets/pic/rent_page/UniqueSpace.jpg')
        },
        {
            type: 'BreakAndBreakfast',
            chinese: '家庭式旅館',
            mapping: 5,
            img: require('@/assets/pic/rent_page/BreakAndBreakfast.jpg')
        },
        {
            type: 'BoutiqueHotel',
            chinese: '精品旅館',
            mapping: 6,
            img: require('@/assets/pic/rent_page/BoutiqueHotel.jpg')
        },
    ],

    roomTypes: [
        {
            type: 'EntirePlace',
            chinese: '整套房源',
            mapping: 1,
        },
        {
            type: 'PrivateRoom',
            chinese: '獨立房間',
            mapping: 2,
        },
        {
            type: 'SharedRoom',
            chinese: '合住房間',
            mapping: 3,
        },
    ],
    facilities: [
        {
            name: 'SwimmingPool',
            chinese: '游泳池',
            mapping: '1109',
            img: require('@/assets/pic/rent_page/SwimmingPool.svg'),
            tag: "unique"
        },
        {
            name: 'Jacuzzi',
            chinese: '按摩浴缸',
            mapping: '1106',
            img: require('@/assets/pic/rent_page/Jacuzzi.svg'),
            tag: "unique"
        },
        {
            name: 'Yard',
            chinese: '庭院',
            mapping: '1012',
            img: require('@/assets/pic/rent_page/Yard.svg'),
            tag: "unique"
        },
        {
            name: 'BBQ',
            chinese: '烤肉區',
            mapping: '1002',
            img: require('@/assets/pic/rent_page/BBQ.svg'),
            tag: "unique"
        },
        {
            name: 'FirePit',
            chinese: '火坑',
            mapping: '1006',
            img: require('@/assets/pic/rent_page/FirePit.svg'),
            tag: "unique"
        },
        {
            name: 'Billiards',
            chinese: '撞球桌',
            mapping: '307',
            img: require('@/assets/pic/rent_page/Billiards.svg'),
            tag: "unique"
        },
        {
            name: 'IndoorFireplace',
            chinese: '室內壁爐',
            mapping: '504',
            img: require('@/assets/pic/rent_page/IndoorFireplace.svg'),
            tag: "unique"
        },
        {
            name: 'OutdoorEatSpace',
            chinese: '室外用餐區',
            mapping: '1009',
            img: require('@/assets/pic/rent_page/OutdoorEatSpace.svg'),
            tag: "unique"
        },
        {
            name: 'SportsEquipment',
            chinese: '運動器材',
            mapping: '303',
            img: require('@/assets/pic/rent_page/SportsEquipment.svg'),
            tag: "unique"
        },

        {
            name: 'Wifi',
            chinese: 'Wifi',
            mapping: '702',
            img: require('@/assets/pic/rent_page/Wifi.svg'),
            tag: "popular"
        },
        {
            name: 'Television',
            chinese: '電視',
            mapping: '310',
            img: require('@/assets/pic/rent_page/TV.svg'),
            tag: "popular"
        },
        {
            name: 'Kitchen',
            chinese: '廚房',
            mapping: '803',
            img: require('@/assets/pic/rent_page/Kitchen.svg'),
            tag: "popular"
        },
        {
            name: 'WashMachine',
            chinese: '洗衣機',
            mapping: '211',
            img: require('@/assets/pic/rent_page/WashMachine.svg'),
            tag: "popular"
        },
        {
            name: 'FreeBuildingParking',
            chinese: '建築物內免費停車',
            mapping: '1103',
            img: require('@/assets/pic/rent_page/FreeBuildingParking.svg'),
            tag: "popular"
        },
        {
            name: 'PaidBuildingParking',
            chinese: '建築物內有收費停車位',
            mapping: '1108',
            img: require('@/assets/pic/rent_page/PaidBuildingParking.svg'),
            tag: "popular"
        },
        {
            name: 'AirConditioner',
            chinese: '空調設備',
            mapping: '501',
            img: require('@/assets/pic/rent_page/AirConditioner.svg'),
            tag: "popular"
        },
        {
            name: 'WorkSpace',
            chinese: '專門工作空間',
            mapping: '701',
            img: require('@/assets/pic/rent_page/WorkSpace.svg'),
            tag: "popular"
        },
        {
            name: 'OutDoorBathSpace',
            chinese: '戶外沐浴空間',
            mapping: '108',
            img: require('@/assets/pic/rent_page/OutDoorBathSpace.svg'),
            tag: "popular"
        },

        {
            name: 'SmokeAlarm',
            chinese: '煙霧警報器',
            mapping: '605',
            img: require('@/assets/pic/rent_page/SmokeAlarm.svg'),
            tag: "safety"
        },
        {
            name: 'FirstAidKit',
            chinese: '急救包',
            mapping: '603',
            img: require('@/assets/pic/rent_page/FirstAidKit.svg'),
            tag: "safety"
        },
        {
            name: 'CarbonMonoxideAlarm',
            chinese: '一氧化碳警報器',
            mapping: '601',
            img: require('@/assets/pic/rent_page/CarbonMonoxideAlarm.svg'),
            tag: "safety"
        },
        {
            name: 'LockBedroom',
            chinese: '帶鎖的臥室',
            mapping: '604',
            img: require('@/assets/pic/rent_page/LockBedroom.svg'),
            tag: "safety"
        },
        {
            name: 'FireExtinguisher',
            chinese: '滅火器',
            mapping: '602',
            img: require('@/assets/pic/rent_page/FireExtinguisher.svg'),
            tag: "safety"
        },
    ],
    houseHighlight: [
        {
            name: 'Peaceful',
            chinese: '寧靜',
            mapping: '1',
            img: require('@/assets/pic/rent_page/Peaceful.svg')
        },
        {
            name: 'Unique',
            chinese: '獨具特色',
            mapping: '2',
            img: require('@/assets/pic/rent_page/Unique.svg')
        },
        {
            name: 'FamilyFriendly',
            chinese: '適合家庭入住',
            mapping: '3',
            img: require('@/assets/pic/rent_page/FamilyFriendly.svg')
        },
        {
            name: 'Stylish',
            chinese: '風格十足',
            mapping: '4',
            img: require('@/assets/pic/rent_page/Stylish.svg')
        },
        {
            name: 'Central',
            chinese: '位於市中心',
            mapping: '5',
            img: require('@/assets/pic/rent_page/Central.svg')
        },
        {
            name: 'Spacious',
            chinese: '寬敞',
            mapping: '6',
            img: require('@/assets/pic/rent_page/Spacious.svg')
        },
    ]
}