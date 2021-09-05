import {createRouter, createWebHistory} from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: () => import('../views/Home.vue'),
    },
    {
        path: '/search',
        name: 'Search',
        component: () => import('../views/Search.vue')
    },
    {
        path: '/room',
        name: 'Room',
        component: () => import('../views/Room.vue')
    },
    {
        path: '/subscribe',
        name: 'Subscribe',
        component: () => import('../views/Subscribe.vue')
    },
    {
        path: '/wishList',
        name: 'wishList',
        component: () => import('../views/WishList.vue')
    },
    {
        path: '/become-host',
        name: 'BecomeHost',
        component: () => import('../views/NewHouse/BecomeHost.vue'),
        meta: {
            plainLayout: true,
        },
        children: [
            {
                path: '',
                name: 'NewHouse',
                component: () => import('../views/NewHouse/NewHouse.vue'),
            },
            {
                path: 'category',
                name: 'HouseCategory',
                component: () => import('../views/NewHouse/ChooseHouseCategory.vue'),
            },
            {
                path: ':id/category',
                name: 'HouseCategoryWithId',
                component: () => import('../views/NewHouse/ChooseHouseCategory.vue'),
            },
            {
                path: ':id/type',
                name: 'HouseType',
                component: () => import('../views/NewHouse/ChooseHouseType.vue'),
            },
            {
                path: ':id/room',
                name: 'RoomType',
                component: () => import('../views/NewHouse/ChooseRoomType.vue'),
            },
            {
                path: ':id/location',
                name: 'HouseLocation',
                component: () => import('../views/NewHouse/SetLocation.vue'),
            },
            {
                path: ':id/facilities',
                name: 'Facilities',
                component: () => import('../views/NewHouse/ChooseFacilities.vue'),
            },
            {
                path: ':id/price',
                name: 'HousePrice',
                component: () => import('../views/NewHouse/SetPrice.vue'),
            },
            {
                path: ':id/description',
                name: 'HouseDescription',
                component: () => import('../views/NewHouse/DescriptHouse.vue'),
            },
            // {
            //     path: ':id/photos',
            //     name: 'HousePhotos',
            //     component: () => import('../views/NewHouse/SetHousePhoto.vue'),
            // },
            {
                path: ':id/highlight',
                name: 'HouseHighlight',
                component: () => import('../views/NewHouse/ChooseHouseHighlight.vue'),
            },
        ]
    },
    {
        path: '/map',
        name: 'map',
        component: () => import('../components/Map/SearchMap.vue')
    },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router
