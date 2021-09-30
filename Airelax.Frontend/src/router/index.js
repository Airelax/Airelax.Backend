import {createRouter, createWebHistory} from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: () => import('../views/Home.vue'),
        meta: {
            homeLayout: true,
        },
    },
    {
        path: '/search',
        name: 'Search',
        component: () => import('../views/Search.vue'),
        meta: {
            searchPage: true,
            messageLayout: true,
        },
    },
    {
        path: '/message',
        name: 'Message',
        component: () => import('../views/Information.vue'),
        meta: {
            messageLayout: true,
        },
    },
    {
        path: '/room/:houseId',
        name: 'Room',
        component: () => import('../views/Room.vue')
    },
    {
        path: '/subscribe/:houseId',
        name: 'Subscribe',
        component: () => import('../views/Subscribe.vue')
    },
    {
        path: '/wishLists',
        name: 'wishLists',
        component: () => import('../views/WishLists.vue')
    },
    {
        path:'/wishLists/:id',
        name: 'wishList',
        component:() => import('../views/WishList.vue')
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
                name: 'Price',
                component: () => import('../views/NewHouse/SetPrice.vue'),
            },
            {
                path: ':id/description',
                name: 'HouseDescription',
                component: () => import('../views/NewHouse/DescriptHouse.vue'),
            },
            {
                path: ':id/photos',
                name: 'HousePhotos',
                component: () => import('../views/NewHouse/Photos.vue'),
            },
            {
                path: ':id/title',
                name: 'HouseTitle',
                component: () => import('../views/NewHouse/NamingHouse.vue'),
            },
        ]
    },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router
