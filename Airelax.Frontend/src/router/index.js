import { createRouter, createWebHistory } from 'vue-router'

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
    component: () => import('../views/Search.vue')
  },
  {
    path: '/room/:houseId',
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
    path: '/new-house',
    name: 'NewHouse',
    component: () => import('../views/NewHouse/NewHouse.vue'),
    meta: {
      newHouseLayout: true,
    },
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
