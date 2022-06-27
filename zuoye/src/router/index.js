import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/list',
    name: 'home',
    component: () => import('../views/list.vue')
  },
  {
    path: '/add',
    name: 'home',
    component: () => import('../views/add.vue')
  },
  {
    path: '/upd',
    name: 'home',
    component: () => import('../views/upd.vue')
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/Login',
    name: 'home',
    component: () => import('../views/Admin/Login.vue')
  },
]

const router = new VueRouter({
  routes
})

export default router
